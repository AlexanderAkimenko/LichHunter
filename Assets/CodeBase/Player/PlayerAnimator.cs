
using CodeBase.Logic;
using UnityEngine;

namespace CodeBase.Player
{
    [RequireComponent(typeof(Animator))]
    
    public class PlayerAnimator: MonoBehaviour,IAnimationStateReader
    {
        
        private static readonly int Die = Animator.StringToHash("Die");
        private static readonly int Attack = Animator.StringToHash("Attack_1");
        private static readonly int  Attack2 = Animator.StringToHash("Attack_2");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int IsMoving = Animator.StringToHash("IsMoving");
        private static readonly int Speed = Animator.StringToHash("Speed");
        private static readonly int JumpAttack = Animator.StringToHash("JumpAttack");
        
        
        private  readonly int _idleStateHash = Animator.StringToHash("Idle_SwordShield");
        private readonly int _attackStateHash = Animator.StringToHash("NormalAttack01_SwordShield");
        private readonly int _nextAttackStateHesh = Animator.StringToHash("NormalAttack02_SwordShield");
        private readonly int _walkingStateHash = Animator.StringToHash("Move");
        private readonly int _deathStateHash = Animator.StringToHash("Die_SwordShield");
        
        [SerializeField] private Animator _animator;

        public AnimatorState State { get; }

        public bool IsAttacking => State == AnimatorState.Attack;

        public void PlayAttack() => _animator.SetTrigger(Attack);
        public void PlayNextAttack() => _animator.SetBool(Attack2,true);
        public void FinishingNextAttack() => _animator.SetBool(Attack2,false);

        public void PlayJumpAttack() => _animator.SetBool(JumpAttack, true);
        public void PlayHit() => _animator.SetTrigger(Hit);
        public void PlayDeath() => _animator.SetTrigger(Die);

        public void Move(float speed)
        {
            _animator.SetBool(IsMoving,true);
            _animator.SetFloat(Speed,speed);
        }

        public void StopMoving() => _animator.SetBool(IsMoving, false);
        
        
        public void EnteredState(int stateHash)
        {
            
        }

        public void ExitedState(int stateHash)
        {
          
        }

        private AnimatorState StateFor(int StateHash)
        {
            AnimatorState state;
            if (StateHash == _idleStateHash ) 
                state = AnimatorState.Idle;
            else if (StateHash == _attackStateHash ) 
                state = AnimatorState.Attack;  
            else if (StateHash == _nextAttackStateHesh ) 
                state = AnimatorState.NextAttack;
            else if (StateHash == _walkingStateHash ) 
                state = AnimatorState.Move;
            else if (StateHash == _deathStateHash)
                state = AnimatorState.Die;
            else
                state = AnimatorState.Unknown;

            return state;
        }
    }
}