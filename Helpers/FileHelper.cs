using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Generator.Helpers
{
    public static class FileHelper
    {

        public static string GetPath(string fileName, string folder)
        {
            return Path.Combine(Directory.GetCurrentDirectory() + folder, fileName);
        }
    }
}
