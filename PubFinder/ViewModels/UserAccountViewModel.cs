using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PubFinder.Messages;
using PubFinder.Models;
using PubFinder.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace PubFinder.ViewModels
{
    public class BoolToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            bool checkValue = (bool)value;
            if (checkValue == true)
                return Visibility.Visible;
            else
                return Visibility.Hidden;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    class UserAccountViewModel:ViewModelBase
    {
        private ObservableCollection<Pub> pubs = new ObservableCollection<Pub>();
        public ObservableCollection<Pub> Pubs { get => pubs; set => Set(ref pubs, value); }

        private int loggedInUser = new int();
        public int LoggedInUser { get => loggedInUser; set => Set(ref loggedInUser, value); }

        private User activeUser = new User();
        public User ActiveUser { get => activeUser; set => Set(ref activeUser, value); }

        private bool menuOpen = true;
        public bool MenuOpen { get => menuOpen; set => Set(ref menuOpen, value); }

        private bool menuClose = false;
        public bool MenuClose { get => menuClose; set => Set(ref menuClose, value); }

        private readonly INavigationService navigation;
        private readonly AppDbContext db;

        public UserAccountViewModel(INavigationService navigation, AppDbContext db)
        {
            this.navigation = navigation;
            this.db = db;

            Messenger.Default.Register<UserLogInOutMessage>(this, msg =>
             {
                 LoggedInUser = msg.UserId;
                 ActiveUser = new User(db.Users.FirstOrDefault(x => x.Id == LoggedInUser));
                 Pubs = new ObservableCollection<Pub>(db.Pubs);
             },true);
        }

        private RelayCommand menuCloseCommand;
        public RelayCommand MenuCloseCommand
        {
            get => menuCloseCommand ?? (menuCloseCommand = new RelayCommand(
                () =>
                {
                    MenuClose = true;
                    MenuOpen = false;
                }
            ));
        }

        private RelayCommand menuOpenCommand;
        public RelayCommand MenuOpenCommand
        {
            get => menuOpenCommand ?? (menuOpenCommand = new RelayCommand(
                () =>
                {
                    MenuClose = false;
                    MenuOpen = true;
                }
            ));
        }
    }
}
