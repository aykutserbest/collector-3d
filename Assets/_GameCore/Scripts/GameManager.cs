using System;
using System.Collections.Generic;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }

        [SerializeField] private List<Level> levelSOList;

        public List<Level> _levelSOList
        {
            get { return levelSOList;}
            set {  }
        }

        private void Start()
        {
            DataManager.Instance.LoadLevel();
            StartLevelProgress();
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

        private void StartLevelProgress()
        {
            LevelManager.Instance.StartLevel();
        }
        
        public int GetLevelTargetHole(int levelID)
        {
            return levelSOList[levelID].holeCount;
        }
        
    
    
    
    }
}
