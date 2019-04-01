using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Messaging;
using PubFinder.Messages;
using PubFinder.Models;
using PubFinder.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.ViewModels
{
    class UserAccountViewModel:ViewModelBase
    {
        private ObservableCollection<Pub> pubs = new ObservableCollection<Pub>();
        public ObservableCollection<Pub> Pubs { get => pubs; set => Set(ref pubs, value); }

        private int loggedInUser = new int();
        public int LoggedInUser { get => loggedInUser; set => Set(ref loggedInUser, value); }

        private User activeUser = new User();
        public User ActiveUser { get => activeUser; set => Set(ref activeUser, value); }

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
    }
}
