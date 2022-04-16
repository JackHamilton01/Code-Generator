using Chord_Generator.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Chord_Generator.Services
{
    public class Settings
    {
        private const string imagesFolderName = "chordImages";
        private const string settingsFolderName = @"Settings\";

        private string defaultImagesPath => Path.Combine(Directory.GetCurrentDirectory(), imagesFolderName);
        private string defaultSavePath => Path.Combine(Directory.GetCurrentDirectory(), settingsFolderName);


        public void SaveSettings<T>(T item, string fileName)
        {
            if (!Directory.Exists(defaultSavePath))
            {
                Directory.CreateDirectory(defaultSavePath);
            }

            using (var stream = new FileStream(defaultSavePath + fileName + ".xml", FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(T));
                XML.Serialize(stream, item);
            }
        }

        private ChordRunList DeserializeChordRunList(string savedSetting)
        {
            var loadedItems = new List<ObservableCollection<ChordRunList>>();

            if (Directory.Exists(defaultSavePath))
            {
                using (FileStream fs = new FileStream(savedSetting, FileMode.Open))
                {
                    try
                    {
                        XmlSerializer xml = new XmlSerializer(typeof(ChordRunList));
                        StreamReader reader = new StreamReader(fs);

                        return (ChordRunList)xml.Deserialize(reader);
                    }
                    catch (InvalidOperationException)
                    {
                        throw new InvalidOperationException($"Error deserialzing the following path {defaultSavePath}");
                    }
                }
            }
            else
            {
                return new ChordRunList();
            }
        }

        public ObservableCollection<ChordRunList> GetRunList()
        {
            var totalRunList = new ObservableCollection<ChordRunList>();

            string[] savedSettings = Directory.GetFiles(defaultSavePath);

            foreach (var savedSetting in savedSettings)
            {
                totalRunList.Add(DeserializeChordRunList(savedSetting));
            }

            //ChordRunList chordRunList = new ChordRunList(runList.Chords, runList.Title);

            //foreach (var item in runList)
            //{
            //    ChordRunList chordRunList = new ChordRunList(item.Chords);
            //    totalRunList.Add(chordRunList);
            //}

            return totalRunList;
        }
    }
}
