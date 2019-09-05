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
using System.Windows;

namespace PubFinder.ViewModels
{
    class UserCommentViewModel: ViewModelBase
    {
        private ObservableCollection<Comment> comments = new ObservableCollection<Comment>();
        public ObservableCollection<Comment> Comments { get => comments; set => Set(ref comments, value); }

        private Pub pub = new Pub();
        public Pub Pub { get => pub; set => Set(ref pub, value); }

        private int loggedInUser = new int();
        public int LoggedInUser { get => loggedInUser; set => Set(ref loggedInUser, value); }

        private Comment selectedComment = new Comment();
        public Comment SelectedComment { get => selectedComment; set => Set(ref selectedComment, value); }

        private string newFeedback;
        public string NewFeedback { get => newFeedback; set => Set(ref newFeedback, value); }
        
        private User activeUser = new User();
        public User ActiveUser { get => activeUser; set => Set(ref activeUser, value); }

        private bool menuOpen = true;
        public bool MenuOpen { get => menuOpen; set => Set(ref menuOpen, value); }

        private bool menuClose = false;
        public bool MenuClose { get => menuClose; set => Set(ref menuClose, value); }


        private readonly INavigationService navigation;
        private readonly AppDbContext db;
        private readonly IMessageService message;
        public UserCommentViewModel(INavigationService navigation, AppDbContext db, IMessageService message)
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
                Comments = new ObservableCollection<Comment>(db.Comments.Where(x => x.PubId == Pub.Id));
                //foreach (var item in BeerSets)
                //{
                //    item.SetItems = new ObservableCollection<SetItem>();
                //    item.SetItems = (db.SetItems.Where(x => x.BeerSetId == item.Id));
                //}
            }, true);
        }


        private RelayCommand goToBeerSetPageCommand;
        public RelayCommand GoToBeerSetPageCommand
        {
            get => goToBeerSetPageCommand ?? (goToBeerSetPageCommand = new RelayCommand(
                () =>
                {
                    navigation.Navigate<UserBeerSetViewModel>();
                }
            ));
        }

        //this function redirects from beers usercontrol to menus usercontrol
        private RelayCommand goToMenuPageCommand;
        public RelayCommand GoToMenuPageCommand
        {
            get => goToMenuPageCommand ?? (goToMenuPageCommand = new RelayCommand(
                () =>
                {
                    navigation.Navigate<UserMenuViewModel>();
                }
            ));
        }

        //this commant for adding new comment
        private RelayCommand addNewCommentCommand;
        public RelayCommand AddNewCommentCommand
        {
            get => addNewCommentCommand ?? (addNewCommentCommand = new RelayCommand(
                () =>
                {
                    if (!String.IsNullOrWhiteSpace(NewFeedback))
                    {
                        db.Comments.Add(new Comment { Feedback = NewFeedback, Weight = 0, UserId = LoggedInUser, PubId = Pub.Id });
                        db.SaveChanges();
                        NewFeedback = "";
                        Comments = new ObservableCollection<Comment>(db.Comments.Where(x => x.PubId == Pub.Id));
                    }
                    else
                    {
                        MessageBox.Show("Comment field is empty!");
                    }
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
                    Comments = null;
                    navigation.Navigate<UserAccountViewModel>();
                }
            ));
        }

        private RelayCommand menuOpenCommand;
        public RelayCommand MenuOpenCommand
        {
            get => menuOpenCommand ?? (menuOpenCommand = new RelayCommand(
                () =>
                {
                    MenuClose = true;
                    MenuOpen = false;
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
