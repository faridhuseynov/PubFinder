using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PubFinder.Messages;
using PubFinder.Models;
using PubFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PubFinder.ViewModels
{
    class UserSignUpViewModel:ViewModelBase
    {
        private readonly INavigationService navigation;
        private readonly AppDbContext db;
        private readonly IMessageService message;

        private User newUser = new User();
        public User NewUser { get => newUser; set => Set(ref newUser, value); }

        void UserDataClear()
        {
            NewUser.Email = NewUser.Name = NewUser.PhotoLink = NewUser.Surname = NewUser.UserName = "";
        }

        public UserSignUpViewModel(INavigationService navigation, AppDbContext db, IMessageService message)
        {
            this.navigation = navigation;
            this.db = db;
            this.message = message;
        }

        //taken from StackOverflow for email validation
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private RelayCommand<PasswordBox> registerCommand;
        public RelayCommand<PasswordBox> RegisterCommand
        {
            get => registerCommand ?? (registerCommand = new RelayCommand<PasswordBox>(
                param =>
                {

                    if (!String.IsNullOrEmpty(NewUser.Name) && !String.IsNullOrEmpty(NewUser.Surname) && !String.IsNullOrEmpty(NewUser.UserName)
                && !String.IsNullOrEmpty(param.Password) && IsValid(NewUser.Email))
                    {
                        if (db.Users.FirstOrDefault(x => x.UserName == NewUser.UserName) != null)
                            message.ShowError("This Username is already being used, please choose new username");
                        else
                        {
                            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
                            byte[] salt = new byte[32];
                            csprng.GetBytes(salt);
                            // Get the salt value
                            NewUser.SaltValue = Convert.ToBase64String(salt);
                            // Salt the password
                            byte[] saltedPassword = Encoding.UTF8.GetBytes(NewUser.SaltValue + param.Password);
                            // Hash the salted password using SHA256
                            SHA256Managed hashstring = new SHA256Managed();
                            byte[] hash = hashstring.ComputeHash(saltedPassword);
                            // Save both the salt and the hash in the user's database record.
                            NewUser.SaltValue = Convert.ToBase64String(salt);
                            NewUser.HashValue = Convert.ToBase64String(hash);
                            db.Users.Add(NewUser);
                            db.SaveChanges();
                            Messenger.Default.Send(new UserLogInOutMessage{ UserId = NewUser.Id });
                            UserDataClear();
                            navigation.Navigate<StartPageViewModel>();
                        }
                    }
                    else
                    {
                        message.ShowError("Please check validation errors");
                    }
                }
            ));
        }

        private RelayCommand cancelCommand;
        public RelayCommand CancelCommand
        {
            get => cancelCommand ?? (cancelCommand = new RelayCommand(
                () =>
                {
                    UserDataClear();
                    navigation.Navigate<StartPageViewModel>();
                }
            ));
        }
    }
}
