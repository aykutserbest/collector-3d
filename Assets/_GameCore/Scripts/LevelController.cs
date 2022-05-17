using System.Collections;
using DG.Tweening;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private int levelID;
    
        public GameObject spawnPoint;
    
        private int _completedHoleCount;
        
        private int _continueCounter;
        
        
        [SerializeField] private GameObject[] swapFloors;
        private int _floorCounter;
        
        private void Start()
        {
            SubscribeEvent();
        }
    
        private void SubscribeEvent()
        {
            EventManager.DestroyOldLevel += DestroyLevel;
            EventManager.OnCompletedHoleTargetCount += IncreaseCompletedHoleCount;
            EventManager.OnFinishTriggerEnter += OnFinishTriggerEnter;
        }

        private void OnDisable()
        {
            EventManager.DestroyOldLevel -= DestroyLevel;
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
                //todo:en sonuncu hole bu sefer finishe bakacak, not continue
                Debug.Log(_completedHoleCount);
                var isLevelFinish = LevelManager.Instance.CheckLevelStatus(_completedHoleCount, levelID);

                if (isLevelFinish)
                {
                    Debug.Log("succesful");
                    
                    DataManager.Instance.LevelUp();
                    EventManager.OnLWinLevel?.Invoke();
                }
                else
                {
                    IsContinue();
                    
                   
                }
            }
        }

        private void IsContinue()
        {
            _continueCounter++;
            var isEqual = _completedHoleCount == _continueCounter;
            if (!isEqual)
            {
                Debug.Log("lose");
                EventManager.OnLoseLevel?.Invoke();
            }
            else
            {
                swapFloors[_floorCounter].gameObject.transform.DOLocalMoveY(97.6f, 0.2f);
                _floorCounter++;
                LevelManager.Instance.CollectorSpeedUp();
                Debug.Log("continue");
            }
        }
        
        
        private void DestroyLevel()
        {
            Destroy(gameObject);
        }
    
        private void IncreaseCompletedHoleCount()
        {
            _completedHoleCount++;
        }


    }
}
