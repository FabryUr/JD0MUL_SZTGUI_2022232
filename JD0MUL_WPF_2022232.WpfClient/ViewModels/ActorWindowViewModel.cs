using JD0MUL_HFT_2022231.Models;
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
    internal class ActorWindowViewModel : ObservableRecipient
    {
        public RestCollection<Actor> Actors { get; set; }
        public ICommand CreateActorCommand { get; set; }
        public ICommand DeleteActorCommand { get; set; }
        public ICommand UpdateActorCommand { get; set; }
        private Actor selectedActor;
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

        public Actor SelectedActor
        {
            get { return selectedActor; }
            set
            {
                if (value != null)
                {
                    selectedActor = new Actor()
                    {
                        ActorName = value.ActorName,
                        ActorId = value.ActorId,
                    };
                    OnPropertyChanged();
                    (DeleteActorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ActorWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Actors = new RestCollection<Actor>("http://localhost:36235/", "actor", "hub");
                CreateActorCommand = new RelayCommand(() =>
                {
                    Actors.Add(new Actor()
                    {
                        ActorName = SelectedActor.ActorName
                    });
                });

                UpdateActorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Actors.Update(SelectedActor);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteActorCommand = new RelayCommand(() =>
                {
                    Actors.Delete(SelectedActor.ActorId);
                },
                () =>
                {
                    return SelectedActor != null;
                });
                SelectedActor = new Actor();
            }
        }
    }
}
