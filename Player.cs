using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace othello
{
    internal class Player
    {
        protected string __name;
        protected int __tokenCount;
        protected int __id;

        public string Name
        {
            get => __name;
        }

        public int TokenCount
        {
            get => __tokenCount;
        }

        public int ID
        {
            get => __id;
        }

        public Player(string name, int tokenCount, int id)
        {
            this.__name = name;
            this.__tokenCount = tokenCount;
            this.__id = id;
        }
    }
}
