using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PubFinder.Messages;
using PubFinder.Models;
using PubFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.ViewModels
{
    class UserLocationViewModel:ViewModelBase
    {
        private readonly INavigationService navigation;
        private readonly AppDbContext db;
        private readonly IMessageService message;
        public UserLocationViewModel(INavigationService navigation, AppDbContext db, IMessageService message)
        {
            this.navigation = navigation;
            this.db = db;
            this.message = message;
            this.navigation = navigation;
            Messenger.Default.Register<UserLogInOutMessage>(this, msg =>
            {
                //LoggedInUser = msg.UserId;
                //ActiveUser = new User(db.Users.FirstOrDefault(x => x.Id == LoggedInUser));
            }, true);
            Messenger.Default.Register<PubSelectedMessage>(this, msg =>
            {
                //Pub = new Pub();
                //Pub = db.Pubs.FirstOrDefault(x => x.Id == msg.PubId);
                //BeerSets = new ObservableCollection<BeerSet>(db.BeerSets.Where(x => x.PubId == Pub.Id));
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
                    //BeerSetItems = null;
                    navigation.Navigate<UserMenuViewModel>();
                }
            ));
        }
        private RelayCommand goToBeerSetPageCommand;
        public RelayCommand GoToBeerSetPageCommand
        {
            get => goToBeerSetPageCommand ?? (goToBeerSetPageCommand = new RelayCommand(
                () =>
                {
                    //BeerSetItems = null;
                    navigation.Navigate<UserBeerSetViewModel>();
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
                    //BeerSetItems = null;
                    navigation.Navigate<UserCommentViewModel>();
                }
            ));
        }
        //
        //this is to show the set items once you double click with mouse on the set name


        //this function redirects directly to Pubs usercontrol
        private RelayCommand returnToPubsCommand;
        public RelayCommand ReturnToPubsCommand
        {
            get => returnToPubsCommand ?? (returnToPubsCommand = new RelayCommand(
                () =>
                {
                    //BeerSetItems = null;
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
