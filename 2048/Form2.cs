using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Game : Form
    {
        public int[,] gameField = new int[4, 4];
        public Button[,] bt = new Button[4, 4];
        int[] numbers = { 2, 2, 2, 2, 2, 2, 2, 2, 2, 4 };
        int x0 = 30, y0 = 30, sizeButton = 80, previousMaxScore = 0, currentMaxScore = 0;
        bool playAfterWin = false;
        string str;

        public Game()
        {
            InitializeComponent();

            CreateGameField(bt, gameField);

            for (int i = 0; i < 2; i++)
            {
                FillGameField(gameField);
            }

            using (var sr = new StreamReader("maxScore.txt"))
            {
                str = sr.ReadLine();
                previousMaxScore = Convert.ToInt32(str);
                maxScore.Text = "Max Score: " + str;
            }

            coloringTheButtons(gameField, bt);

        }


        public void coloringTheButtons(int[,] gameField, Button[,] bt)
        {
            for (int k = 0; k < 4; k++)
            {
                for (int u = 0; u < 4; u++)
                {
                    if (gameField[k, u] != 0)
                    {
                        switch (gameField[k, u])
                        {
                            case 2:
                                bt[k, u].BackColor = Color.White;
                                break;
                            case 4:
                                bt[k, u].BackColor = Color.LightSlateGray;
                                break;
                            case 8:
                                bt[k, u].BackColor = Color.AntiqueWhite;
                                break;
                            case 16:
                                bt[k, u].BackColor = Color.LightGoldenrodYellow;
                                break;
                            case 32:
                                bt[k, u].BackColor = Color.PeachPuff;
                                break;
                            case 64:
                                bt[k, u].BackColor = Color.GreenYellow;
                                break;
                            case 128:
                                bt[k, u].BackColor = Color.LimeGreen;
                                break;
                            case 256:
                                bt[k, u].BackColor = Color.ForestGreen;
                                break;
                            case 512:
                                bt[k, u].BackColor = Color.PaleTurquoise;
                                break;
                            case 1024:
                                bt[k, u].BackColor = Color.MediumPurple;
                                break;
                            case 2048:
                                bt[k, u].BackColor = Color.BlueViolet;
                                break;
                            case 4096:
                                bt[k, u].BackColor = Color.PaleVioletRed;
                                break;
                            case 8192:
                                bt[k, u].BackColor = Color.IndianRed;
                                break;
                            case 16384:
                                bt[k, u].BackColor = Color.LightSteelBlue;
                                break;
                            case 32768:
                                bt[k, u].BackColor = Color.CornflowerBlue;
                                break;
                            case 65536:
                                bt[k, u].BackColor = Color.DodgerBlue;
                                break;
                        }
                        bt[k, u].Text = gameField[k, u].ToString();
                    }
                    else
                        bt[k, u].BackColor = Color.LightGray;
                }
            }
        }


        public void FillGameField(int[,] gameField)
        {
            bool flag = true;
            Random rnd = new Random();
            while (flag)
            {
                int i = rnd.Next(0, 4);
                int j = rnd.Next(0, 4);
                if (gameField[i, j] == 0)
                {
                    gameField[i, j] = numbers[rnd.Next(0, numbers.Length)];
                    flag = false;
                }
            }
        }


        public void CreateGameField(Button[,] bt, int[,] gameField)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    gameField[i, j] = 0;
                    bt[i, j] = new Button();
                    bt[i, j].Left = x0 + j * sizeButton;
                    bt[i, j].Top = y0 + i * sizeButton;
                    bt[i, j].Size = new Size(sizeButton, sizeButton);
                    bt[i, j].BackColor = Color.LightGray;
                    bt[i, j].Font = new Font("Timew new Roman", 10, FontStyle.Bold);
                    Controls.Add(bt[i, j]);
                }
            }
        }


        public void lose(int[,] gameField, Button[,] bt)
        {
            int timer = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameField[i, j] != 0)
                    {
                        if (j == 3 && i != 3)
                        {
                            if (gameField[i, j] != gameField[i + 1, j])
                                timer++;
                        }
                        else if (i == 3 && j != 3)
                        {
                            if (gameField[i, j] != gameField[i, j + 1])
                                timer++;
                        }
                        else if (i == 3 && j == 3 && timer == 15 || i == 3 && j == 3 && timer != 15)
                            timer++;
                        else
                        {
                            if (gameField[i, j] != gameField[i + 1, j] && gameField[i, j] != gameField[i, j + 1])
                                timer++;
                        }
                    }

                    if (gameField[i, j] > currentMaxScore)
                        currentMaxScore = gameField[i, j];
                }
            }

            if (timer == 16)
            {
                if (currentMaxScore > previousMaxScore)
                {
                    using (StreamWriter sw = new StreamWriter("maxScore.txt"))
                    {
                        sw.Write(currentMaxScore.ToString());
                    }
                }

                DialogResult result = MessageBox.Show("Хотите начать заново?", "Вы проиграли", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        for (int j = 0; j < 4; j++)
                        {
                            gameField[i, j] = 0;
                            bt[i, j].Text = "";
                        }
                    }

                    using (var sr = new StreamReader("maxScore.txt"))
                    {
                        str = sr.ReadLine();
                        previousMaxScore = Convert.ToInt32(str);
                        maxScore.Text = "Max Score: " + str;
                    }

                    for (int i = 0; i < 2; i++)
                    {
                        FillGameField(gameField);
                    }

                    coloringTheButtons(gameField, bt);
                }
                else
                {
                    this.Hide();
                    Menu menu = new Menu();
                    menu.Show();
                }
            }
        }


        public void win(int[,] gameField, Button[,] bt)
        {
            bool win = false;

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameField[i, j] == 2048)
                        win = true;

                    if (gameField[i, j] > currentMaxScore)
                        currentMaxScore = gameField[i, j];
                }
            }

            if (win)
            {
                if (currentMaxScore > previousMaxScore)
                {
                    using (StreamWriter sw = new StreamWriter("maxScore.txt"))
                    {
                        sw.Write(currentMaxScore.ToString());
                    }

                }

                DialogResult result = MessageBox.Show("Хотите продолжить?", "Победа", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    playAfterWin = true;

                    using (var sr = new StreamReader("maxScore.txt"))
                    {
                        str = sr.ReadLine();
                        previousMaxScore = Convert.ToInt32(str);
                        maxScore.Text = "Max Score: " + str;
                    }
                }

                else
                {
                    DialogResult result2 = MessageBox.Show("Хотите выйти в меню?", "Победа", MessageBoxButtons.YesNo);

                    if (result2 == DialogResult.Yes)
                    {
                        this.Hide();
                        Menu menu = new Menu();
                        menu.Show();
                    }
                    else
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            for (int j = 0; j < 4; j++)
                            {
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                            }
                        }

                        using (var sr = new StreamReader("maxScore.txt"))
                        {
                            str = sr.ReadLine();
                            previousMaxScore = Convert.ToInt32(str);
                            maxScore.Text = "Max Score: " + str;
                        }

                        for (int i = 0; i < 2; i++)
                        {
                            FillGameField(gameField);
                        }

                        coloringTheButtons(gameField, bt);
                    }
                }
            }
        }


        public void up()
        {
            bool moved = false;

            for (int t = 0; t < 3; t++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (gameField[i, j] != 0 && i != 0)
                        {
                            int f = i - 1;

                            if (gameField[f, j] == 0)
                            {
                                gameField[f, j] = gameField[i, j];
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                                moved = true;
                            }
                            else if (gameField[f, j] == gameField[i, j])
                            {
                                gameField[f, j] *= 2;
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                                moved = true;
                            }
                        }
                    }
                }
            }

            if (moved)
                FillGameField(gameField);

            coloringTheButtons(gameField, bt);

            if (!playAfterWin)
                win(gameField, bt);

            lose(gameField, bt);
        }


        public void down()
        {
            bool moved = false;

            for (int t = 0; t < 3; t++)
            {
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 3; j >= 0; j--)
                    {
                        if (gameField[i, j] != 0 && i != 3)
                        {
                            int f = i + 1;

                            if (gameField[f, j] == 0)
                            {
                                gameField[f, j] = gameField[i, j];
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                                moved = true;
                            }
                            else if (gameField[f, j] == gameField[i, j])
                            {
                                gameField[f, j] *= 2;
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                                moved = true;
                            }
                        }
                    }
                }
            }

            if (moved)
                FillGameField(gameField);

            coloringTheButtons(gameField, bt);

            if (!playAfterWin)
                win(gameField, bt);

            lose(gameField, bt);
        }


        public void right()
        {
            bool moved = false;

            for (int t = 0; t < 3; t++)
            {
                for (int i = 3; i >= 0; i--)
                {
                    for (int j = 3; j >= 0; j--)
                    {
                        if (gameField[i, j] != 0 && j != 3)
                        {
                            int f = j + 1;

                            if (gameField[i, f] == 0)
                            {
                                gameField[i, f] = gameField[i, j];
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                                moved = true;
                            }
                            else if (gameField[i, f] == gameField[i, j])
                            {
                                gameField[i, f] *= 2;
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                                moved = true;
                            }
                        }
                    }
                }
            }

            if (moved)
                FillGameField(gameField);

            coloringTheButtons(gameField, bt);

            if (!playAfterWin)
                win(gameField, bt);

            lose(gameField, bt);
        }


        public void left()
        {
            bool moved = false;

            for (int t = 0; t < 3; t++)
            {
                for (int i = 0; i < 4; i++)
                {
                    for (int j = 0; j < 4; j++)
                    {
                        if (gameField[i, j] != 0 && j != 0)
                        {
                            int f = j - 1;

                            if (gameField[i, f] == 0)
                            {
                                gameField[i, f] = gameField[i, j];
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                                moved = true;
                            }
                            else if (gameField[i, f] == gameField[i, j])
                            {
                                gameField[i, f] *= 2;
                                gameField[i, j] = 0;
                                bt[i, j].Text = "";
                                moved = true;
                            }
                        }
                    }
                }
            }

            if (moved)
                FillGameField(gameField);

            coloringTheButtons(gameField, bt);

            if (!playAfterWin)
                win(gameField, bt);

            lose(gameField, bt);
        }


        private void playAgain_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    if (gameField[i, j] > currentMaxScore)
                        currentMaxScore = gameField[i, j];
                    gameField[i, j] = 0;
                    bt[i, j].Text = "";
                }
            }

            if (currentMaxScore > previousMaxScore)
            {
                using (StreamWriter sw = new StreamWriter("maxScore.txt"))
                {
                    sw.Write(currentMaxScore.ToString());
                }
            }

            using (var sr = new StreamReader("maxScore.txt"))
            {
                str = sr.ReadLine();
                previousMaxScore = Convert.ToInt32(str);
                maxScore.Text = "Max Score: " + str;
            }

            for (int i = 0; i < 2; i++)
            {
                FillGameField(gameField);
            }

            coloringTheButtons(gameField, bt);
        }


        private void Back_Click(object sender, EventArgs e)
        {
            this.Hide();
            Menu menu = new Menu();
            menu.Show();
        }


        public void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
                up();
            else if (e.KeyCode == Keys.S)
                down();
            else if (e.KeyCode == Keys.D)
                right();
            else if (e.KeyCode == Keys.A)
                left();
        }
    }
}