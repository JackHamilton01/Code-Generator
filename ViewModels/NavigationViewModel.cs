using Chord_Generator.Enums;
using Chord_Generator.Views;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Generator.ViewModels
{
    class NavigationViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public DelegateCommand<string> NavigateCommand { get; set; }

        public NavigationViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;
            NavigateCommand = new DelegateCommand<string>(Navigate);
        }

        private void Navigate(string navigationDestination)
        {
            if (navigationDestination == NavigationItem.Home.ToString())
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(PlayView));
            }
            else if (navigationDestination == NavigationItem.RunListSettings.ToString())
            {
                _regionManager.RequestNavigate(RegionNames.ContentRegion, nameof(RunListSettingsView));
            }
        }
    }
}
