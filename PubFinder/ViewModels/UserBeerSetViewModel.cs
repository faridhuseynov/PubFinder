using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
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
    class UserBeerSetViewModel : ViewModelBase
    {
        //created this temporarily for testing the view. Instead of this will have quantity of setItem
        //public int QuantityTest { get; set; }
        private ObservableCollection<BeerSet> beerSets = new ObservableCollection<BeerSet>();
        public ObservableCollection<BeerSet> BeerSets { get => beerSets; set => Set(ref beerSets, value); }

        private ObservableCollection<SetItem> beerSetItems = new ObservableCollection<SetItem>();
        public ObservableCollection<SetItem> BeerSetItems { get => beerSetItems; set => Set(ref beerSetItems, value); }

        private Pub pub = new Pub();
        public Pub Pub { get => pub; set => Set(ref pub, value); }

        private int loggedInUser = new int();
        public int LoggedInUser { get => loggedInUser; set => Set(ref loggedInUser, value); }

        private BeerSet selectedSet = new BeerSet();
        public BeerSet SelectedSet { get => selectedSet; set => Set(ref selectedSet, value); }

        private User activeUser = new User();
        public User ActiveUser { get => activeUser; set => Set(ref activeUser, value); }

        private readonly INavigationService navigation;
        private readonly AppDbContext db;
        private readonly IMessageService message;
        public UserBeerSetViewModel(INavigationService navigation, AppDbContext db, IMessageService message)
        {
            this.navigation = navigation;
            this.db = db;
            this.message = message;
            this.navigation = navigation;
            Messenger.Default.Register<UserLogInOutMessage>(this, msg =>
            {
                LoggedInUser = msg.UserId;
                ActiveUser = new User(db.Users.FirstOrDefault(x => x.Id == LoggedInUser));
            }, true);
            Messenger.Default.Register<PubSelectedMessage>(this, msg =>
            {
                Pub = new Pub();
                Pub = db.Pubs.FirstOrDefault(x => x.Id == msg.PubId);
                BeerSets = new ObservableCollection<BeerSet>(db.BeerSets.Where(x => x.PubId == Pub.Id));
                    //foreach (var item in BeerSets)
                    //{
                    //    item.SetItems = new ObservableCollection<SetItem>();
                    //    item.SetItems = (db.SetItems.Where(x => x.BeerSetId == item.Id));
                    //}
                }, true);
        }

        //this function redirects from beers usercontrol to menus usercontrol
        private RelayCommand goToMenuPageCommand;
        public RelayCommand GoToMenuPageCommand
        {
            get => goToMenuPageCommand ?? (goToMenuPageCommand = new RelayCommand(
                () =>
                {
                    BeerSetItems = null;
                    navigation.Navigate<UserMenuViewModel>();
                }
            ));
        }

        //this function redirects from beers usercontrol to Comments usercontrol
        private RelayCommand goToCommentsPageCommand;
        public RelayCommand GoToCommentsPageCommand
        {
            get => goToCommentsPageCommand ?? (goToCommentsPageCommand = new RelayCommand(
                () =>
                {
                    BeerSetItems = null;
                    navigation.Navigate<UserCommentViewModel>();
                }
            ));
        }
        //
        //this is to show the set items once you double click with mouse on the set name
        private RelayCommand beerSetSelectedCommand;
        public RelayCommand BeerSetSelectedCommand
        {
            get => beerSetSelectedCommand ?? (beerSetSelectedCommand = new RelayCommand(
                () =>
                {
                    BeerSetItems = new ObservableCollection<SetItem>(db.SetItems.Where(x => x.BeerSetId == SelectedSet.Id));
                }
            ));
        }
        

        //this function redirects directly to Pubs usercontrol
        private RelayCommand returnToPubsCommand;
        public RelayCommand ReturnToPubsCommand
        {
            get => returnToPubsCommand ?? (returnToPubsCommand = new RelayCommand(
                () =>
                {
                    BeerSetItems = null;
                    navigation.Navigate<UserAccountViewModel>();
                }
            ));
        }
      

        private RelayCommand logOutCommand;
        public RelayCommand LogOutCommand
        {
            get => logOutCommand ?? (logOutCommand = new RelayCommand(
                () =>
                {
                    Messenger.Default.Send(new UserLogInOutMessage { UserId = 0 });
                    navigation.Navigate<StartPageViewModel>();
                }
            ));
        }

    }
}
