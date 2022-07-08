using Chord_Generator.Models;
using Chord_Generator.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Generator.Views
{
    class RunListSettingsViewModel : BindableBase
    {
        public ObservableCollection<Chord> Chords { get; set; }
        public ObservableCollection<Chord> NewChordsList { get; set; }
        public string RunListTitle { get; set; }

        public DelegateCommand<Chord> AddToRunListCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        private IChordsService chordsService;
        private ISettings settings;

        public RunListSettingsViewModel(IChordsService chordsService, ISettings settings)
        {
            this.chordsService = chordsService;
            this.settings = settings;

            AddToRunListCommand = new DelegateCommand<Chord>(AddToRunList);
            SaveCommand = new DelegateCommand(Save);

            Chords = new ObservableCollection<Chord>(chordsService.CreateChords());
            NewChordsList = new ObservableCollection<Chord>();
        }

        private void Save()
        {
            var newChordsList = new ChordRunList(NewChordsList.ToList(), RunListTitle);
            settings.SaveSettings(newChordsList, RunListTitle);
            NewChordsList.Clear();
        }

        private void AddToRunList(Chord chord)
        {
            NewChordsList.Add(chord);
        }
    }
}
