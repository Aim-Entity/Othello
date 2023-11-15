using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace othello
{
    internal class Save
    {
        protected int[,] _boardArr;
        public int[,] BoardArr
        {
            get => _boardArr;
            set => _boardArr = value;
        }

        protected Player _currentPlayer;
        public Player CurrentPlayer
        {
            get => _currentPlayer;
            set => _currentPlayer = value;
        }

        protected Player _p1;
        public Player P1
        {
            get => _p1;
            set => _p1 = value;
        }

        protected Player _p2;
        public Player P2
        {
            get => _p2;
            set => _p2 = value;
        }

        protected string _saveFileName;
        public string SaveFileName
        {
            get => _saveFileName;
            set => _saveFileName = Directory.GetCurrentDirectory() + @"\assets\" + value;
        }

        public Save(string saveFileName)
        {
            _saveFileName = saveFileName;
        }

        public Tuple<int[,], Player, Player, Player> loadSaveFile()
        {
            return new Tuple<int[,], Player, Player, Player>(BoardArr, CurrentPlayer, P1, P2);
        }

        public Form2 loadJsonData(Form2 form)
        {
            string text = File.ReadAllText(SaveFileName);
            MessageBox.Show(text);

            return form;
        }
    }
}
