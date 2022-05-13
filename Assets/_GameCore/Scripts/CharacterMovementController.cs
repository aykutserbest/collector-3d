using System;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class CharacterMovementController : MonoBehaviour
    {
        #region Variable
        [SerializeField] private float speed;
        [SerializeField] private float clampxMin = -2.7f;
        [SerializeField] private float clampxMax = 0.7f;

        private Rigidbody _rigidbody;
        #endregion
        
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        void FixedUpdate()
        {
            MovementAddDirection(Input.GetAxis("Horizontal"));
        }

        private void MovementAddDirection(float direction)
        {
            var newPositionX = (speed * Time.fixedDeltaTime) * -1 ;
            var newPositionZ = direction * speed * Time.fixedDeltaTime;
            
            _rigidbody.MovePosition(transform.position + new Vector3(newPositionX,0,newPositionZ));

            ClampedPositionCorner();
        }

        private void ClampedPositionCorner()
        {
            Vector3 clampedPosition = gameObject.transform.position;
            
            clampedPosition.z= Mathf.Clamp(clampedPosition.z, clampxMin, clampxMax);
            
            transform.position = clampedPosition;
        }
        
    }
}
