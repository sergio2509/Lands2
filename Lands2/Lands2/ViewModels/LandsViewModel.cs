namespace Lands2.ViewModels
{
   using Models;
   using System;
   using System.Collections.ObjectModel;
   using Services;
   using Xamarin.Forms;
   using System.Collections.Generic;

   public class LandsViewModel : BaseViewModel
   {
      #region Services
      private ApiService apiService;
      #endregion

      #region Attributtes
      private ObservableCollection<Land> lands;
      #endregion

      #region Properties
      public ObservableCollection<Land> Lands
      {
         get
         {
            return this.lands;
         }
         set
         {
            SetValue(ref this.lands, value);
         }
      }

      #endregion

      #region Constructors
      public LandsViewModel()
      {
         this.apiService = new ApiService();
         this.LoadLands();
      }
      #endregion

      #region Methodes
      private async void LoadLands()
      {

         var connection = await this.apiService.CheckConnection();

         if (!connection.IsSuccess)
         {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                connection.Message,
                "Acept");
            await Application.Current.MainPage.Navigation.PopAsync();

            return;

         }

         var response = await this.apiService.GetList<Land>(
             "http://restcountries.eu",
             "/rest",
             "/v2/all");

         if (response.IsSuccess == false)
         {
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                response.Message,
                "Acept");
            await Application.Current.MainPage.Navigation.PopAsync();
            return;
         }

         var list = (List<Land>)response.Result;
         this.Lands = new ObservableCollection<Land>(list);

         await Application.Current.MainPage.DisplayAlert(
                 "Base de Datos Consultada",
                 response.Message,
                 "Acept");
         return;

      }


      #endregion

   }
}
