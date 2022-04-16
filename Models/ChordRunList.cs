using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chord_Generator.Models
{
    public class ChordRunList
    {
        public string Title { get; set; }
        public List<Chord> Chords { get; set; }

        public ChordRunList(List<Chord> chords, string title)
        {
            Chords = chords;
            Title = title;
        }

        // Parameterless constructor for serialization
        public ChordRunList()
        {

        }
    }
}
