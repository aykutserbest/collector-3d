using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private List<Level> levelSOList;

    public List<Level> _levelSOList
    {
        get { return levelSOList;}
        set {  }
    }
    
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;             
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }
    
    
    
}
