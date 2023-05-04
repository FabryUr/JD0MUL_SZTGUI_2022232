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
    internal class RoleWindowViewModel : ObservableRecipient
    {
        public RestCollection<Role> Roles { get; set; }
        public ICommand CreateRoleCommand { get; set; }
        public ICommand DeleteRoleCommand { get; set; }
        public ICommand UpdateRoleCommand { get; set; }
        private Role selectedRole;
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

        public Role SelectedRole
        {
            get { return selectedRole; }
            set
            {
                if (value != null)
                {
                    selectedRole = new Role()
                    {
                        RoleName = value.RoleName,
                        RoleId = value.RoleId,
                    };
                    OnPropertyChanged();
                    (DeleteRoleCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public RoleWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                Roles = new RestCollection<Role>("http://localhost:36235/", "role", "hub");
                CreateRoleCommand = new RelayCommand(() =>
                {
                    Roles.Add(new Role()
                    {
                        RoleName = SelectedRole.RoleName
                    });
                });

                UpdateRoleCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Roles.Update(SelectedRole);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }

                });

                DeleteRoleCommand = new RelayCommand(() =>
                {
                    Roles.Delete(SelectedRole.RoleId);
                },
                () =>
                {
                    return SelectedRole != null;
                });
                SelectedRole = new Role();
            }
        }
    }
}
