using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace othello
{
    public partial class Form2 : Form
    {
        public int selectedIndex;

        private string _requestType;
        public string RequestType // "POST" = save | "GET" = load
        {
            get => _requestType; set => _requestType = value;
        }

        public int[,] BoardArr;
        public int CurrentPlayer;
        public string P1Name;
        public int P1Token;
        public string P2Name;
        public int P2Token;

        public Form2(string requestType)
        {
            InitializeComponent();
            RequestType = requestType;
        }

        

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (RequestType == "POST")
            {

            }
            else if (RequestType == "GET")
            {
                if (selectedIndex != 0)
                {
                    this.Close(); // If the button is clicked & selected index != 0, the public attribute can be accessed later
                }
            }
        }
    }
}
