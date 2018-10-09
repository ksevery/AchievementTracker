using AchievementTracker.Interfaces;
using System;
using System.Diagnostics;
using System.IO;

namespace AchievementTracker.Droid.Services
{
    public class FileService_Droid : IFileService
    {
        public string GetDbPath()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), "exrin.db");
            Debug.WriteLine(path);
            return path;
        }
    }
}