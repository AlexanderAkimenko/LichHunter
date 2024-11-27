using UnityEngine;


namespace CodeBase.Infrastructure
{
    public class GameRunner: MonoBehaviour
    {
        public GameBootstrapper GameBootstrappPrefab;

        private void Awake()
        {
            GameBootstrapper gameBootstrapper = FindObjectOfType<GameBootstrapper>();
            if (gameBootstrapper == null) Instantiate(GameBootstrappPrefab);
        }
    }
}