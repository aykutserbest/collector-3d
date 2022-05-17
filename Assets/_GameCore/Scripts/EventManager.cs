using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager 
{
    public static Action<int> OnHoleTriggerEnter;
    
    public static Action OnFinishTriggerEnter;
    
    public static Action OnCompletedHoleTargetCount;
    
    public static Action OnLoseLevel;
    
    public static Action OnLWinLevel;
    
    public static Action RestartLevel;
    
    public static Action DestroyOldLevel;
}

