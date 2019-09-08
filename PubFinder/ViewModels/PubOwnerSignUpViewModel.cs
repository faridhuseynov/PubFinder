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
    class PubOwnerSignUpViewModel:ViewModelBase
    {
        private readonly INavigationService navigation;
        private readonly AppDbContext db;
        private readonly IMessageService message;

        private Pub newPub = new Pub();
        public Pub NewPub { get => newPub; set => Set(ref newPub, value); }

        void PubDataClear()
        {
            NewPub.Email = NewPub.Name = NewPub.LogoLink =NewPub.Address=NewPub.PhoneNum= "";
        }

        public PubOwnerSignUpViewModel(INavigationService navigation, AppDbContext db, IMessageService message)
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

                    if (!String.IsNullOrEmpty(NewPub.Name) && !String.IsNullOrEmpty(NewPub.Address) && !String.IsNullOrEmpty(NewPub.PhoneNum)
                && !String.IsNullOrEmpty(param.Password) && IsValid(NewPub.Email))
                    {
                        if (db.Pubs.FirstOrDefault(x => x.Name == NewPub.Name) != null)
                            message.ShowError("This Pub with this name is already registered, please choose new username");
                        else
                        {
                            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
                            byte[] salt = new byte[32];
                            csprng.GetBytes(salt);
                            // Get the salt value
                            NewPub.SaltValue = Convert.ToBase64String(salt);
                            // Salt the password
                            byte[] saltedPassword = Encoding.UTF8.GetBytes(NewPub.SaltValue + param.Password);
                            // Hash the salted password using SHA256
                            SHA256Managed hashstring = new SHA256Managed();
                            byte[] hash = hashstring.ComputeHash(saltedPassword);
                            // Save both the salt and the hash in the user's database record.
                            NewPub.SaltValue = Convert.ToBase64String(salt);
                            NewPub.HashValue = Convert.ToBase64String(hash);
                            db.Pubs.Add(NewPub);
                            var NewUser = new User
                            {
                                Name = NewPub.Name.Replace(" ",""),
                                HashValue = NewPub.HashValue,
                                SaltValue = NewPub.SaltValue,
                                PhotoLink = NewPub.LogoLink,
                                Email = NewPub.Email,
                                UserName = NewPub.Name.Trim(' '),
                                RoleId = 2,
                                Surname = "pub"
                            };
                            db.Users.Add(NewUser);
                            db.SaveChanges();
                            Messenger.Default.Send(new PubLogInOutMessage { PubId = NewPub.Id });
                            PubDataClear();
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
                    PubDataClear();
                    navigation.Navigate<StartPageViewModel>();
                }
            ));
        }
    }
}