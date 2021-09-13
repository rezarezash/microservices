using System.Collections.Generic;
using PlatformService.Models;

namespace PlatformService.Data
{
    public interface IPlatformRepository
    {
        bool SaveChanges();
        IEnumerable<Platform> GetAllPlatforms();

        Platform GetplatformById(int id);

        void CreatePlatform(Platform entity);
    }
}