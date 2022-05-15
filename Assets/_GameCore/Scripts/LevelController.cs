using System.Collections;
using System.Collections.Generic;
using _GameCore.Scripts;
using TMPro;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] private int levelID;
    private int _completedHoleCount;
    
    private void Start()
    {
        SubscribeEvent();
    }
    
    private void SubscribeEvent()
    {
        EventManager.OnCompletedHoleTargetCount += IncreaseCompletedHoleCount;
        EventManager.OnFinishTriggerEnter += OnFinishTriggerEnter;
    }

    private void OnDisable()
    {
        EventManager.OnCompletedHoleTargetCount -= IncreaseCompletedHoleCount;
        EventManager.OnFinishTriggerEnter -= OnFinishTriggerEnter;
    }

    private void OnFinishTriggerEnter()
    {
        LevelManager.Instance.CollectorSpeedDown();
       
        StartCoroutine(Wait3Second());
        
        
    }
    
    IEnumerator Wait3Second()
    {
        yield return new WaitForSeconds(3);

        if (_completedHoleCount==0)
        {
            Debug.Log("lose");
            EventManager.OnLoseLevel?.Invoke();
        }
        else
        {
            var isLevelFinish = LevelManager.Instance.CheckLevelStatus(_completedHoleCount, levelID);

            if (isLevelFinish)
            {
                Debug.Log("win");
            }
            else
            {
                Debug.Log("continue");
            }
        }
        
       
        
        
        
    }
    
    private void IncreaseCompletedHoleCount()
    {
        _completedHoleCount++;
    }


}
