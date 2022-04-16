using Chord_Generator.Models;
using Chord_Generator.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Chord_Generator.ViewModels
{
    public class PlayViewModel : BindableBase
    {
        public string ActiveChord { get; set; }
        public string ActiveImageSource { get; set; }
        public string NextActiveChord { get; set; }

        public List<Chord> ChordList { get; set; }
        public ObservableCollection<ChordRunList> ChordRunLists { get; set; }
        public ChordRunList SelectedRunList { get; set; }

        public DelegateCommand StartCommand { get; set; }

        private ChordsService chordsService;
        private AudioService audioService;
        private Settings settings;

        public PlayViewModel()
        {
            chordsService = new ChordsService();
            audioService = new AudioService();
            settings = new Settings();

            StartCommand = new DelegateCommand(Start);
            ChordList = chordsService.CreateRandomisedChordList().Chords;
            ChordRunLists = new ObservableCollection<ChordRunList>(settings.GetRunList());
            ChordRunLists.Add(chordsService.CreateRandomisedChordList());

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
    }
}
