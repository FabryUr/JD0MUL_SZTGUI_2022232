using JD0MUL_HFT_2022231.Models;
using JD0MUL_HFT_2022231.Models.SideClasses;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JD0MUL_WPF_2022232.WpfClient.ViewModels
{
    internal class StatWindowViewModel : ObservableRecipient
    {
        RestService rest;
        public List<Best> BestTvShowRoles { get; set; }
        public List<Worst> WorstShowActors { get; set; }
        public List<ActorInfo> BestTvShowsByActor { get; set; }
        public ActorRateInfo AverageTvShowRatingsByActor { get; set; }
        public List<StudioInfo> LargestStudios { get; set; }

        public ICommand ShowAverageTvShowRatingByActorCommand { get; set; }
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }


        private int actorIdx;
        public int ActorIdx { 
            get
            { 
                return actorIdx;
            }
            set 
            {
                if (value != null && value>0)
                {
                    actorIdx = value;
                    OnPropertyChanged(nameof(ActorIdx));
                    (ShowAverageTvShowRatingByActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            } 
        }


        public StatWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                rest = new RestService("http://localhost:36235/");

                BestTvShowRoles = rest.Get<Best>("Stat/BestTvShowRoles"); OnPropertyChanged(nameof(BestTvShowRoles));

                WorstShowActors = rest.Get<Worst>("Stat/WorstShowActors"); OnPropertyChanged(nameof(WorstShowActors));

                BestTvShowsByActor = rest.Get<ActorInfo>("Stat/ActorBestTvShowRating"); OnPropertyChanged(nameof(BestTvShowsByActor));
                
                LargestStudios = rest.Get<StudioInfo>("Stat/LargestStudio"); OnPropertyChanged(nameof(LargestStudios));
                

                ShowAverageTvShowRatingByActorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        AverageTvShowRatingsByActor = rest.Get<ActorRateInfo>(actorIdx, "Stat/ActorShowsAverage"); OnPropertyChanged(nameof(AverageTvShowRatingsByActor));
                        ;
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }                    
                });
                ActorIdx = 1;
            }
            ;
        }
    }
    
}
