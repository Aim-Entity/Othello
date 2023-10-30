using GameboardGUI;

namespace othello
{
    public partial class Form1 : Form
    {
        const int NUM_OF_BOARD_ROWS = 8;
        const int NUM_OF_BOARD_COL = 8;

        GameboardImageArray _gameBoardGui;
        int[,] gameBoardData;
        string tileImageDirPath = Directory.GetCurrentDirectory() + @"\assets\";
        GameEngine gameEngine = new GameEngine();

        public Form1()
        {
            InitializeComponent();

            Point top = new Point(10, 10);
            Point bottom = new Point(10, 10);

            gameBoardData = this.MakeBoardArray();

            try
            {
                _gameBoardGui = new GameboardImageArray(this, gameBoardData, top, bottom, 0, tileImageDirPath);
                _gameBoardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                _gameBoardGui.UpdateBoardGui(gameBoardData);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.ToString(), "Game board has size problem", MessageBoxButtons.OK);
                this.Close();
            }

            gameEngine.BoardArray = gameBoardData;
            gameEngine.P1 = new Player("Player 1", 0, 0);
            gameEngine.P2 = new Player("Player 2", 0, 0);
            gameEngine.CurrentPlayer = gameEngine.P1;
            gameEngine.GameOver = false;

            IllegalMove i1 = new IllegalMove(gameEngine.BoardArray, gameEngine.CurrentPlayer, 6, 6);
            int[,] arr = i1.adjacencyCheck(8, 8);
            for(int i = 0; i < arr.Length; i++)
            {
                //MessageBox.Show($"{arr[i, 0]} | {arr[i, 1]} | {gameBoardData[arr[i, 0], arr[i, 1]]}");
            }
        }

        private int[,] MakeBoardArray()
        {
            int[,] boardArray = new int[NUM_OF_BOARD_COL, NUM_OF_BOARD_ROWS];
            int boardVal = 0;

            for (int row = 0; row < NUM_OF_BOARD_ROWS; row++)
            {
                for (int col = 0; col < NUM_OF_BOARD_COL; col++)
                {
                    boardArray[row, col] = 10;
                }
            }

            boardArray[3, 3] = 1;
            boardArray[4, 3] = 0;
            boardArray[3, 4] = 0;
            boardArray[4, 4] = 1;

            return boardArray;
        }

        private void GameTileClicked(object sender, EventArgs e)
        {
            int selectionRow = _gameBoardGui.GetCurrentRowIndex(sender);
            int selectionCol = _gameBoardGui.GetCurrentColumnIndex(sender);

            MessageBox.Show($"You just clicked the square at row {selectionRow + 1} and col {selectionCol + 1}");
        }
    }
}