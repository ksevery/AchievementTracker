using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Prism;
using Prism.AppModel;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Autofac;
using Autofac;
using System.Collections.Generic;
using AchievementTracker.Models.Data;
using AchievementTracker.Data;
using System.Linq;
using AchievementTracker.Views;
using AchievementTracker.Interfaces;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace AchievementTracker
{
    public partial class App : PrismApplication
    {
        private string _dbPath;

        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.GetBuilder().Register((arg) => 
            {
                var fileService = arg.Resolve<IFileService>();
                var dbPath = fileService.GetDbPath();
                return new AchievementsContext(dbPath);
            });

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage>();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
