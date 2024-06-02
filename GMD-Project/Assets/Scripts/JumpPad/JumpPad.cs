using System.Collections;
using UnityEngine;

namespace JumpPad
{
    public class JumpPad : MonoBehaviour
    {
        [SerializeField] private float jumpPower;
        [SerializeField] private float jumpDelay;
        [SerializeField] private AnimationClip animationClip;

        private Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.contacts[0].normal.y < 0)
            {
                var jumpable = other.gameObject.GetComponent<IJumpPadInteractable>();
                if (jumpable != null)
                {
                    if (animationClip != null)
                    {
                        _animator.Play(animationClip.name, -1, 0);
                    }
                    StartCoroutine(JumpAfterDelay(jumpable));
                }
            }
        }
        
        private IEnumerator JumpAfterDelay(IJumpPadInteractable jumpPadInteractable)
        {
            yield return new WaitForSeconds(jumpDelay);
            jumpPadInteractable.InteractWithJumpPad(jumpPower);
        }
    }
}
