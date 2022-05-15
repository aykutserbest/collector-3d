using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
