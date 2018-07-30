using System;
using AchievementTracker.Interfaces;
using AchievementTracker.iOS.Services;
using Prism;
using Prism.Ioc;

namespace AchievementTracker.iOS.Configuration
{
    public class AppConfiguration_iOS : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFileService, FileService_iOS>();
        }
    }
}
