using Chord_Generator.Models;
using System.Collections.Generic;

namespace Chord_Generator.Services
{
    public interface IChordsService
    {
        List<Chord> CreateChords();
        ChordRunList CreateRandomisedChordList();
        List<Chord> GetChords(ChordRunList chordRunList);
        string GetImageSource(string imageName);
        string GetNextActiveChordName(Chord chord, List<Chord> chordList);
    }
}