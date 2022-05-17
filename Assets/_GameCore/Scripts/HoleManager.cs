using TMPro;
using UnityEngine;

namespace _GameCore.Scripts
{
    public class HoleManager : MonoBehaviour
    {
        [SerializeField] private int holeID;
        [SerializeField] private int targetCollectCount;
        private int _currentCollectCount;
        private bool _isCompletedHole;

        [SerializeField] private TextMeshPro targetCollectCountTxt;
        [SerializeField] private TextMeshPro currentCollectCountTxt;

        void OnEnable()
        {
            _isCompletedHole = true;
            targetCollectCountTxt.text = targetCollectCount.ToString();
            SubscribeHoleTriggerEvent();
        }
    
        void SubscribeHoleTriggerEvent()
        {
            EventManager.OnHoleTriggerEnter += CollectCounter;
        }

        private void OnDisable()
        {
            EventManager.OnHoleTriggerEnter -= CollectCounter;
        }

        private void CollectCounter(int currentHoleID)
        {
            if (holeID==currentHoleID)
            {
                _currentCollectCount++;
                currentCollectCountTxt.text = _currentCollectCount.ToString();
                
                if (_currentCollectCount == targetCollectCount && _isCompletedHole)
                {
                    _isCompletedHole = false;
                    EventManager.OnCompletedHoleTargetCount?.Invoke();
                }
            }

            
        }
        
    }
}
