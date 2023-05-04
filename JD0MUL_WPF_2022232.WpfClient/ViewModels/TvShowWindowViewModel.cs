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
    internal class TvShowWindowViewModel : ObservableRecipient
    {
        public RestCollection<TvShow> TvShows { get; set; }
        public ICommand CreateTvShowCommand { get; set; }
        public ICommand DeleteTvShowCommand { get; set; }
        public ICommand UpdateTvShowCommand { get; set; }
        private TvShow selectedTvShow;
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

        public TvShow SelectedTvShow
        {
            get { return selectedTvShow; }
            set
            {
                if (value != null)
                {
                    selectedTvShow = new TvShow()
                    {
                        Title = value.Title,
                        TvShowId = value.TvShowId,
                    };
                    OnPropertyChanged();
                    (DeleteTvShowCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public TvShowWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                TvShows = new RestCollection<TvShow>("http://localhost:36235/", "tvshow", "hub");
                CreateTvShowCommand = new RelayCommand(() =>
                {
                    TvShows.Add(new TvShow()
                    {
                        Title = SelectedTvShow.Title
                    });
                });

                UpdateTvShowCommand = new RelayCommand(() =>
                {
                    try
                    {
                        TvShows.Update(selectedTvShow);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteTvShowCommand = new RelayCommand(() =>
                {
                    TvShows.Delete(selectedTvShow.TvShowId);
                },
                () =>
                {
                    return selectedTvShow != null;
                });
                selectedTvShow = new TvShow();
            }
        }
    }
}
