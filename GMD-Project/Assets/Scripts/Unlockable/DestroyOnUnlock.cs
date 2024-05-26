using UnityEngine;

namespace Unlockable
{
    public class DestroyOnUnlock : MonoBehaviour, IUnlockable
    {
        public void UnlockAction()
        {
            Destroy(gameObject);
        }
    }
}
