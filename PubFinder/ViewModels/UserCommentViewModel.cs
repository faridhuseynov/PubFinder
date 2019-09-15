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

        private bool isFavorite = false;
        public bool IsFavorite { get => isFavorite; set => Set(ref isFavorite, value); }

        private bool isntFavorite = true;
        public bool IsntFavorite { get => isntFavorite; set => Set(ref isntFavorite, value); }

        private int userRate = new int();
        public int UserRate { get => userRate; set => Set(ref userRate, value); }

        private Comment selectedComment = new Comment();
        public Comment SelectedComment { get => selectedComment; set => Set(ref selectedComment, value); }

        private string newFeedback;
        public string NewFeedback { get => newFeedback; set => Set(ref newFeedback, value); }
        
        private User activeUser = new User();
        public User ActiveUser { get => activeUser; set => Set(ref activeUser, value); }

        public Ranking Rank { get; set; }

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
                Rank = db.Rankings.FirstOrDefault(x=>x.UserId==ActiveUser.Id && x.PubId==Pub.Id);
                if (Rank == null)
                    UserRate = 0;
                else
                    UserRate = Rank.Score;
                if (db.FavoritePubs.FirstOrDefault(x => x.PubId == Pub.Id && x.UserId == ActiveUser.Id) != null)
                {
                    IsFavorite = true;
                    IsntFavorite = false;
                }
            }, true);
        }
        private RelayCommand addRemoveFavorite;
        public RelayCommand AddRemoveFavorite
        {
            get => addRemoveFavorite ?? (addRemoveFavorite = new RelayCommand(
                () =>
                {
                    if (IsFavorite == false)
                    {
                        IsFavorite = true;
                        IsntFavorite = false;
                    }
                    else
                    {
                        IsFavorite = false;
                        IsntFavorite = true;
                    }
                }
            ));
        }

        private RelayCommand<Comment> commentLikedCommand;
        public RelayCommand<Comment> CommentLikedCommand
        {
            get => commentLikedCommand ?? (commentLikedCommand = new RelayCommand<Comment>(
                param =>
                {
                    var commentRate = db.CommentRates.FirstOrDefault(x => x.PubId == Pub.Id
                                        &&
                                        x.UserId == ActiveUser.Id
                                        &&
                                        x.CommentId == param.Id);
                    if (commentRate != null)
                    {
                        if (commentRate.VoteId == 1)
                            return;
                        else if (commentRate.VoteId == 2)
                        {
                            db.CommentRates.Remove(commentRate);
                            --param.Dislike;
                        }
                    }

                    db.CommentRates.Add(new CommentRate
                    {
                        PubId = Pub.Id,
                        UserId = ActiveUser.Id,
                        CommentId = param.Id,
                        VoteId = 1
                    });
                    ++param.Like;
                    db.SaveChanges();
                    Comments = new ObservableCollection<Comment>(db.Comments.Where(x => x.PubId == Pub.Id));
                }
            ));
        }

        private RelayCommand<Comment> commentDislikedCommand;
        public RelayCommand<Comment> CommentDislikedCommand
        {
            get => commentDislikedCommand ?? (commentDislikedCommand = new RelayCommand<Comment>(
                param =>
                {
                    var commentRate = db.CommentRates.FirstOrDefault(x => x.PubId == Pub.Id
                                        &&
                                        x.UserId == ActiveUser.Id
                                        &&
                                        x.CommentId == param.Id);
                    if (commentRate != null)
                    {
                        if (commentRate.VoteId == 2)
                            return;
                        else if (commentRate.VoteId == 1)
                        {
                            db.CommentRates.Remove(commentRate);
                            --param.Like;
                        }
                    }
                    db.CommentRates.Add(new CommentRate
                    {
                        PubId = Pub.Id,
                        UserId = ActiveUser.Id,
                        CommentId = param.Id,
                        VoteId = 2
                    });
                    ++param.Dislike;
                    db.SaveChanges();
                    Comments = new ObservableCollection<Comment>(db.Comments.Where(x => x.PubId == Pub.Id));
                }
            ));
        }

        private RelayCommand goToBeerSetPageCommand;
        public RelayCommand GoToBeerSetPageCommand
        {
            get => goToBeerSetPageCommand ?? (goToBeerSetPageCommand = new RelayCommand(
                () =>
                {
                    RatingAndFavoriteValueChangedCheck();
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

                    RatingAndFavoriteValueChangedCheck();
                    navigation.Navigate<UserMenuViewModel>();
                }
            ));
        }
        void RatingAndFavoriteValueChangedCheck()
        {
            if (UserRate == 0)
                return;
            else if (Rank == null || Rank.Score == 0)
                db.Rankings.Add(new Ranking { PubId = Pub.Id, UserId = ActiveUser.Id, Score = UserRate });
            else if (UserRate != Rank.Score)
                db.Rankings.FirstOrDefault(x => x.PubId == Pub.Id && x.UserId == ActiveUser.Id).Score = UserRate;
            db.SaveChanges();
            db.Pubs.FirstOrDefault(x=>x.Id==Pub.Id).Rate = db.Rankings.Where(x => x.PubId == Pub.Id).Sum(x=>x.Score)/ db.Rankings.Count(x => x.PubId == Pub.Id);
            var favPub = db.FavoritePubs.FirstOrDefault(x => x.UserId == ActiveUser.Id && x.PubId == Pub.Id);
            if (IsFavorite)
            {
                if (favPub == null)
                    db.FavoritePubs.Add(new FavoritePub { PubId = Pub.Id, UserId = ActiveUser.Id });
            }
            else if (IsntFavorite)
            {
                if (favPub!= null)
                    db.FavoritePubs.Remove(favPub);
            }
            db.SaveChanges();
        }
        private RelayCommand ratingValueChangedCommand;
        public RelayCommand RatingValueChangedCommand
        {
            get => ratingValueChangedCommand ?? (ratingValueChangedCommand = new RelayCommand(
                () =>
                {
                    db.Pubs.FirstOrDefault(x => x.Id == Pub.Id).Rate = UserRate;
                    db.SaveChanges();
                }
            ));
        }
        private RelayCommand goToLocationPageCommand;
        public RelayCommand GoToLocationPageCommand
        {
            get => goToLocationPageCommand ?? (goToLocationPageCommand = new RelayCommand(
                () =>
                {
                    RatingAndFavoriteValueChangedCheck();
                    navigation.Navigate<UserLocationViewModel>();
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
                        db.Comments.Add(new Comment { Feedback = NewFeedback,  UserId = LoggedInUser, PubId = Pub.Id });
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
                    RatingAndFavoriteValueChangedCheck();
                    Comments = null;
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
                    RatingAndFavoriteValueChangedCheck();
                    Messenger.Default.Send(new UserLogInOutMessage { UserId = 0 });
                    navigation.Navigate<StartPageViewModel>();
                }
            ));
        }

    }
}
