using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Generator.Models
{
    public class Chord
    {
        public string ChordName { get; set; }
        public string ImagePath { get; set; }

        public Chord(string chordName, string imagePath)
        {
            ChordName = chordName;
            ImagePath = imagePath;
        }

        // Parameterless constrcutor for serialisation
        public Chord()
        {
                
        }
    }
}
