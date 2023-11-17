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
                CurrentPlayer = P1;
            } else
            {
                CurrentPlayer = P2;
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

        public void saveDataToJson(int saveFileID)
        {

        }
    }
}
