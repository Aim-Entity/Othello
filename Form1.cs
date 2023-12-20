using GameboardGUI;
using System;
using System.Speech.Synthesis;
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
        Save JsonData = new Save("game_data.json");
        SpeechSynthesizer synth = new SpeechSynthesizer();

        string selectedFileName;

        // These are global variables for the saving / loading

        int SelectedFileIndex = -1; // initalise at -1 to signify nothing is selected
        string RequestType; // "POST" = Save | "GET" = Load | "POST, RELOAD" = Save & Reload

        public Form1()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            this.StartPosition = FormStartPosition.CenterScreen;
            synth.SetOutputToDefaultAudioDevice();
        }

        private void generateNewBoard()
        {
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
        }

        private void outputSpeech(string speech)
        {
            if (speakToolStripMenuItem.Checked)
            {
                synth.Speak(speech);
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
            boardArray[3, 4] = 0;
            boardArray[4, 4] = 1;
            boardArray[4, 3] = 0;

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
            if (gameEngine.CurrentPlayer == gameEngine.P1)
            {
                label3.Visible = false;
                label4.Visible = true;
            }
            else
            {
                label3.Visible = true;
                label4.Visible = false;
            }
        }

        private void updateBoardData(int selectionRow, int selectionCol)
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

            gameEngine.P1.TokenCount = countTokensForPlayer(gameEngine.P1);
            gameEngine.P2.TokenCount = countTokensForPlayer(gameEngine.P2);

            label2.Text = $"{gameEngine.P1.TokenCount}";
            label1.Text = $"{gameEngine.P2.TokenCount}";
        }

        private bool checkForValidMoves(ValidMove v1)
        {
            return v1.checkForAnyValidMoves(NUM_OF_BOARD_ROWS, NUM_OF_BOARD_COL);
        }

        private void playUserMove(int selectionRow, int selectionCol)
        {
            Player oppositePlayer = getOppositePlayer(gameEngine.CurrentPlayer);
            IllegalMove illegalMove = new IllegalMove(gameEngine.BoardArray, gameEngine.CurrentPlayer, selectionCol + 1, selectionRow + 1);
            ValidMove validMoveForCurrentPlayer = new ValidMove(gameEngine.BoardArray, gameEngine.CurrentPlayer, -1, -1); // Valid move does not need x and y
            ValidMove validMoveForOppositePlayer = new ValidMove(gameEngine.BoardArray, oppositePlayer, -1, -1);

            if (checkIfSelectedIsPiece(selectionRow, selectionCol) == false)
            {
                string output1 = "You cannot select your own piece";
                MessageBox.Show(output1);
                outputSpeech(output1);
            }
            else if (checkForValidMoves(validMoveForCurrentPlayer) == false && checkForValidMoves(validMoveForOppositePlayer) == false)
            {
                string winner = playerWithGreaterTokens();
                string output2 = $"Neither player has a legal move. Game winner is {winner}";
                MessageBox.Show(output2);
                outputSpeech(output2);

                Application.Exit();
            }
            else if (checkForValidMoves(validMoveForCurrentPlayer) == false)
            {
                string output3 = $"{gameEngine.CurrentPlayer.Name} does not have a legal move";
                MessageBox.Show(output3);
                outputSpeech(output3);
                gameEngine.UpdateCurrentPlayer();
                _gameBoardGui.UpdateBoardGui(gameBoardData);
            }
            else if (illegalMove.checkAllSides() == false)
            {
                if (checkForValidMoves(validMoveForCurrentPlayer))
                {
                    updateBoardData(selectionRow, selectionCol);

                }
            }
            else
            {
                //MessageBox.Show($"You just clicked the square at row {selectionRow + 1} and col {selectionCol + 1}");
                string output4 = $"This is not a legal move";
                MessageBox.Show(output4);
                outputSpeech(output4);
            }
        }

        private int countTokensForPlayer(Player player)
        {
            int count = 0;
            for (int y = 0; y < NUM_OF_BOARD_ROWS; y++)
            {
                for (int x = 0; x < NUM_OF_BOARD_COL; x++)
                {
                    if (gameBoardData[y, x] == player.ID)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        private void GameTileClicked(object sender, EventArgs e)
        {
            int selectionRow = _gameBoardGui.GetCurrentRowIndex(sender);
            int selectionCol = _gameBoardGui.GetCurrentColumnIndex(sender);

            playUserMove(selectionRow, selectionCol);
            //MessageBox.Show($"{gameEngine.CurrentPlayer.Name}");
        }

        private void displayFiles(string requestType)
        {
            panel2.Visible = true;

            string[] fileNames = JsonData.getFileNames();

            checkedListBox1.Items[0] = fileNames[0];
            checkedListBox1.Items[1] = fileNames[1];
            checkedListBox1.Items[2] = fileNames[2];
            checkedListBox1.Items[3] = fileNames[3];
            checkedListBox1.Items[4] = fileNames[4];

            disableInput(requestType);
        }

        private void disableInput(string requestType) // "POST" = Save | "GET" = Load | "POST, RELOAD" = Save & Reload
        {
            if (requestType == "POST")
            {
                textBox3.Enabled = true;
                button6.Text = "Save";
                RequestType = "POST";
            }
            else if (requestType == "GET")
            {
                textBox3.Enabled = false;
                button6.Text = "Load";
                RequestType = "GET";
            }
            else if (requestType == "POST, RELOAD")
            {
                textBox3.Enabled = true;
                button6.Text = "Save";
                RequestType = "POST, RELOAD";
            }
        }

        private void hideFiles()
        {
            panel2.Visible = false;
        }

        private int ChechNumberOfSaves()
        {
            SaveState[] payload = JsonData.loadJsonData();
            int countSaves = 0;

            for (int i = 0; i < payload.Length; i++)
            {
                if (payload[i].FileName != "Blank")
                {
                    countSaves++;
                }
            }

            return countSaves;
        }

        private int getIndexOfOnlySave()
        {
            SaveState[] payload = JsonData.loadJsonData();

            for (int i = 0; i < payload.Length; i++)
            {
                if (payload[i].FileName != "Blank")
                {
                    return i;
                }
            }

            return -1; // In-case of there being no saves
        }

        private void extractJson(int fileIndex)
        {
            SaveState payload = JsonData.loadJsonData()[fileIndex];
            int[,] loadedBoardArr = payload.BoardArr;
            Player loadedP1 = payload.P1;
            Player loadedP2 = payload.P2;
            Player loadedCurrentPlayer;

            if (payload.CurrentPlayerID == 0)
            {
                loadedCurrentPlayer = loadedP1;
            }
            else
            {
                loadedCurrentPlayer = loadedP2;
            }

            panel2.Visible = false;

            if (_gameBoardGui == null) // If player is currently not in game, then generate new board instance.
            {
                generateNewBoard();
                button1.Visible = false;
            }

            textBox1.Text = loadedP1.Name;
            textBox2.Text = loadedP2.Name;

            textBox1.Enabled = false;
            textBox2.Enabled = false;

            gameEngine = new GameEngine();
            gameEngine.P1 = new Player(textBox1.Text, loadedP1.TokenCount, 0);
            gameEngine.P2 = new Player(textBox2.Text, loadedP2.TokenCount, 1);
            gameEngine.BoardArray = loadedBoardArr;
            gameEngine.CurrentPlayer = loadedCurrentPlayer;

            gameBoardData = gameEngine.BoardArray;
            _gameBoardGui.UpdateBoardGui(gameBoardData);

            if (loadedCurrentPlayer.ID == 0) // This fixes the bug of black having 2 turns when loading a game
            {
                gameEngine.UpdateCurrentPlayer();
            }
        }

        private void updateGUIAfterLoad()
        {
            gameEngine.P1.TokenCount = countTokensForPlayer(gameEngine.P1);
            gameEngine.P2.TokenCount = countTokensForPlayer(gameEngine.P2);

            label2.Text = $"{gameEngine.P1.TokenCount}";
            label1.Text = $"{gameEngine.P2.TokenCount}";
            updateCurrentPlayerGUI();
        }

        private void loadFileDataToScreen()
        {
            int numberOfSaves = ChechNumberOfSaves();

            if (numberOfSaves == 1)
            {
                SelectedFileIndex = getIndexOfOnlySave();
                extractJson(SelectedFileIndex);
            }
            else if (numberOfSaves > 1)
            {
                extractJson(SelectedFileIndex);
            }

            updateGUIAfterLoad();
        }

        private bool warningFromSave()
        {
            var result = MessageBox.Show("Are you sure? This will overwrite the current save", "Yes", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void saveFileDataToJson()
        {
            SaveState payload = new SaveState();
            if (textBox3.Text == "")
            {
                DateTime currentDateTime = DateTime.Now;
                string formattedDateTime = currentDateTime.ToString("dddd, dd MMMM yyyy HH:mm:ss");
                payload.FileName = formattedDateTime;
            }
            else
            {
                payload.FileName = textBox3.Text;
            }
            payload.BoardArr = gameBoardData;
            payload.CurrentPlayerID = gameEngine.CurrentPlayer.ID;
            payload.P1 = gameEngine.P1;
            payload.P2 = gameEngine.P2;
            if (warningFromSave())
            {
                JsonData.saveDataToJson(SelectedFileIndex, payload);
            }
            else
            {
                string output = "Operation Cancelled";
                MessageBox.Show(output);
                outputSpeech(output);
            }

            hideFiles();
        }

        private string playerWithGreaterTokens()
        {
            Player oppositePlayer = getOppositePlayer(gameEngine.CurrentPlayer);
            if (gameEngine.CurrentPlayer.TokenCount < oppositePlayer.TokenCount)
            {
                return gameEngine.CurrentPlayer.Name;
            }
            else if (gameEngine.CurrentPlayer.TokenCount > oppositePlayer.TokenCount)
            {
                return oppositePlayer.Name;
            }
            else
            {
                return "Draw";
            }
        }

        /* ----------------------------------- EVENT LISTENERS ----------------------------------------*/

        private void saveGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                displayFiles("POST");
            }
        }

        private void loadGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int numberOfSaves = ChechNumberOfSaves();
            if (numberOfSaves > 1)
            {
                displayFiles("GET");
            }
            else if (numberOfSaves == 1)
            {
                sToolStripMenuItem.Visible = true;
                saveGameToolStripMenuItem.Visible = true;
                loadFileDataToScreen();
            }
        }

        private void sToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Would you like to save your current game?", "Save Game?", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                displayFiles("POST, RELOAD");
            }
            else if (result == DialogResult.No)
            {
                Application.Restart();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") textBox1.Text = "Player 1#";
            if (textBox2.Text == "") textBox2.Text = "Player 2#";

            button1.Hide();
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            sToolStripMenuItem.Visible = true;
            saveGameToolStripMenuItem.Visible = true;
            updateCurrentPlayerGUI();

            generateNewBoard();

            gameEngine.P1 = new Player(textBox1.Text, 2, 0);
            gameEngine.P2 = new Player(textBox2.Text, 2, 1);
            gameEngine.BoardArray = gameBoardData;
            gameEngine.CurrentPlayer = gameEngine.P1;
        }

        private void label7_Click(object sender, EventArgs e)
        {
            hideFiles();
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iSelectedIndex = checkedListBox1.SelectedIndex;
            if (iSelectedIndex == -1)
                return;
            for (int iIndex = 0; iIndex < checkedListBox1.Items.Count; iIndex++)
            {
                checkedListBox1.SetItemCheckState(iIndex, CheckState.Unchecked);
            }


            checkedListBox1.SetItemCheckState(iSelectedIndex, CheckState.Checked);
            selectedFileName = checkedListBox1.Items[iSelectedIndex].ToString();
            SelectedFileIndex = iSelectedIndex;

            textBox3.Text = checkedListBox1.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (RequestType == "GET" && SelectedFileIndex != -1)
            {
                if (selectedFileName == "Blank")
                {
                    string output = "You cannot load a blank file";
                    MessageBox.Show(output);
                    outputSpeech(output);
                }
                else
                {
                    // If user is loading a game whilst not currently playing one, the settings will need to appear
                    sToolStripMenuItem.Visible = true;
                    saveGameToolStripMenuItem.Visible = true;
                    loadFileDataToScreen();
                }
            }
            else if (RequestType == "POST" && SelectedFileIndex != -1)
            {
                saveFileDataToJson();
            }
            else if (RequestType == "POST, RELOAD")
            {
                saveFileDataToJson();
                Application.Restart();
            }
        }

        private void informationPanelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (informationPanelToolStripMenuItem.Checked)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;
            }
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // If there is no game active, then don't ask user to save game
            if (button1.Visible == true)
            {
                Application.Exit();
            }

            var result = MessageBox.Show("Would you like to save your current game?", "Save Game?", MessageBoxButtons.YesNoCancel);

            if (result == DialogResult.Yes)
            {
                displayFiles("POST, RELOAD");
                Application.Exit();
            }
            else if (result == DialogResult.No)
            {
                Application.Exit();
            }
        }

        private void sToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();
            frm2.Show();
        }
    }
}