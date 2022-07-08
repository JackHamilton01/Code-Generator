using Chord_Generator.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Chord_Generator.Services
{
    public class AudioService : IAudioService
    {
        private string audioFolder = @"\Audio\";
        private string trainingBeatFileName = "TrainingBeatShort.WAV";

        SoundPlayer soundPlayer;

        public AudioService()
        {
            soundPlayer = new SoundPlayer(FileHelper.GetPath(trainingBeatFileName, audioFolder));
        }

        public async Task PlayAudio()
        {
            await Task.Run(() => soundPlayer.PlayLooping());
        }

        public async Task StopAudio()
        {
            await Task.Run(() => soundPlayer.Stop());
        }
    }
}
