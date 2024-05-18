using System;
using Jumpable;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IJumpable
    {
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float gravity;
        [SerializeField] private float maxFallSpeed;
        [SerializeField] private float jumpPower;
        private float _currentSpeed;
        private int _moveDirection; // -1, 0 or 1
        private Vector2 _frameVelocity;
        private bool _isJumpHeld;
        private bool _canJump;
        private bool _jumpConsumed;
        private float _pendingJumpPower;
    
        private InputAction _moveAction;
        private InputAction _jumpAction;
    
        private Rigidbody2D _rb;
        private CapsuleCollider2D _col;

        public event Action<float /* moveSpeed */, float /* maxSpeed */> Moving;
        public event Action<float /* moveDirection */> DirectionChanged;
        public event Action Stopped;
        public event Action Jumped;
        public event Action Falling;
#pragma warning disable CS0067 // Event is never used
        public event Action Landed; // Not in use for now
#pragma warning restore CS0067 // Event is never used
    

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<CapsuleCollider2D>();
            _moveAction = InputSystem.ListEnabledActions().Find(a => a.name == "Move");
            _jumpAction = InputSystem.ListEnabledActions().Find(a => a.name == "Jump");
        }

        private void Update()
        {
            // Read input
            _moveDirection = (int)_moveAction.ReadValue<Vector2>().normalized.x;
            _isJumpHeld = _jumpAction.ReadValue<float>() > 0;
        }
    
        private void FixedUpdate()
        {
            HandleMovement();
            HandleGravity();
            HandleJump();

            _rb.velocity = _frameVelocity;
        }

        // TODO: Might need some refactoring
        private void HandleGravity()
        {
            Physics2D.queriesStartInColliders = false;
            var bounds = _col.bounds;
            var groundHitRayCast = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.down, 0.3f);
            bool groundHit = groundHitRayCast.collider != null && groundHitRayCast.collider.isTrigger == false;
            bool ceilingHit = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.up, 0.3f);
            if (!groundHit)
            {
                float newFallSpeed = _frameVelocity.y + gravity;
                if (newFallSpeed < -maxFallSpeed) newFallSpeed = -maxFallSpeed;
                _frameVelocity = new Vector2(_frameVelocity.x, newFallSpeed);
                _canJump = false;
                if (_frameVelocity.y < 0)
                {
                    Falling?.Invoke();
                    _pendingJumpPower = 0;
                }
                else Jumped?.Invoke();
            }
            else
            {
                _frameVelocity = new Vector2(_frameVelocity.x, 0);
                _canJump = true;
                if (!_isJumpHeld) _jumpConsumed = false;
            }

            if (ceilingHit && _frameVelocity.y > 0)
            {
                _frameVelocity = new Vector2(_frameVelocity.x, 0);
            }
        }

        private void HandleMovement()
        {
            switch (_moveDirection)
            {
                case -1:
                    if (_currentSpeed > 0) _currentSpeed = 0;
                    _currentSpeed += _moveDirection * acceleration;
                    DirectionChanged?.Invoke(_moveDirection);
                    if (_frameVelocity.y == 0) Moving?.Invoke(_currentSpeed, maxSpeed);
                    break;
                case 1:
                    if (_currentSpeed < 0) _currentSpeed = 0;
                    _currentSpeed += _moveDirection * acceleration;
                    DirectionChanged?.Invoke(_moveDirection);
                    if (_frameVelocity.y == 0) Moving?.Invoke(_currentSpeed, maxSpeed);
                    break;
                case 0:
                    _currentSpeed = 0;
                    if (_frameVelocity.y == 0) Stopped?.Invoke();
                    break;
            }
            _currentSpeed += _moveDirection * acceleration;
            if (_currentSpeed > maxSpeed) _currentSpeed = maxSpeed;
            if (_currentSpeed < -maxSpeed) _currentSpeed = -maxSpeed;
            _frameVelocity = new Vector2(_currentSpeed, _frameVelocity.y);
        }

        private void HandleJump()
        {
            if (_pendingJumpPower > 0 && !_jumpConsumed)
            {
                _frameVelocity = new Vector2(_frameVelocity.x, _pendingJumpPower);
                _jumpConsumed = true;
            }
            
            if (_canJump && _isJumpHeld && !_jumpConsumed)
            {
                _frameVelocity = new Vector2(_frameVelocity.x, jumpPower);
                _jumpConsumed = true;
            }

            // Descend when jump is released
            if (!_canJump && !_isJumpHeld && _frameVelocity.y > 0 && _pendingJumpPower == 0)
            {
                _frameVelocity = new Vector2(_frameVelocity.x, _frameVelocity.y * 0.2f);
            }

        }

        // Currently only used by JumpPads
        public void Jump(float power)
        {
            _pendingJumpPower = power;
        }
    }
}
