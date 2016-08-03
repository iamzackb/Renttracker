using Template10.Mvvm;
using System.Collections.Generic;
using System.Threading.Tasks;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;
using MyToolkit.Collections;
using Renttracker.Models;
using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Renttracker.UWP.ViewModels
{
    /// <summary>
    /// View model for the MainPage.
    /// </summary>
    public class MainPageViewModel : ViewModelBase
    {
        MtObservableCollection<Home> _homes { get; set; }
        public ObservableCollectionView<Home> Homes { get; set; }

        int _minPrice = 0;
        public int MinPrice { get { return _minPrice; } set { Set(ref _minPrice, value); FilterHomes(); } }

        int _maxPrice = 10000;
        public int MaxPrice { get { return _maxPrice; } set { Set(ref _maxPrice, value); FilterHomes(); } }

        int _minBeds = 1;
        public int MinBeds { get { return _minBeds; } set { Set(ref _minBeds, value); FilterHomes(); } }

        int _maxBeds = 5;
        public int MaxBeds { get { return _maxBeds; } set { Set(ref _maxBeds, value); FilterHomes(); } }

        Func<Home, bool> PriceFilter;
        Func<Home, bool> BedsFilter;

        List<Func<Home, bool>> Filters = new List<Func<Home, bool>>();

        public MainPageViewModel()
        {
            _homes = new MtObservableCollection<Home>();
            Homes = new ObservableCollectionView<Home>(_homes);
            PriceFilter = a => a.Price <= MaxPrice && a.Price >= MinPrice;
            BedsFilter = a => a.Beds <= MaxBeds && a.Beds >= MinBeds;
        }
        
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            _homes.AddRange(await Controllers.ProtoController.GetHomesFromSampleJsonAsync());
            await Task.CompletedTask;
        }

        public override async Task OnNavigatedFromAsync(IDictionary<string, object> suspensionState, bool suspending)
        {
            await Task.CompletedTask;
        }

        public override async Task OnNavigatingFromAsync(NavigatingEventArgs args)
        {
            args.Cancel = false;
            await Task.CompletedTask;
        }

        public void PriceToggleSwitchToggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = sender as ToggleSwitch;

            if (toggleSwitch.IsOn)
                AddPriceFilter();
            else
                RemovePriceFilter();

            FilterHomes();
        }

        public void BedsToggleSwitchToggled(object sender, RoutedEventArgs e)
        {
            var toggleSwitch = sender as ToggleSwitch;

            if (toggleSwitch.IsOn)
                AddBedsFilter();
            else
                RemoveBedsFilter();

            FilterHomes();
        }

        void FilterHomes()
        {
            Homes.Filter = a =>
            {
                var matches = true;
                Filters.ForEach(b =>
                {
                    if (!b.Invoke(a).Equals(true))
                        matches = false;
                });
                return matches;
            };
        }

        void AddPriceFilter() =>
            Filters.Add(PriceFilter);

        void RemovePriceFilter() =>
            Filters.Remove(PriceFilter);

        void AddBedsFilter() =>
            Filters.Add(BedsFilter);

        void RemoveBedsFilter() =>
            Filters.Remove(BedsFilter);
    }
}

