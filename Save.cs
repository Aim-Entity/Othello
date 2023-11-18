using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace othello
{
    internal class SaveState
    {
        public string FileName {  get; set; }
        public int[,] BoardArr { get; set; }

        public int CurrentPlayerID { get; set; }

        public Player CurrentPlayer { get; set; }

        public Player P1 { get; set; }

        public Player P2 { get; set; }

        public SaveState()
        {
            if(CurrentPlayerID == 0)
            {
                CurrentPlayer = P2;
            } else
            {
                CurrentPlayer = P1;
            }
        }
    }
    internal class Save
    {
        

        protected string _jsonDir;
        public string JsonDir
        {
            get => _jsonDir;
            set => _jsonDir = Directory.GetCurrentDirectory() + @"\assets\" + value;
        }

        public Save(string jsonDir)
        {
            JsonDir = jsonDir;
        }

        public SaveState[] loadJsonData()
        {
            string jsonText = File.ReadAllText(JsonDir);
            SaveState[] jsonData = JsonConvert.DeserializeObject<SaveState[]>(jsonText);

            return jsonData;
        }

        public void saveDataToJson(int saveFileID, SaveState newFileSave)
        {
            string jsonText = File.ReadAllText(JsonDir);
            SaveState[] jsonData = JsonConvert.DeserializeObject<SaveState[]>(jsonText);

            jsonData[saveFileID] = newFileSave;
            string output = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
            File.WriteAllText(JsonDir, output);
        }

        public string[] getFileNames()
        {
            string jsonText = File.ReadAllText(JsonDir);
            SaveState[] jsonData = JsonConvert.DeserializeObject<SaveState[]>(jsonText);

            string[] names = { 
                jsonData[0].FileName, 
                jsonData[1].FileName, 
                jsonData[2].FileName, 
                jsonData[3].FileName,
                jsonData[4].FileName
            };

            return names;
        }
    }
}
