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
    internal class StudioWindowViewModel : ObservableRecipient
    {
        public RestCollection<Studio> Studios { get; set; }
        public ICommand CreateStudioCommand { get; set; }
        public ICommand DeleteStudioCommand { get; set; }
        public ICommand UpdateStudioCommand { get; set; }
        private Studio selectedStudio;
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

        public Studio SelectedStudio
        {
            get { return selectedStudio; }
            set
            {
                if (value != null)
                {
                    selectedStudio = new Studio()
                    {
                        StudioName = value.StudioName,
                        StudioId = value.StudioId,
                    };
                    OnPropertyChanged();
                    (DeleteStudioCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public StudioWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Studios = new RestCollection<Studio>("http://localhost:36235/", "studio", "hub");
                CreateStudioCommand = new RelayCommand(() =>
                {
                    Studios.Add(new Studio()
                    {
                        StudioName = SelectedStudio.StudioName
                    });
                });

                UpdateStudioCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Studios.Update(SelectedStudio);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteStudioCommand = new RelayCommand(() =>
                {
                    Studios.Delete(SelectedStudio.StudioId);
                },
                () =>
                {
                    return SelectedStudio != null;
                });
                SelectedStudio = new Studio();
            }
        }
    }
}
