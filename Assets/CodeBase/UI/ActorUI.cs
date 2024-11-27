
using UnityEngine;

namespace CodeBase.UI
{
    public class ActorUI : MonoBehaviour
    {
        [SerializeField] private HPBar _hpBar;

        private IHealth _playerStateHealth;

        private void OnDestroy()
        {
            _playerStateHealth.ChangeHP -= UpdateHPBar;
        }

        public void Construct(IHealth stateHealth)
        {
            _playerStateHealth = stateHealth;
            _playerStateHealth.ChangeHP += UpdateHPBar;

        }

        private void UpdateHPBar()
        {
            _hpBar.SetValue(_playerStateHealth.CurrentHP, _playerStateHealth.MaxHP);
        }
    }
}
