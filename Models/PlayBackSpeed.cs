using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Generator.Models
{
    public class PlayBackSpeed
    {
        public double VerySlow { get; } = 0.25;
        public double SemiSlow { get; } = 0.5;
        public double Slow { get; } = 0.75;
        //Easier for user to understand which is normal speed if it is labeled 'Normal'
        public string Normal { get; } = "Normal";
        public double SemiFast { get; } = 1.25;
        public double VeryFast { get; } = 1.5;
    }
}
