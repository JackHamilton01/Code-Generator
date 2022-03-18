using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Generator.Services
{
    public class Settings
    {
        private const string imagesFolderName = "chordImages";

        private string defaultSavePath => Path.Combine(Directory.GetCurrentDirectory(), imagesFolderName);

    }
}
