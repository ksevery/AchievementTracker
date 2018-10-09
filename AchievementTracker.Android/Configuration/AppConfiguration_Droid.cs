using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AchievementTracker.Droid.Services;
using AchievementTracker.Interfaces;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Prism;
using Prism.Ioc;

namespace AchievementTracker.Droid.Configuration
{
    public class AppConfiguration_Droid : IPlatformInitializer
    {
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<IFileService, FileService_Droid>();
        }
    }
}