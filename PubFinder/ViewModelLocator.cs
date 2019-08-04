﻿using Autofac;
using Autofac.Configuration;
using GalaSoft.MvvmLight;
using Microsoft.Extensions.Configuration;
using PubFinder.Services;
using PubFinder.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PubFinder
{
    class ViewModelLocator
    {
        private AppViewModel appViewModel;
        private StartPageViewModel startPageViewModel;
        private UserSignUpViewModel userSignUpViewModel;
        private PubOwnerSignUpViewModel pubOwnerSignUpViewModel;
        private UserAccountViewModel userAccountViewModel;
        private UserMenuViewModel userMenuViewModel;
        private UserBeerSetViewModel userBeerSetViewModel;

        private INavigationService navigationService;
        private IMessageService messageService;

        public static IContainer Container;

        public ViewModelLocator()
        {
            try
            {   
                var config = new ConfigurationBuilder();
                config.AddJsonFile("autofac.json");
                var module = new ConfigurationModule(config.Build());
                var builder = new ContainerBuilder();
                builder.RegisterModule(module);
                Container = builder.Build();

                navigationService = Container.Resolve<INavigationService>();
                messageService = Container.Resolve<IMessageService>();

                appViewModel = Container.Resolve<AppViewModel>();
                startPageViewModel = Container.Resolve<StartPageViewModel>();
                userSignUpViewModel = Container.Resolve<UserSignUpViewModel>();
                pubOwnerSignUpViewModel = Container.Resolve<PubOwnerSignUpViewModel>();
                userAccountViewModel = Container.Resolve<UserAccountViewModel>();
                userMenuViewModel = Container.Resolve<UserMenuViewModel>();
                userBeerSetViewModel = Container.Resolve<UserBeerSetViewModel>();

                navigationService.Register<StartPageViewModel>(startPageViewModel);
                navigationService.Register<UserSignUpViewModel>(userSignUpViewModel);
                navigationService.Register<PubOwnerSignUpViewModel>(pubOwnerSignUpViewModel);
                navigationService.Register<UserAccountViewModel>(userAccountViewModel);
                navigationService.Register<UserMenuViewModel>(userMenuViewModel);
                navigationService.Register<UserBeerSetViewModel>(userBeerSetViewModel);

                navigationService.Navigate<StartPageViewModel>();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public ViewModelBase GetAppViewModel()
        {
            return appViewModel;
        }
    }
}
