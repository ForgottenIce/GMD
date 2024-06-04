using Input;
using JumpPad;
using Player.MovementStates;
using UnityEngine;
using UnityEngine.Serialization;

namespace Player
{
    public class PlayerMovementStateMachine : MonoBehaviour, IJumpPadInteractable
    {
        // Stats
        [SerializeField] private PlayerStats playerStats;
        
        // Context
        private PlayerContext _playerContext;
    
        // Components
        [SerializeField] private InputManager inputManager;
        private Rigidbody2D _rb;
        private CapsuleCollider2D _col;
        private Animator _animator;
        
        // States
        private PlayerMovementState _idleState;
        private PlayerMovementState _movingState;
        private PlayerMovementState _jumpingState;
        private PlayerMovementState _fallingState;
        private PlayerMovementState _dashingState;
        
        private PlayerMovementState _currentState;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _col = GetComponent<CapsuleCollider2D>();
            _animator = GetComponent<Animator>();
            
            _playerContext = new PlayerContext(playerStats, inputManager, _rb, _animator);
            
            _idleState = new PlayerIdleState();
            _movingState = new PlayerMovingState();
            _jumpingState = new PlayerJumpingState();
            _fallingState = new PlayerFallingState();
            _dashingState = new PlayerDashingState();
            
            _currentState = _fallingState;
            _currentState.EnterState(_playerContext);
        }

        private void Update()
        {
            if (_currentState.StateComplete)
            {
                SelectState();
            }
            _currentState.Update(_playerContext);
        }
    
        private void FixedUpdate()
        {
            CheckCollisions();
            _currentState.FixedUpdate(_playerContext);
        }

        private void SelectState()
        {
            if (inputManager.DashHeld && _playerContext.DashAvailable)
            {
                _currentState = _dashingState;
            }
            else if (_playerContext.CollisionData.TouchingGround && inputManager.MoveDirection == 0)
            {
                _currentState = _idleState;
            }
            else if (_playerContext.CollisionData.TouchingGround && inputManager.MoveDirection != 0)
            {
                _currentState = _movingState;
            }
            else if (!_playerContext.CollisionData.TouchingGround && _rb.velocity.y > 0 && (inputManager.JumpHeld || _playerContext.JumpPadUsed))
            {
                _currentState = _jumpingState;
            }
            else
            {
                _currentState = _fallingState;
            }
            
            _currentState.EnterState(_playerContext);
            // Debug.Log("Entered state: " + _currentState.GetType().Name.Replace("Player", ""));
        }
        
        private void CheckCollisions()
        {
            Physics2D.queriesStartInColliders = false;
            var bounds = _col.bounds;
            bool touchingGround = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.down, 0.5f, 1);
            bool touchingCeiling = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.up, 0.5f, 1);
            bool touchingLeftWall = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.left, 0.5f, 1);
            bool touchingRightWall = Physics2D.CapsuleCast(bounds.center, _col.size, _col.direction, 0, Vector2.right, 0.5f, 1);

            _playerContext.CollisionData = new PlayerCollisionData(touchingGround, touchingCeiling, touchingLeftWall, touchingRightWall);
        }
        
        public void InteractWithJumpPad(float power)
        {
            _currentState.InteractWithJumpPad(_playerContext, power);
        }
        
        public void JumpOrbCollected()
        {
            _playerContext.JumpOrbCollected = true;
        }

        public void DashOrbCollected()
        {
            _playerContext.DashAvailable = true;
        }
    }
}
