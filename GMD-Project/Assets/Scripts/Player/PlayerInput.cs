﻿using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerInput : MonoBehaviour
    {
        public int MoveDirection { get; private set; }
        public bool JumpHeld { get; private set; }
        public bool DashHeld { get; private set; }
        
        private InputAction _moveAction;
        private InputAction _jumpAction;
        private InputAction _dashAction;
        
        private void Start()
        {
            _moveAction = InputSystem.ListEnabledActions().Find(a => a.name == "Move");
            _jumpAction = InputSystem.ListEnabledActions().Find(a => a.name == "Jump");
            _dashAction = InputSystem.ListEnabledActions().Find(a => a.name == "Dash");
        }
        
        private void Update()
        {
            // Read input
            MoveDirection = (int)_moveAction.ReadValue<Vector2>().normalized.x;
            JumpHeld = _jumpAction.ReadValue<float>() > 0;
            DashHeld = _dashAction.ReadValue<float>() > 0;
        }
    }
}