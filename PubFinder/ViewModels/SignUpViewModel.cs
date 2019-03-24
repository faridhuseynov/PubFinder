using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using PubFinder.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubFinder.ViewModels
{
    class SignUpViewModel:ViewModelBase
    {
        private readonly INavigationService navigation;

        public SignUpViewModel(INavigationService navigation)
        {
            this.navigation = navigation;
        }

        private RelayCommand userSignUpCommand;
        public RelayCommand UserSignUpCommand
        {
            get => userSignUpCommand ?? (userSignUpCommand = new RelayCommand(
                () =>
                {
                    navigation.Navigate<UserSignUpPageViewModel>();
                }
            ));
        }

        private RelayCommand pubSignUpCommand;
        public RelayCommand PubSignUpCommand
        {
            get => pubSignUpCommand ?? (pubSignUpCommand = new RelayCommand(
                () =>
                {
                    navigation.Navigate<UserSignUpPageViewModel>();
                }
            ));
        }

        private RelayCommand cancelSignUpCommand;
        public RelayCommand CancelSignUpCommand
        {
            get => cancelSignUpCommand ?? (cancelSignUpCommand = new RelayCommand(
                () =>
                {
                    navigation.Navigate<UserSignUpPageViewModel>();
                }
            ));
        }
    }
}
