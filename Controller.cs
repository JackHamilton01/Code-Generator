using Chord_Generator.ViewModels;
using Chord_Generator.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;

namespace Chord_Generator
{
    public class Controller : IModule
    {
        private readonly IRegionManager _regionManager;
        private readonly IUnityContainer unityContainer;

        public Controller(IRegionManager regionManager, IUnityContainer unityContainer)
        {
            _regionManager = regionManager;
            this.unityContainer = unityContainer;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            //unityContainer.RegisterType<IXMLSerialization, XMLSerialization>();

            _regionManager.RegisterViewWithRegion(RegionNames.ContentRegion, typeof(PlayView));
            _regionManager.RegisterViewWithRegion(RegionNames.NavigationRegion, typeof(NavigationView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<PlayView, PlayViewModel>();
            containerRegistry.RegisterForNavigation<NavigationView, NavigationViewModel>();
            containerRegistry.RegisterForNavigation<RunListSettingsView, RunListSettingsViewModel>();
        }
    }
}
