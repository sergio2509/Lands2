namespace Lands2.ViewModels
{
   using Models;
   using System;
   using System.Collections.ObjectModel;
   using Services;
   using Xamarin.Forms;
   using System.Collections.Generic;
   using System.Windows.Input;
   using GalaSoft.MvvmLight.Command;
   using System.Linq;

   public class LandsViewModel : BaseViewModel
   {
      #region Services
      private ApiService apiService;
      #endregion

      #region Attributtes
      private ObservableCollection<Land> lands;
      private bool isRefreshing;
      private string filter;
      private List<Land> landsList;
      #endregion

      #region Properties
      public ObservableCollection<Land> Lands      
      {         
         get  { return this.lands; }
         set  { SetValue(ref this.lands, value); }
      }

      public bool IsRefreshing
      {
         get  { return this.isRefreshing;}
         set  { SetValue(ref this.isRefreshing, value); }
      }

      public string Filter
      {
         get  {            return this.filter;         }
         set  
         {            
            SetValue(ref this.filter, value);         
            this.Search();
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
         this.IsRefreshing = true;

         var connection = await this.apiService.CheckConnection();

         if (!connection.IsSuccess)
         {
            this.IsRefreshing = false;
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                connection.Message,
                "Accept");
            await Application.Current.MainPage.Navigation.PopAsync();

            return;

         }

         var response = await this.apiService.GetList<Land>(
             "http://restcountries.eu",
             "/rest",
             "/v2/all");

         if (response.IsSuccess == false)
         {
            this.IsRefreshing = false;
            await Application.Current.MainPage.DisplayAlert(
                "Error",
                response.Message,
                "Accept");
            await Application.Current.MainPage.Navigation.PopAsync(); //se devuelve
            return;
         }

         this.landsList = (List<Land>)response.Result;
         this.Lands = new ObservableCollection<Land>(this.landsList);
         this.IsRefreshing = false;

         

      }

      private void FilterLands()
      {
         if (string.IsNullOrEmpty(this.Filter))
         {
            this.Lands = new ObservableCollection<Land>(
               this.landsList);
         }
         else
         {
            this.Lands = new ObservableCollection<Land>(
               this.landsList.Where(
                  l => l.Name.ToLower().Contains(this.Filter.ToLower()) ||
                       l.Capital.ToLower().Contains(this.Filter.ToLower())
               )
            );
         }
      }

      #endregion

      #region Commands

      public ICommand RefreshCommand
      {
         get
         {
            return new RelayCommand(Refresh);
         }
      }
      private void Refresh()
      {
         LoadLands();
      }

      public ICommand SearchCommand
      {
         get
         {
            return new RelayCommand(Search);
         }
      }
      private void Search()
      {
         FilterLands();
      }

      #endregion

   }
}
