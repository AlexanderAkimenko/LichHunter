using System;
using System.Collections.Generic;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.PersistentProgress;
using UnityEngine;

namespace CodeBase.Infrastructure.Factory
{
    public interface IGameFactory: IService
    {
        GameObject PlayerGameObject { get; }
        GameObject CreatePlayer(GameObject at);
        event Action PlayerCreated;
        
        GameObject Hud { get; set; }
        event Action HudCreated;
        GameObject CreateHud();

        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }

        void Cleanup();
    }
}