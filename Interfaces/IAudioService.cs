using System.Threading.Tasks;

namespace Chord_Generator.Services
{
    public interface IAudioService
    {
        Task PlayAudio();
        Task StopAudio();
    }
}