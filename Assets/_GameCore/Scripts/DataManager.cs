using System;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class DataManager : MonoBehaviour
    {
        public static DataManager Instance { get; private set; }

        [SerializeField] private GameData gameDataSO;
        
        private int _level;
        
        readonly string levelRegistryKey = "CurrentLevel";

        private void Awake()
        {
            if (Instance == null)
                Instance = this;
        }

        public GameData GameDataSO
        {
            get { return gameDataSO;}
        }
        
        public void LevelUp()
        {
            gameDataSO.currentLevelNumber++;
            if (gameDataSO.currentLevelNumber > 3)
            {
                gameDataSO.currentLevelNumber = 1;
            }
            _level = gameDataSO.currentLevelNumber;
            SaveLevel();
        }
        
        public void LoadLevel()
        {
            _level = PlayerPrefs.HasKey(levelRegistryKey) ? PlayerPrefs.GetInt(levelRegistryKey) : 1;
            gameDataSO.currentLevelNumber = _level;
        }

        void SaveLevel()
        {
            PlayerPrefs.SetInt(levelRegistryKey, _level);
        }

       
        

    }

}
