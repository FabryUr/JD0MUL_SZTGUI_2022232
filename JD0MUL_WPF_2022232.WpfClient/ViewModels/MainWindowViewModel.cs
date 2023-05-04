using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using JD0MUL_WPF_2022232.WpfClient.Windows;

namespace JD0MUL_WPF_2022232.WpfClient.ViewModels
{
    internal class MainWindowViewModel
    {
        public ICommand OpenActorCommand { get; set; }
        public ICommand OpenTvShowCommand { get; set; }
        public ICommand OpenRoleCommand { get; set; }
        public ICommand OpenStudioCommand { get; set; }
        public ICommand OpenStatisticsCommand { get; set; }

        public MainWindowViewModel()
        {
            OpenActorCommand = new RelayCommand(() =>
            {
                ActorWindow actorWindow = new ActorWindow();
                actorWindow.Show();
            });
            OpenRoleCommand = new RelayCommand(() =>
            {
                RoleWindow roleWindow = new RoleWindow();
                roleWindow.Show();
            });
            OpenStatisticsCommand = new RelayCommand(() =>
            {
                StatisticsWindow statWindow = new StatisticsWindow();
                statWindow.Show();
            });
            OpenStudioCommand = new RelayCommand(() =>
            {
                StudioWindow studioWindow = new StudioWindow();
                studioWindow.Show();
            });
            OpenTvShowCommand = new RelayCommand(() =>
            {
                TvShowWindow tvShowWindow = new TvShowWindow();
                tvShowWindow.Show();
            });
        }
    }
}
