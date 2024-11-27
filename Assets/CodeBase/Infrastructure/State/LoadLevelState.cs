using CodeBase.CameraLogic;
using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services.PersistentProgress;
using CodeBase.Logic;
using CodeBase.Player;
using CodeBase.UI;
using UnityEngine;

namespace CodeBase.Infrastructure.State
{
    public class LoadLevelState : IPayLoadedState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader, LoadingCurtain curtain, 
            IGameFactory gameFactory, IPersistentProgressService progressService)
        
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _curtain = curtain;
            _gameFactory = gameFactory;
            _progressService = progressService;
        }

        public void Enter(string nameScene)
        {
            if(_curtain != null) _curtain.Show();
            _sceneLoader.Load(nameScene,OnLoaded);
            _gameFactory.Cleanup();
        }

        private void OnLoaded()
        {
            InitialGameWorld();
            InformProgressReader();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReader()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
            {
                progressReader.LoadProgress(_progressService.Progress);
            }
        }
        private void InitialGameWorld()
        {
            GameObject player = CreatePlayer();
            InitHUD(player);
            CameraFollow(player);
        }

        private GameObject InitHUD( GameObject player)
        {
            GameObject hud = _gameFactory.CreateHud();
            hud.GetComponentInChildren<ActorUI>().Construct(player.GetComponent<PlayerHealth>());
            return hud;
        }

        private GameObject CreatePlayer()
        {
            return _gameFactory.CreatePlayer(GameObject.FindObjectOfType<InitializePoint>().gameObject);
        }

        private static void CameraFollow(GameObject player) => 
            Camera.main.GetComponent<CameraFollow>().Follow(player);

        public void Exit()
        {
           _curtain.Hide();
        }
    }
}