using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int collectCount;

    [SerializeField] private TextMeshPro targetCollectCountTxt;
    [SerializeField] private TextMeshPro currentCollectCountTxt;

    void OnEnable()
    {
        SubscribeHoleTriggerEvent();
    }
    
    void SubscribeHoleTriggerEvent()
    {
        EventManager.OnHoleTriggerEnter += CollectCounter;
    }

    private void OnDisable()
    {
        EventManager.OnHoleTriggerEnter -= CollectCounter;
    }

    private void CollectCounter()
    {
        collectCount++;
        currentCollectCountTxt.text = collectCount.ToString();
    }
}
