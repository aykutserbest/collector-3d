using System;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class HoleTriggerController : MonoBehaviour
    {
        [SerializeField] private int holeID;
        private void OnTriggerEnter(Collider other)
        {
            EventManager.OnHoleTriggerEnter?.Invoke(holeID);
        }
    }
}
