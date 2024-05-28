using System;
using Jumpable;
using UnityEngine;

namespace Player
{
    public class PlayerMovement : MonoBehaviour, IJumpable
    {
        // Player Parameterss
        [SerializeField] private float maxSpeed;
        [SerializeField] private float acceleration;
        [SerializeField] private float gravity;
        [SerializeField] private float maxFallSpeed;
        [SerializeField] private float jumpPower;
        [SerializeField] private float dashPower;
        [SerializeField] private float dashCooldown;
        
        // Player Properties
        private float _currentSpeed;
        private Vector2 _frameVelocity;
        private bool _canJump;
        private bool _jumpConsumed;
        private float _pendingJumpPower;
        private float _lastDashUsedTime;
        
        private bool _touchingGround;
        private bool _touchingCeiling;
        private bool _touchingLeftWall;
        private bool _touchingRightWall;
        
        // Player states
        private enum PlayerState { Grounded, Airborne, Dashing, WallSliding }
        private PlayerState _currentState;
        private bool _stateCompleted;
    
        // Components
        private PlayerInput _playerInput;
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
            _playerInput = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            if (_stateCompleted)
            {
                SelectState();
            }
            UpdateState();
        }
    
        private void FixedUpdate()
        {
            CheckCollisions();
            HandleMovement();
            HandleGravity();
            HandleJump();
            HandleDash();

            _rb.velocity = _frameVelocity;
        }
        
        private void SelectState()
        {
            _stateCompleted = false;

            if (_touchingGround)
            {
                _currentState = PlayerState.Grounded;
            }
            else
            {
                _currentState = PlayerState.Airborne;
            }
            Debug.Log("State: " + _currentState);
        }
        
        private void UpdateState()
        {
            switch (_currentState)
            {
                case PlayerState.Grounded:
                    UpdateGrounded();
                    break;
                case PlayerState.Airborne:
                    UpdateAirborne();
                    break;
                case PlayerState.Dashing:
                    break;
                case PlayerState.WallSliding:
                    break;
            }
        }

        private void UpdateGrounded()
        {
            if (!_touchingGround)
            {
                _stateCompleted = true;
            }
        }
        
        private void UpdateAirborne()
        {
            if (_touchingGround)
            {
                _stateCompleted = true;
            }
        }
        
        private void UpdateDashing()
        {
            //TODO: Implement
        }
        
        private void UpdateWallSliding()
        {
            //TODO: Implement
        }
        
        private void CheckCollisions()
        {
            Physics2D.queriesStartInColliders = false;
            var bounds = _col.bounds;
            _touchingGround = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.down, 0.3f, 1);
            _touchingCeiling = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.up, 0.3f, 1);
            _touchingLeftWall = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.left, 0.3f, 1);
            _touchingRightWall = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.right, 0.3f, 1);
        }

        // TODO: Might need some refactoring
        private void HandleGravity()
        {
            if (!_touchingGround)
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
                if (!_playerInput.JumpHeld) _jumpConsumed = false;
            }

            if (_touchingCeiling && _frameVelocity.y > 0)
            {
                _frameVelocity = new Vector2(_frameVelocity.x, 0);
            }
        }

        private void HandleMovement()
        {
            switch (_playerInput.MoveDirection)
            {
                case -1:
                    if (_currentSpeed > 0) _currentSpeed = 0;
                    _currentSpeed += _playerInput.MoveDirection * acceleration;
                    if (_touchingLeftWall) _currentSpeed = 0;
                    DirectionChanged?.Invoke(_playerInput.MoveDirection);
                    if (_frameVelocity.y == 0) Moving?.Invoke(_currentSpeed, maxSpeed);
                    break;
                case 1:
                    if (_currentSpeed < 0) _currentSpeed = 0;
                    _currentSpeed += _playerInput.MoveDirection * acceleration;
                    if (_touchingRightWall) _currentSpeed = 0;
                    DirectionChanged?.Invoke(_playerInput.MoveDirection);
                    if (_frameVelocity.y == 0) Moving?.Invoke(_currentSpeed, maxSpeed);
                    break;
                case 0:
                    _currentSpeed = 0;
                    if (_frameVelocity.y == 0) Stopped?.Invoke();
                    break;
            }
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
            
            if (_canJump && _playerInput.JumpHeld && !_jumpConsumed)
            {
                _frameVelocity = new Vector2(_frameVelocity.x, jumpPower);
                _jumpConsumed = true;
            }

            // Descend when jump is released
            if (!_canJump && !_playerInput.JumpHeld && _frameVelocity.y > 0 && _pendingJumpPower == 0)
            {
                _frameVelocity = new Vector2(_frameVelocity.x, _frameVelocity.y * 0.2f);
            }

        }

        // Currently only used by JumpPads
        public void Jump(float power)
        {
            _pendingJumpPower = power;
        }
        
        private void HandleDash()
        {
            if (_playerInput.DashHeld && Time.time + dashCooldown > _lastDashUsedTime)
            {
                _frameVelocity = new Vector2(_frameVelocity.x + dashPower * _playerInput.MoveDirection, 0);
                _lastDashUsedTime = Time.time;
            }
        }
    }
}
