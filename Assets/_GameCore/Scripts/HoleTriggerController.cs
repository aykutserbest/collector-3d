using System;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class HoleTriggerController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            EventManager.OnHoleTriggerEnter?.Invoke();
        }
    }
}
