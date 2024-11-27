using CodeBase.Infrastructure.Factory;
using CodeBase.Infrastructure.Services;
using UnityEngine;
using UnityEngine.AI;

namespace CodeBase.Enemy
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class AgentMoveToPlayer : Follow
    {
        public NavMeshAgent Agent;
        private Transform _player;

        private IGameFactory _gameFactory;
        private void Start()
        {
            _gameFactory = AllServices.Container().Single<IGameFactory>();
            if (_gameFactory.PlayerGameObject !=null)
            {
                GetPlayerTransform();
            }
            else
            {
                _gameFactory.PlayerCreated += GetPlayerTransform;
            }
            
        }

        void Update()
        {
            if (_player != null )
            {
                Agent.SetDestination(_player.position);
            }
        }

        private void GetPlayerTransform() => 
            _player = _gameFactory.PlayerGameObject.transform;
    }
}
