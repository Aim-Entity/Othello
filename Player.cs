using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
    internal class Player
    {
        protected string _name;
        protected int _tokenCount;
        protected int _id;

        public string Name
        {
            get => _name;
        }

        public int TokenCount
        {
            get => _tokenCount;
        }

        public int ID
        {
            get => _id;
        }

        public Player(string name, int tokenCount, int id)
        {
            this._name = name;
            this._tokenCount = tokenCount;
            this._id = id;
        }
    }
}
