using UnityEngine;

namespace _GameCore.Scripts
{
    public class CollectableController : MonoBehaviour
    {
        #region Variables
        
        private float staticYPosition = 5f;

        private Rigidbody _rigidbody;
        
        #endregion
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void Update()
        {
            if (gameObject.transform.position.y > staticYPosition)
            {
                _rigidbody.MovePosition(new Vector3(transform.position.x, staticYPosition, transform.position.z));
            }
        }
    }
}
