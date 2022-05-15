using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HoleManager : MonoBehaviour
{
    [SerializeField] private int holeID;
    [SerializeField] private int targetCollectCount;
    private int _currentCollectCount;

    [SerializeField] private TextMeshPro targetCollectCountTxt;
    [SerializeField] private TextMeshPro currentCollectCountTxt;

    void OnEnable()
    {
        targetCollectCountTxt.text = targetCollectCount.ToString();
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
        _currentCollectCount++;
        currentCollectCountTxt.text = _currentCollectCount.ToString();

        if (_currentCollectCount >= targetCollectCount)
        {
            EventManager.OnCompletedHoleTargetCount?.Invoke();
        }
        
    }
}
