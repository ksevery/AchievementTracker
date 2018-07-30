using System;
using System.Linq;
using System.Collections.ObjectModel;
using AchievementTracker.Data;
using AchievementTracker.Models.Data;
using Prism.Navigation;
using Prism.Services;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using Acr.UserDialogs;

namespace AchievementTracker.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private AchievementsContext _db;

        private ObservableCollection<Achievement> _achievements = new ObservableCollection<Achievement>();

        public MainPageViewModel(INavigationService navigationService,
                                 IPageDialogService pageDialogService,
                                 IDeviceService deviceService,
                                 AchievementsContext db)
            : base(navigationService, pageDialogService, deviceService)
        {
            _db = db;
        }

        public ObservableCollection<Achievement> Achievements
        {
            get => _achievements;
            set
            {
                _achievements = value;
                RaisePropertyChanged();
            }
        }

        public ICommand AddItemCommand => new Command(async () =>
        {
            var newAchievementText = await ShowInputBoxDialog("Add Achievement", "Add a new Achievement:", string.Empty);
            if (!string.IsNullOrWhiteSpace(newAchievementText))
            {
                var achievement = new Achievement { Name = newAchievementText };
                _db.Achievements.Add(achievement);
                await _db.SaveChangesAsync();
                Achievements.Add(achievement);
            }
        });

        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            // Ensure database is created
            _db.Database.EnsureCreated();

            var achievement = _db.Achievements.FirstOrDefault();
            if (!_db.Achievements.Any())
            {
                // Insert Data
                _db.Add(new Achievement() { Name = "Test1" });
                _db.Add(new Achievement() { Name = "Test2" });
                _db.Add(new Achievement() { Name = "test3" });
                _db.SaveChanges();
            }

            var achievements = _db.Achievements.ToList();
            Achievements = new ObservableCollection<Achievement>(achievements);
        }

        private async Task<string> ShowInputBoxDialog(string title, string message, string text = "")
        {
            var config = new PromptConfig
            {
                Title = title,
                Message = message,
                Text = text
            };

            var result = await UserDialogs.Instance.PromptAsync(config);

            return result.Text;
        }
    }
}
