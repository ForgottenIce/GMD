using UnityEngine;

namespace Jumpable
{
    public class Trampoline : MonoBehaviour
    {
        [SerializeField] private float jumpPower;

        private Animator _animator;
        private BoxCollider2D _boxCollider;
        private void Start()
        {
            _animator = GetComponent<Animator>();
            _boxCollider = GetComponent<BoxCollider2D>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.transform.position.y >= transform.position.y)
            {
                _animator.Play("slimeguy_stomp", -1, 0);
                _boxCollider.size = new Vector2(_boxCollider.size.x, 0.5f);
            }
        }
    }
}
