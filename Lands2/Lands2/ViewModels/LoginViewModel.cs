

namespace Lands2.ViewModels
{
   using GalaSoft.MvvmLight.Command;
   using Lands.ViewModels;
   using System.Windows.Input;
   using Xamarin.Forms;

   public class LoginViewModel : BaseViewModel
   {

      #region Attributes
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
         get { return this.password; }
         set { SetValue(ref this.password, value); }
      }

      public bool IsRunning
      {
         get { return this.isRunning; }
         set { SetValue(ref this.isRunning, value); }
      }

      public bool IsRemember
      {
         get;
         set;
      }

      public bool IsEnabled
      {
         get { return this.isEnabled; }
         set { SetValue(ref this.isEnabled, value); }
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
            this.Password = string.Empty;
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
