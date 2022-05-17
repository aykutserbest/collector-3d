using System.Collections.Generic;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class LevelManager : MonoBehaviour
    {
        public static LevelManager Instance { get; private set; }
    
        [SerializeField] private GameObject collector;
        [SerializeField] private GameObject levelSocketObj;
        private GameObject _currentLevelPrefab;

        [SerializeField] private List<Level> _levelList;

        private CharacterMovementController _characterMovementController;

        private void Start()
        {
            if (Instance == null)
                Instance = this;
        
            GetReference();
        }

        private void OnEnable()
        {
            EventManager.OnLWinLevel += WinLevelProgress;
            EventManager.RestartLevel += RestartLevel;
        }
    
        private void OnDisable()
        {
            EventManager.OnLWinLevel -= WinLevelProgress;
            EventManager.RestartLevel -= RestartLevel;
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
        
        public void CollectorSpeedUp()
        {
            _characterMovementController.speed = 15;
        }

        public bool CheckLevelStatus(int completedHoleCount, int levelID)
        {
            var _CheckLevelStatus = _levelList[levelID].holeCount == completedHoleCount;
            return _CheckLevelStatus;
        }

        private void WinLevelProgress()
        {
            
            CanvasManager.Instance.ShowWinPanel();
        }
        
        private void RestartLevel()
        {
            EventManager.DestroyOldLevel?.Invoke();
            StartLevel();
        }
    
        public void StartLevel()
        {
            var currentLevelID = DataManager.Instance.GameDataSO.currentLevelNumber;
            _currentLevelPrefab = _levelList[currentLevelID].levelMesh;
            Instantiate(_currentLevelPrefab, levelSocketObj.transform);
            SetCollectorPosition();
            CanvasManager.Instance.ShowStartPanel();
        }

        private void SetCollectorPosition()
        {
            var currentLevelSpawnPoint = _currentLevelPrefab.GetComponent<LevelController>().spawnPoint.transform.position;
            collector.transform.position = new Vector3(currentLevelSpawnPoint.x, 0f, currentLevelSpawnPoint.z);
        }
    
    }
}
