using CodeBase.Data;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public interface ISaveLoadSrvice : IService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}