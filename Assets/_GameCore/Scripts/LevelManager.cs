using System;
using System.Collections;
using System.Collections.Generic;
using _GameCore.Scripts;
using TMPro;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    
    [SerializeField] private GameObject collector;

    [SerializeField] private List<Level> _levelList;

    private CharacterMovementController _characterMovementController;

    private void Start()
    {
        if (Instance == null)
            Instance = this;
        
        GetReference();
    }
    
    private void GetReference()
    {
        _levelList = GameManager.Instance._levelSOList;
        _characterMovementController = collector.GetComponent<CharacterMovementController>();
    }

    public void CollectorSpeedDown()
    {
        _characterMovementController.speed = 0;
    }

    public bool CheckLevelStatus(int completedHoleCount, int levelID)
    {
        var _CheckLevelStatus = _levelList[levelID].holeCount == completedHoleCount;
        return _CheckLevelStatus;
        
    } 
    
}
