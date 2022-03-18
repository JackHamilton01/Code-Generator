using Chord_Generator.Models;
using Chord_Generator.Services;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace Chord_Generator.ViewModels
{
    public class PlayViewModel : BindableBase
    {
        public string ActiveChord { get; set; }
        public string ActiveImageSource { get; set; }

        public List<Chord> ChordList { get; set; }

        public DelegateCommand StartCommand { get; set; }

        private Chords chords;
        private AudioService audioService;

        public PlayViewModel()
        {
            chords = new Chords();
            audioService = new AudioService();

            StartCommand = new DelegateCommand(Start);
            ChordList = chords.CreateRandomiseChordList();

            ActiveChord = ChordList.FirstOrDefault().ChordName;
            ActiveImageSource = ChordList.FirstOrDefault().ImagePath;
        }

        private async void Start()
        {
            await audioService.PlayAudio();

            foreach (var chord in ChordList)
            {
                ActiveChord = chord.ChordName;
                ActiveImageSource = chord.ImagePath;
                await Task.Delay(5500);
            }
        }
    }
}
