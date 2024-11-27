using System;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(LichAnimator))]
    public class EnemyHealth : IHealth
    {
         [SerializeField] private LichAnimator _animator;

         // [SerializeField]
         // private IActor;
         private float _current;
         private float _max;
     


        public event Action ChangeHP;

        public float CurrentHP
        {
            get => _current;
            set => _current = value;
        }

        public float MaxHP
        {
            get => _max;
            set => _max = value;
        }
    }
}