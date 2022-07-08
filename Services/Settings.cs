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
    public class Settings : ISettings
    {
        private const string settingsFolderName = @"Settings\";
        private string defaultSavePath => Path.Combine(Directory.GetCurrentDirectory(), settingsFolderName);

        public Settings()
        {
            SettingsExist();
        }

        public void SaveSettings<T>(T item, string fileName)
        {
            using (var stream = new FileStream(defaultSavePath + fileName + ".xml", FileMode.Create))
            {
                XmlSerializer XML = new XmlSerializer(typeof(T));
                XML.Serialize(stream, item);
            }
        }

        private ChordRunList DeserializeChordRunList(string savedSetting)
        {
            using (FileStream fs = new FileStream(savedSetting, FileMode.Open))
            {
                try
                {
                    XmlSerializer xml = new XmlSerializer(typeof(ChordRunList));
                    StreamReader reader = new StreamReader(fs);
                    return (ChordRunList)xml.Deserialize(reader);
                }
                catch (Exception)
                {
                    throw new InvalidOperationException($"Error deserialzing the following path {defaultSavePath}");
                }
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

            return totalRunList;
        }

        private void SettingsExist()
        {
            if (!Directory.Exists(defaultSavePath))
            {
                Directory.CreateDirectory(defaultSavePath);
            }
        }
    }
}
