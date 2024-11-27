using CodeBase.Infrastructure.Services;
using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagment
{
    public interface IAssetProvider : IService
    {
        GameObject Instantiate(string path);

        GameObject Instantiate(string path, Transform instPosition);
    }
}