using UnityEngine;

namespace Unlockable
{
    public class Unlocker : MonoBehaviour
    {
        [SerializeField] private GameObject unlockableGameObject;
        private IUnlockable _unlockable;

        private void Start()
        {
            _unlockable = unlockableGameObject.GetComponent<IUnlockable>();
        }
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                _unlockable?.UnlockAction();
                Destroy(gameObject);
            }
        }
    }
}
