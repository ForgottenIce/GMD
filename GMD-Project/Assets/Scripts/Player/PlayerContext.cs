﻿using Input;
using Scriptable_Objects.Audio;
using UnityEngine;

namespace Player
{
    public class PlayerContext
    {
        public PlayerStats PlayerStats { get; }
        public InputManager InputManager { get; }
        public Rigidbody2D RigidBody { get; }
        public Animator Animator { get; }
        public AudioSource AudioSource { get; }
        public AudioClips AudioClips { get; }
        
        public PlayerCollisionData CollisionData { get; set; } // Must only be set by PlayerMovementStateMachine
        
        // Shared variables
        public bool JumpPadUsed { get; set; }
        public bool CoyoteTimeActive { get; set; }
        public bool DashAvailable { get; set; }
        public bool JumpOrbCollected { get; set; }
        
        public PlayerContext(PlayerStats playerStats, InputManager inputManager, Rigidbody2D rigidBody, Animator animator, AudioSource audioSource, AudioClips audioClips)
        {
            PlayerStats = playerStats;
            InputManager = inputManager;
            RigidBody = rigidBody;
            Animator = animator;
            AudioSource = audioSource;
            AudioClips = audioClips;
        }
    }
}