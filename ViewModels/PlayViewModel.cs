using Chord_Generator.Models;
using Chord_Generator.Services;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Chord_Generator.ViewModels
{
    public class PlayViewModel : BindableBase, INavigationAware
    {
        public string ActiveChord { get; set; }
        public string ActiveImageSource { get; set; }
        public string NextActiveChord { get; set; }

        public List<Chord> ChordList { get; set; }
        public ObservableCollection<ChordRunList> ChordRunLists { get; set; }
        public ChordRunList SelectedRunList { get; set; }

        public DelegateCommand StartCommand { get; set; }

        private IChordsService chordsService;
        private IAudioService audioService;
        private ISettings settings;

        public PlayViewModel(IChordsService chordsService, IAudioService audioService, ISettings settings)
        {
            this.chordsService = chordsService;
            this.audioService = audioService;
            this.settings = settings;

            StartCommand = new DelegateCommand(Start);
            ChordList = chordsService.CreateRandomisedChordList().Chords;
            UpdateChordRunList();

            ActiveChord = ChordList.FirstOrDefault().ChordName;
            ActiveImageSource = ChordList.FirstOrDefault().ImagePath;
            NextActiveChord = ChordList[1].ChordName;
        }

        private async void Start()
        {
            ChordList = chordsService.GetChords(SelectedRunList);
            await audioService.PlayAudio();

            foreach (var chord in ChordList)
            {
                ActiveChord = chord.ChordName;
                ActiveImageSource = chord.ImagePath;

                NextActiveChord = chordsService.GetNextActiveChordName(chord, ChordList);
                await Task.Delay(5500);
            }

            await audioService.StopAudio();
            ChordList = chordsService.CreateRandomisedChordList().Chords;
        }

        private void UpdateChordRunList()
        {
            ChordRunLists = new ObservableCollection<ChordRunList>(settings.GetRunList());
            ChordRunLists.Add(chordsService.CreateRandomisedChordList());
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            UpdateChordRunList();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }
    }
}
