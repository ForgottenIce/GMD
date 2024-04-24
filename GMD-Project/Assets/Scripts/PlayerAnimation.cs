using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private PlayerMovement _playerMovement;
    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();  
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        
        // Subscribe to events
        _playerMovement.Moving += (moveDirection) =>
        {
            _animator.Play("player_walk");
            if (moveDirection > 0)
            {
                _spriteRenderer.flipX = false;
            }
            else if (moveDirection < 0)
            {
                _spriteRenderer.flipX = true;
            }
        };
        _playerMovement.Stopped += () => _animator.Play("player_idle");
        _playerMovement.Jumped += () => _animator.Play("player_jump");
        _playerMovement.Falling += () => _animator.Play("player_fall");
        _playerMovement.Landed += () => _animator.Play("player_land");
    }
}
