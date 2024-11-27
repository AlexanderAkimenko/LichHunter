using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagment
{
    public class AssetProvider : IAssetProvider
    {
        public GameObject Instantiate(string path)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab);
        }

        public GameObject Instantiate(string path, Transform instPosition)
        {
            var prefab = Resources.Load<GameObject>(path);
            return Object.Instantiate(prefab, instPosition.position, Quaternion.identity);
        }
    }
}