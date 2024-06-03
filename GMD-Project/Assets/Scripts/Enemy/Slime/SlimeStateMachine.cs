using Enemy.Slime.States;
using UnityEngine;

namespace Enemy.Slime
{
    public class SlimeStateMachine : MonoBehaviour
    {
        // Serialize Fields
        [SerializeField] private SlimeStats slimeStats;
        [SerializeField] private Collider2D visionRadius;
        [SerializeField] private Collider2D patrolArea;
        [SerializeField] private Rigidbody2D playerRigidbody;
        
        // Context
        private SlimeContext _slimeContext;
        
        // Components
        private Rigidbody2D _rb;
        private Collider2D _col;
        private Animator _animator;
        
        // States
        private SlimeState _idleState;
        private SlimeState _patrollingState;
        private SlimeState _chargingState;
        
        private SlimeState _currentState;

        private void Start()
        {
            _rb = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            
            _slimeContext = new SlimeContext(slimeStats, _rb, _col, _animator, visionRadius, patrolArea, playerRigidbody);
            
            _idleState = new SlimeIdleState();
            _patrollingState = new SlimePatrollingState();
            _chargingState = new SlimeChargingState();
            
            _currentState = _patrollingState;
            _currentState.EnterState(_slimeContext);
        }
        
        private void Update()
        {
            if (_currentState.StateComplete)
            {
                SelectState();
            }
            _currentState.Update(_slimeContext);
        }

        private void FixedUpdate()
        {
            _currentState.FixedUpdate(_slimeContext);
        }

        private void SelectState()
        {
            if (SlimeState.ShouldChargePlayer(_slimeContext))
            {
                _currentState = _chargingState;
            }
            else if(_slimeContext.PatrolOnNextStateChange)
            {
                _currentState = _patrollingState;
            }
            else
            {
                _currentState = _idleState;
            }
            
            _currentState.EnterState(_slimeContext);
        }
    }
}
