using System;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class CharacterMovementController : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float clampxMin = -2.7f;
        [SerializeField] private float clampxMax = 0.7f;

        private Rigidbody _rigidbody;

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
            
           // _rigidbody.AddForce(-1 * speed * Time.deltaTime, 0, direction * speed * Time.deltaTime);

           transform.Translate(-1 * speed * Time.fixedDeltaTime, 0, direction * speed * Time.fixedDeltaTime);

            Vector3 clampedPosition = gameObject.transform.position;
            
            clampedPosition.z= Mathf.Clamp(clampedPosition.z, clampxMin, clampxMax);
            
            transform.position = clampedPosition;
        }
    }
}
