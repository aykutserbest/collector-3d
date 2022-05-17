using UnityEngine;

namespace _GameCore.Scripts
{
    public class LevelFinishBorderController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                EventManager.OnFinishTriggerEnter?.Invoke();
            }
        }
    }
}
