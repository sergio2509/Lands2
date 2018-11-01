

namespace Lands2.ViewModels
{
   using GalaSoft.MvvmLight.Command;
   using System;
   using System.ComponentModel;
   using System.Windows.Input;
   using Xamarin.Forms;

   public class LoginViewModel : INotifyPropertyChanged
   {

      #region Events
      public event PropertyChangedEventHandler PropertyChanged;

      #endregion

      #region Attributes
      private string login;
      private string password;
      private bool isRunning;
      
      private bool isEnabled;

      #endregion



      #region Properties

      public string Email
      {
         get;
         set;
      }

      public string Password
      {
         get
         {
            return this.password;
         }
         set
         {
            if (this.password != value)
            {
               this.password = value;
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.Password)));
            }
         }

      }

      public bool IsRunning
      {
         get
         {
            return this.isRunning;
         }
         set
         {
            if (this.isRunning != value)
            {
               this.isRunning = value;
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsRunning)));
            }
         }
      }

      public bool IsRemember
      {
         get;
         set;
      }

      public bool IsEnabled
      {
         get
         {
            return this.isEnabled;
         }
         set
         {
            if (this.isEnabled != value)
            {
               this.isEnabled = value;
               PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(this.IsEnabled)));
            }
         }
      }

      #endregion

      #region Constructors

      public LoginViewModel()
      {
         this.IsRemember = true;
         this.IsEnabled = true;
      }


      #endregion

      #region Commands

      public ICommand LoginCommand
      {
         get
         {
            return new RelayCommand(Login);
         }

      }



      private async void Login()
      {
         if (string.IsNullOrEmpty(this.Email))
         {
            await Application.Current.MainPage.DisplayAlert(
               "Error",
               "You must enter an email.",
               "Accept");
            return;
         }

         if (string.IsNullOrEmpty(this.Password))
         {
            await Application.Current.MainPage.DisplayAlert(
               "Error",
               "You must enter a password.",
               "Accept");
            return;
         }

         this.IsRunning = true;
         this.isEnabled = false;

         if (this.Email != "sergio2509@gmail.com" || this.Password != "1234")
         {
            this.IsRunning = false;
            this.isEnabled = true;
            await Application.Current.MainPage.DisplayAlert(
               "Error",
               "Email or password incorrect.",
               "Accept");
            this.Password = string.Empty;
            return;
         }

         this.IsRunning = false;
         this.isEnabled = true;

         await Application.Current.MainPage.DisplayAlert(
               "Ok",
               "Entraste!!!!",
               "Accept");

      }



      #endregion

   }
}
