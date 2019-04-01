using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GalaSoft.MvvmLight.Messaging;
using PubFinder.Messages;
using PubFinder.Models;
using PubFinder.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace PubFinder.ViewModels
{
    class StartPageViewModel : ViewModelBase
    {
        private RelayCommand<PasswordBox> loginCommand;
        private readonly INavigationService navigation;
        private readonly AppDbContext db;

        private bool userRadBut=false;
        public bool UserRadBut { get => userRadBut; set => Set(ref userRadBut, value); }

        private bool ownerRadBut=false;
        public bool OwnerRadBut { get => ownerRadBut; set => Set(ref ownerRadBut, value); }

        private string userName;
        [Required]
        public string Username { get => userName; set => Set(ref userName, value); }

        public StartPageViewModel(INavigationService navigation, AppDbContext db)
        {
            this.navigation = navigation;
            this.db = db;
        }

        private RelayCommand signUpCommand;
        public RelayCommand SignUpCommand
        {
            get => signUpCommand ?? (signUpCommand = new RelayCommand(
                () =>
                {
                    if (UserRadBut)
                        navigation.Navigate<UserSignUpViewModel>();
                    else
                        navigation.Navigate<PubOwnerSignUpViewModel>();
                }
            ));
        }

        public RelayCommand<PasswordBox> LoginCommand
        {
            get => loginCommand ?? (loginCommand = new RelayCommand<PasswordBox>(
               param =>
               {
                   if (UserRadBut)
                   {
                       var UserCheck = db.Users.FirstOrDefault(x => x.UserName == userName);
                       if (UserCheck == null)
                       {
                           MessageBox.Show("User with that username not found");
                           return;
                       }
                       // Read the user's salt value from the database
                       string saltValueFromDB = UserCheck.SaltValue;
                       // Read the user's hash value from the database
                       string hashValueFromDB = UserCheck.HashValue;
                       byte[] saltedPassword = Encoding.UTF8.GetBytes(saltValueFromDB + param.Password);
                       // Hash the salted password using SHA256
                       SHA256Managed hashstring = new SHA256Managed();
                       byte[] hash = hashstring.ComputeHash(saltedPassword);
                       string hashToCompare = Convert.ToBase64String(hash);
                       if (hashValueFromDB.Equals(hashToCompare))
                       {
                           Messenger.Default.Send(new UserLogInOutMessage { UserId = UserCheck.Id });
                           navigation.Navigate<UserAccountViewModel>();
                       }
                       else
                           Console.WriteLine("Login credentials incorrect. User not validated.");
                   }
                   else
                   {
                       var PubCheck = db.Pubs.FirstOrDefault(x => x.Name == Username);
                       if (PubCheck == null)
                       {
                           MessageBox.Show("User with that username not found");
                           return;
                       }
                       // Read the user's salt value from the database
                       string saltValueFromDB = PubCheck.SaltValue;
                       // Read the user's hash value from the database
                       string hashValueFromDB = PubCheck.HashValue;
                       byte[] saltedPassword = Encoding.UTF8.GetBytes(saltValueFromDB + param.Password);
                       // Hash the salted password using SHA256
                       SHA256Managed hashstring = new SHA256Managed();
                       byte[] hash = hashstring.ComputeHash(saltedPassword);
                       string hashToCompare = Convert.ToBase64String(hash);
                       if (hashValueFromDB.Equals(hashToCompare))
                       {
                           Messenger.Default.Send(new PubLogInOutMessage { PubId = PubCheck.Id });
                           navigation.Navigate<UserAccountViewModel>();
                       }
                       else
                           Console.WriteLine("Login credentials incorrect. User not validated.");
                   }
               }));
        }
    }
}