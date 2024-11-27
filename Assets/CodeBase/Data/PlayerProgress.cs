using System;

namespace CodeBase.Data
{
    [Serializable]
    public class PlayerProgress
    {
        public WorldData WorldData;
        public StateHealth StateHealth;
        public Stats PlayerStats;

        public PlayerProgress(string initialLevel)
        {
            WorldData = new WorldData(initialLevel);
            StateHealth = new StateHealth();
            PlayerStats = new Stats();
        }
    }
}