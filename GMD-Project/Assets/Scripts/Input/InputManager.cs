using UnityEngine;
using UnityEngine.InputSystem;

namespace Input
{
    public class InputManager : MonoBehaviour
    {
        // Player input
        public int MoveDirection { get; private set; }
        public bool JumpPressed { get; private set; }
        public bool JumpHeld { get; private set; }
        public bool DashPressed { get; private set; }
        public bool DashHeld { get; private set; }
        public bool InteractPressed { get; private set; }
        
        // Menu input
        public bool PausePressed { get; private set; }
        public bool MenuUpPressed { get; private set; }
        public bool MenuDownPressed { get; private set; }
        public bool MenuClickPressed { get; private set; }
        
        // Player input actions
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private InputAction _dashAction;
        private InputAction _interactAction;
        
        // Menu input actions
        private InputAction _pauseAction;
        private InputAction _menuUpAction;
        private InputAction _menuDownAction;
        private InputAction _menuClickAction;
        
        // Bool to disable pause button when in menus
        public bool PauseButtonDisabled { get; set; }
        
        private void Start()
        {
            _moveAction = InputSystem.ListEnabledActions().Find(a => a.name == "Move");
            _jumpAction = InputSystem.ListEnabledActions().Find(a => a.name == "Jump");
            _dashAction = InputSystem.ListEnabledActions().Find(a => a.name == "Dash");
            _interactAction = InputSystem.ListEnabledActions().Find(a => a.name == "Interact");
            
            _pauseAction = InputSystem.ListEnabledActions().Find(a => a.name == "Pause");
            _menuUpAction = InputSystem.ListEnabledActions().Find(a => a.name == "MenuUp");
            _menuDownAction = InputSystem.ListEnabledActions().Find(a => a.name == "MenuDown");
            _menuClickAction = InputSystem.ListEnabledActions().Find(a => a.name == "MenuClick");
        }
        
        private void Update()
        {
            // Read input
            MoveDirection = (int)_moveAction.ReadValue<Vector2>().normalized.x;
            JumpPressed = _jumpAction.triggered;
            JumpHeld = _jumpAction.ReadValue<float>() > 0;
            DashPressed = _dashAction.triggered;
            DashHeld = _dashAction.ReadValue<float>() > 0;
            InteractPressed = _interactAction.triggered;   
            
            PausePressed = _pauseAction.triggered && !PauseButtonDisabled;
            MenuUpPressed = _menuUpAction.triggered;
            MenuDownPressed = _menuDownAction.triggered;
            MenuClickPressed = _menuClickAction.triggered;
        }
    }
}