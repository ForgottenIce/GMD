using System.Collections;
using UnityEngine;

namespace Jumpable
{
    public class JumpPad : MonoBehaviour
    {
        [SerializeField] private float jumpPower;
        [SerializeField] private float jumpDelay;

        private Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.contacts[0].normal.y < 0)
            {
                var jumpable = other.gameObject.GetComponent<IJumpable>();
                if (jumpable != null)
                {
                    _animator.Play("slimeguy_stomp", -1, 0);
                    StartCoroutine(JumpAfterDelay(jumpable));
                }
            }
        }
        
        private IEnumerator JumpAfterDelay(IJumpable jumpable)
        {
            yield return new WaitForSeconds(jumpDelay);
            jumpable.Jump(jumpPower);
        }
    }
}
