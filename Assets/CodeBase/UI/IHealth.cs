using System;

namespace CodeBase.UI
{
    public interface IHealth
    {
        public event Action ChangeHP;
        
        float CurrentHP { get; set; }
        float MaxHP { get; set; }
    }
}
