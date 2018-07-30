using System;
using System.Diagnostics;
using System.IO;
using AchievementTracker.Interfaces;

namespace AchievementTracker.iOS.Services
{
    public class FileService_iOS : IFileService
    {
        public string GetDbPath()
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "..", "Library", "test.db");
            Debug.WriteLine(path);
            return path;
        }
    }
}
