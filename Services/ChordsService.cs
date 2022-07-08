using Chord_Generator.Helpers;
using Chord_Generator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Generator.Services
{
    public class ChordsService : IChordsService
    {
        private string imageFolder = @"\Images\";

        public List<Chord> CreateChords()
        {
            return new List<Chord>()
            {
                new Chord(chordName: "C", imagePath: FileHelper.GetPath("C.jpg", imageFolder)),
                new Chord(chordName: "Cm", imagePath: FileHelper.GetPath("Cm.jpg", imageFolder)),
                new Chord(chordName: "D", imagePath: FileHelper.GetPath("D.jpg", imageFolder)),
                new Chord(chordName: "Dm", imagePath: FileHelper.GetPath("Dm.jpg", imageFolder)),
                new Chord(chordName: "E", imagePath: FileHelper.GetPath("E.jpg", imageFolder)),
                new Chord(chordName: "Em", imagePath: FileHelper.GetPath("Em.jpg", imageFolder)),
                new Chord(chordName: "F", imagePath: FileHelper.GetPath("F.jpg", imageFolder)),
                new Chord(chordName: "Fm", imagePath: FileHelper.GetPath("Fm.jpg", imageFolder)),
                new Chord(chordName: "F#m", imagePath: FileHelper.GetPath("F#m.jpg", imageFolder)),
                new Chord(chordName: "G", imagePath: FileHelper.GetPath("G.jpg", imageFolder)),
                new Chord(chordName: "Gm", imagePath: FileHelper.GetPath("Gm.jpg", imageFolder)),
                new Chord(chordName: "A", imagePath: FileHelper.GetPath("A.jpg", imageFolder)),
                new Chord(chordName: "Am", imagePath: FileHelper.GetPath("Am.jpg", imageFolder)),
                new Chord(chordName: "B", imagePath: FileHelper.GetPath("B.jpg", imageFolder)),
                new Chord(chordName: "Bm", imagePath: FileHelper.GetPath("Bm.jpg", imageFolder)),
            };
        }

        public ChordRunList CreateRandomisedChordList()
        {
            var random = new Random();
            var randomizedChords = CreateChords().OrderBy(item => random.Next()).ToList();
            return new ChordRunList(randomizedChords, "Random");
        }

        public string GetImageSource(string imageName)
        {
            return Path.Combine(Directory.GetCurrentDirectory() + imageFolder, imageName);
        }

        public string GetNextActiveChordName(Chord chord, List<Chord> chordList)
        {
            int nextActiveChordIndex = chordList.IndexOf(chord);
            return chord == chordList.Last() ? string.Empty : chordList[nextActiveChordIndex + 1].ChordName;
        }

        public List<Chord> GetChords(ChordRunList chordRunList)
        {
            return chordRunList is null ? CreateRandomisedChordList().Chords : chordRunList.Chords.ToList();
        }
    }
}
