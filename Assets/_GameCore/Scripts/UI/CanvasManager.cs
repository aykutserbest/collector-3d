using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager Instance { get; private set; }
    
    
    [SerializeField] private GameObject losePanelObj;
    [SerializeField] private GameObject startPanelObj;
    [SerializeField] private GameObject winPanelObj;
    
    private void Start()
    {
        if (Instance == null)
            Instance = this;
        
    }

    private void OnEnable()
    {
        EventManager.OnLoseLevel += ShowLosePanel;
    }
    
    private void OnDisable()
    {
        EventManager.OnLoseLevel -= ShowLosePanel;
    }

    private void ShowLosePanel()
    {
        losePanelObj.SetActive(true);
    }

    public void VisibleLosePanel()
    {
        losePanelObj.SetActive(false);
    }
    
    public void ShowStartPanel()
    {
        startPanelObj.SetActive(true);
    }

    public void ShowWinPanel()
    {
        winPanelObj.SetActive(true);
    }
    
    public void VisibleWinPanel()
    {
        winPanelObj.SetActive(false);
    }

}
