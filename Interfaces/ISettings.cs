using Chord_Generator.Models;
using System.Collections.ObjectModel;

namespace Chord_Generator.Services
{
    public interface ISettings
    {
        ObservableCollection<ChordRunList> GetRunList();
        void SaveSettings<T>(T item, string fileName);
    }
}