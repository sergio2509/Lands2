

namespace Lands2.ViewModels
{

   using System.Windows.Input;

   public class LoginViewModel
    {
      #region Properties

      public string Email
      {
         get;
         set;
      }

      public string Password
      {
         get;
         set;
      }

      public bool IsRunning
      {
         get;
         set;
      }

      public bool IsRemember
      {
         get;
         set;
      }

      #endregion

      #region Constructors

      public LoginViewModel()
      {
         this.IsRemember = true;

      }


      #endregion

      #region Commands

      public ICommand LoginComand
      {
         get;
         set;
      }

      #endregion

   }
}
