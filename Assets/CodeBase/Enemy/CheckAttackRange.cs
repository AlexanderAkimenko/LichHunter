using UnityEngine;

namespace CodeBase.Enemy
{
    public class CheckAttackRange : MonoBehaviour
    {
        [SerializeField] private Attack _attack;
        [SerializeField] private TriggerObserver _triggerObserver;
        

        private void Start()
        {
            _triggerObserver.TriggerEnter += TriggerEnter;
            _triggerObserver.TriggerExit += TriggerExit;
            
        }
        private void TriggerEnter(Collider obj) => 
            _attack.EnableAttack();

        private void TriggerExit(Collider obj) => 
            _attack.DisableAttack();


      
       
    }
}