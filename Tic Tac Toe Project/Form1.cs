using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Properties;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        stGameStatus GameStatus;
        enPlayer PlayerTurn = enPlayer.Player1;
        enum enPlayer
        {
            Player1,
            Player2
        }

        enum enWinner
        {
            Player1,
            Player2,
            Draw,
            GameInProgress
        }

        struct stGameStatus
        {
            public enWinner Winner;
            public bool GameOver;
            public short PlayCount;

        }
        public Form1()
        {
            InitializeComponent();
            
        }
        

        public void ChangeImage(PictureBox pct)
        {
            if(pct.Tag.ToString() == "?")
            {
                switch(PlayerTurn)
                {
                    case enPlayer.Player1:
                        pct.Image = Resources.X;
                        PlayerTurn = enPlayer.Player2;
                        lblTurn.Text = "Player 2";
                        GameStatus.PlayCount++;
                        pct.Tag = "X";
                        CheckWinner();
                        break;
                    case enPlayer.Player2:
                        pct.Image = Resources.O;
                        PlayerTurn = enPlayer.Player1;
                        lblTurn.Text = "Player 1";
                        GameStatus.PlayCount++;
                        pct.Tag = "Y";
                        CheckWinner();
                        break;

                }
            }
        }


        public bool CheckValues(PictureBox btn1, PictureBox btn2, PictureBox btn3)
        {


            if (btn1.Tag.ToString() != "?" && btn1.Tag.ToString() == btn2.Tag.ToString() && btn1.Tag.ToString() == btn3.Tag.ToString())
            {

                btn1.BackColor = Color.GreenYellow;
                btn2.BackColor = Color.GreenYellow;
                btn3.BackColor = Color.GreenYellow;

                if (btn1.Tag.ToString() == "X")
                {
                    GameStatus.Winner = enWinner.Player1;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }
                else
                {
                    GameStatus.Winner = enWinner.Player2;
                    GameStatus.GameOver = true;
                    EndGame();
                    return true;
                }

            }

            GameStatus.GameOver = false;
            return false;


        }

        void EndGame()
        {

            lblTurn.Text = "Game Over";
            switch (GameStatus.Winner)
            {

                case enWinner.Player1:

                    label5.Text = "Player1";
                    break;

                case enWinner.Player2:

                    label5.Text = "Player2";
                    break;

                default:

                    label5.Text = "Draw";
                    break;

            }

            MessageBox.Show("GameOver", "GameOver", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }


        public void CheckWinner()
        {


            //checked rows
            //check Row1
            if (CheckValues(pictureBox1, pictureBox4, pictureBox5))
                return;

            //check Row2
            if (CheckValues(pictureBox2, pictureBox6, pictureBox7))
                return;

            //check Row3
            if (CheckValues(pictureBox3, pictureBox8, pictureBox9))
                return;

            //checked cols
            //check col1
            if (CheckValues(pictureBox1, pictureBox2, pictureBox3))
                return;

            //check col2
            if (CheckValues(pictureBox4, pictureBox6, pictureBox8))
                return;

            //check col3
            if (CheckValues(pictureBox5, pictureBox7, pictureBox9))
                return;

            //check Diagonal

            //check Diagonal1
            if (CheckValues(pictureBox1, pictureBox6, pictureBox9))
                return;

            //check Diagonal2
            if (CheckValues(pictureBox5, pictureBox6, pictureBox3))
                return;


        }

        private void RestButton(PictureBox btn)
        {
            btn.Image = Resources.question_mark_96;
            btn.Tag = "?";
            btn.BackColor = Color.Transparent;

        }

        private void RestartGame()
        {

            RestButton(pictureBox1);
            RestButton(pictureBox2);
            RestButton(pictureBox3);
            RestButton(pictureBox4);
            RestButton(pictureBox5);
            RestButton(pictureBox6);
            RestButton(pictureBox7);
            RestButton(pictureBox8);
            RestButton(pictureBox9);

            PlayerTurn = enPlayer.Player1;
            lblTurn.Text = "Player 1";
            GameStatus.PlayCount = 0;
            GameStatus.GameOver = false;
            GameStatus.Winner = enWinner.GameInProgress;
            label5.Text = "In Progress";



        }


        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Color white = Color.FromArgb(255, 255, 255);
            Pen pen = new Pen(white);
            pen.Width = 10;
            pen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            pen.EndCap = System.Drawing.Drawing2D.LineCap.Round;
            
            // Horizintal Line
            e.Graphics.DrawLine(pen, 400, 300, 1050, 300);
            e.Graphics.DrawLine(pen, 400, 460, 1050, 460);
            // Vertical Line
            e.Graphics.DrawLine(pen, 610, 140, 610, 620);
            e.Graphics.DrawLine(pen, 840, 140, 840, 620);
            

        }

        private void pictureBox_Click(object sender, EventArgs e)
        {
            ChangeImage((PictureBox)sender);
        }

       

        private void button1_Click(object sender, EventArgs e)
        {
            RestartGame();
        }

        
    }
}
