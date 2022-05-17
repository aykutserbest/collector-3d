using System;
using System.Collections;
using System.Collections.Generic;
using _GameCore.Scripts;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public void OnClickRestartBtn()
    {
        CanvasManager.Instance.VisibleLosePanel();
        EventManager.RestartLevel?.Invoke();
        
    }
    
    public void OnClickNextBtn()
    {
        CanvasManager.Instance.VisibleWinPanel();
        
        EventManager.DestroyOldLevel?.Invoke();
        
        LevelManager.Instance.StartLevel();
    }
    
    public void OnClickStartScreenBtn()
    {
        gameObject.SetActive(false);
        LevelManager.Instance.CollectorSpeedUp();
    }
}
