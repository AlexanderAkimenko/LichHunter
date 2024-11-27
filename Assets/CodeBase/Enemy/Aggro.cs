using System.Collections;
using UnityEngine;

namespace CodeBase.Enemy
{
    public class Aggro : MonoBehaviour
    {
        [SerializeField] private TriggerObserver _triggerObserver;
        [SerializeField] private Follow _follow;
        [SerializeField] private float _cooldown;
        
        private bool _hasAggroTarget;
        private Coroutine _aggroCoroutine;
        private void Start()
        {
            _triggerObserver.TriggerEnter += TriggerEnter;
            _triggerObserver.TriggerExit += TriggerExit;
        }

        private void TriggerEnter( Collider obj)
        {
            if (!_hasAggroTarget)
            {
                SwitchFollowOn();
                _hasAggroTarget = true;
                StopAggroCoroutine();
            }
         
        }

        private void TriggerExit( Collider obj)
        {
            if (_hasAggroTarget)
            {
                _aggroCoroutine = StartCoroutine(SwitchFollowOffAfterCooldown());
                _hasAggroTarget = false;
            }
        }

        private void StopAggroCoroutine()
        {
            if (_aggroCoroutine != null)
            {
                StopCoroutine(_aggroCoroutine);
                _aggroCoroutine = null;  
            }
        }

        IEnumerator SwitchFollowOffAfterCooldown()
        {
            yield return new WaitForSeconds(_cooldown);
            SwitchFollowOff();
            _hasAggroTarget = false;
        }

        private void SwitchFollowOn() => _follow.enabled = true;
        private void SwitchFollowOff() => _follow.enabled = false;
    }
}