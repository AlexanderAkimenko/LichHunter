using System;
using CodeBase.Infrastructure.Services;
using CodeBase.Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace CodeBase.Logic
{
    public class SaveTrigger: MonoBehaviour
    {
        private ISaveLoadSrvice _saveLoadService;
        public BoxCollider Collider;
        private void Awake()
        {
            _saveLoadService = AllServices.Container().Single<ISaveLoadSrvice>();
        }

        private void OnTriggerEnter(Collider other)
        {
            _saveLoadService.SaveProgress();
            Debug.Log("save");
            gameObject.SetActive(false);
        }

        private void OnDrawGizmos()
        {
            if (Collider != null)
            {
                Gizmos.color = new Color32(255, 255, 255, 130);
                Gizmos.DrawCube(transform.position + Collider.center, Collider.size);
            }
          
        }
    }
}