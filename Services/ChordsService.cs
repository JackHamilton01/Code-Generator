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
                new Chord(chordName: "Bm", imagePath: FileHelper.GetPath("Bm.jpg", imageFolder)),
                new Chord(chordName: "Bm", imagePath: FileHelper.GetPath("Bm.jpg", imageFolder)),
                new Chord(chordName: "Bm", imagePath: FileHelper.GetPath("Bm.jpg", imageFolder)),
                new Chord(chordName: "CMaj7", imagePath: FileHelper.GetPath("CMaj7.jpg", imageFolder)),
                new Chord(chordName: "C7", imagePath: FileHelper.GetPath("C7.jpg", imageFolder)),
                new Chord(chordName: "D7", imagePath: FileHelper.GetPath("D7.jpg", imageFolder)),
                new Chord(chordName: "Dmaj7", imagePath: FileHelper.GetPath("Dmaj7.jpg", imageFolder)),
                new Chord(chordName: "Dm7", imagePath: FileHelper.GetPath("Dm7.jpg", imageFolder)),
                new Chord(chordName: "E7", imagePath: FileHelper.GetPath("E7.jpg", imageFolder)),
                new Chord(chordName: "Emaj7", imagePath: FileHelper.GetPath("Emaj7.jpg", imageFolder)),
                new Chord(chordName: "Em7", imagePath: FileHelper.GetPath("Em7.jpg", imageFolder)),
                new Chord(chordName: "F7", imagePath: FileHelper.GetPath("F7.jpg", imageFolder)),
                new Chord(chordName: "G7", imagePath: FileHelper.GetPath("G7.jpg", imageFolder)),
                new Chord(chordName: "Gmaj7", imagePath: FileHelper.GetPath("Gmaj7.jpg", imageFolder)),
                new Chord(chordName: "Gm7", imagePath: FileHelper.GetPath("Gm7.jpg", imageFolder)),
                new Chord(chordName: "A7", imagePath: FileHelper.GetPath("A7.jpg", imageFolder)),
                new Chord(chordName: "Amaj7", imagePath: FileHelper.GetPath("Amaj7.jpg", imageFolder)),
                new Chord(chordName: "B7", imagePath: FileHelper.GetPath("B7.jpg", imageFolder)),
                new Chord(chordName: "Bm7", imagePath: FileHelper.GetPath("Bm7.jpg", imageFolder)),
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
