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
            boardArray[3, 4] = 0;
            boardArray[4, 4] = 1;
            boardArray[4, 3] = 0;
            //boardArray[2, 4] = 0;


            return boardArray;
        }

        private Player getOppositePlayer(Player player)
        {
            if (player == gameEngine.P1)
            {
                return gameEngine.P2;
            }
            else
            {
                return gameEngine.P1;
            }
        }

        private bool checkIfSelectedIsPiece(int row, int col)
        {
            if (gameBoardData[row, col] != 10)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void updateCurrentPlayerGUI()
        {
            if(gameEngine.CurrentPlayer == gameEngine.P1)
            {
                label1.ForeColor = Color.Crimson;
                label2.ForeColor = Color.Black;
            } else
            {
                label2.ForeColor = Color.Crimson;
                label1.ForeColor = Color.Black;
            }
        }

        private void GameTileClicked(object sender, EventArgs e)
        {
            int selectionRow = _gameBoardGui.GetCurrentRowIndex(sender);
            int selectionCol = _gameBoardGui.GetCurrentColumnIndex(sender);

            Player oppositePlayer = getOppositePlayer(gameEngine.CurrentPlayer);

            IllegalMove illegalMove = new IllegalMove(gameEngine.BoardArray, gameEngine.CurrentPlayer, selectionCol + 1, selectionRow + 1);
            ValidMove validMoveForCurrentPlayer = new ValidMove(gameEngine.BoardArray, gameEngine.CurrentPlayer, -1, -1); // Valid move does not need x and y
            ValidMove validMoveForOppositePlayer = new ValidMove(gameEngine.BoardArray, oppositePlayer, -1, -1);


            //MessageBox.Show($"{validMoveForCurrentPlayer.checkForAnyValidMoves(NUM_OF_BOARD_ROWS, NUM_OF_BOARD_COL)}");
            //MessageBox.Show($"{validMoveForOppositePlayer.checkForAnyValidMoves(NUM_OF_BOARD_ROWS, NUM_OF_BOARD_COL)}");

            if (checkIfSelectedIsPiece(selectionRow, selectionCol) == false)
            {
                MessageBox.Show("You cannot select your own piece");
            }
            else if (validMoveForCurrentPlayer.checkForAnyValidMoves(NUM_OF_BOARD_ROWS, NUM_OF_BOARD_COL) == false && validMoveForOppositePlayer.checkForAnyValidMoves(NUM_OF_BOARD_ROWS, NUM_OF_BOARD_COL) == false)
            {
                MessageBox.Show("Neither player has a legal move. Game end");
            }
            else if (validMoveForCurrentPlayer.checkForAnyValidMoves(NUM_OF_BOARD_ROWS, NUM_OF_BOARD_COL) == false)
            {
                MessageBox.Show($"{gameEngine.CurrentPlayer.Name} does not have a legal move");
                gameEngine.UpdateCurrentPlayer();
                _gameBoardGui.UpdateBoardGui(gameBoardData);
            }
            else if (illegalMove.checkAllSides() == false)
            {
                if (validMoveForCurrentPlayer.checkForAnyValidMoves(NUM_OF_BOARD_ROWS, NUM_OF_BOARD_COL))
                {
                    SimulateMove s1 = new SimulateMove(gameEngine.BoardArray, gameEngine.CurrentPlayer, selectionCol + 1, selectionRow + 1);
                    s1.updateBoard(selectionCol, selectionRow);
                    gameBoardData[selectionRow, selectionCol] = gameEngine.CurrentPlayer.ID;
                    gameBoardData = s1.BoardArr;

                    s1.updateBoard(selectionCol, selectionRow);
                    gameBoardData = s1.BoardArr;

                    _gameBoardGui.UpdateBoardGui(gameBoardData);

                    gameEngine.UpdateCurrentPlayer();
                    updateCurrentPlayerGUI();
                }
            }
            else
            {
                //MessageBox.Show($"You just clicked the square at row {selectionRow + 1} and col {selectionCol + 1}");
                MessageBox.Show($"This is not a legal move");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Please enter player names");
            } else
            {
                button1.Hide();
                textBox1.Enabled = false;
                textBox2.Enabled = false;
                updateCurrentPlayerGUI();

                Point top = new Point(100, 50);
                Point bottom = new Point(100, 200);

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
                gameEngine.P1 = new Player(textBox1.Text, 2, 0);
                gameEngine.P2 = new Player(textBox2.Text, 2, 1);
                gameEngine.CurrentPlayer = gameEngine.P1;
                gameEngine.GameOver = false;
            }
        }
    }
}