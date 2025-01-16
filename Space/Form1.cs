using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Media;

namespace Space
{
    public partial class Form1 : Form
    {
        // Player scores
        private int scorePlayer1 = 0;
        private int scorePlayer2 = 0;

        // Sound
        SoundPlayer sp = new SoundPlayer(Properties.Resources.shotgun);
        SoundPlayer sp2 = new SoundPlayer(Properties.Resources.suspense);
        SoundPlayer sp3 = new SoundPlayer(Properties.Resources.punch);
        SoundPlayer sp4 = new SoundPlayer(Properties.Resources.rocket);

        // Create players 
        Rectangle player1 = new Rectangle(200, 270, 20, 20);
        Rectangle player2 = new Rectangle(400, 270, 20, 20); // Moved player 2 right

        // Hero speed
        int heroSpeed = 10;

        // List of balls
        List<Rectangle> balls = new List<Rectangle>();
        List<int> ballSpeeds = new List<int>();  // ball speeds
        List<int> ballSizes = new List<int>();   // ball sizes

        // Button presses
        bool upPressed = false;
        bool downPressed = false;
        bool wPressed = false;
        bool sPressed = false;

        // Brushes
        SolidBrush blueBrush = new SolidBrush(Color.DodgerBlue);
        SolidBrush greenBrush = new SolidBrush(Color.Green);
        SolidBrush blackBrush = new SolidBrush(Color.Black);

        // Random generator
        Random randGen = new Random();

        // Game state
        bool gameOver = false;

        // Player win message
        string winnerMessage = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Key cases for player movement
            if (gameOver)
                return; // Do nothing if game is over

            if (e.KeyCode == Keys.Up)
            {
                upPressed = true;
            }

            if (e.KeyCode == Keys.Down)
            {
                downPressed = true;
            }

            if (e.KeyCode == Keys.W)
            {
                wPressed = true;
            }

            if (e.KeyCode == Keys.S)
            {
                sPressed = true;
            }
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Up)
            {
                upPressed = false;
            }

            if (e.KeyCode == Keys.Down)
            {
                downPressed = false;
            }

            if (e.KeyCode == Keys.W)
            {
                wPressed = false;
            }

            if (e.KeyCode == Keys.S)
            {
                sPressed = false;
            }
        }

        private void gameTime_Tick(object sender, EventArgs e)
        {
            if (gameOver)
                return; // Stop game if the game is over

            // Move Player 1 (up/down)
            if (upPressed && player1.Y > 0)
            {
                player1.Y -= heroSpeed;
            }

            if (downPressed && player1.Y < this.Height - player1.Height)
            {
                player1.Y += heroSpeed;
            }

            // Move Player 2 (w/s) 
            if (wPressed && player2.Y > 0)
            {
                player2.Y -= heroSpeed;
            }

            if (sPressed && player2.Y < this.Height - player2.Height)
            {
                player2.Y += heroSpeed;
            }

            // Check if Player 1 reaches the top
            if (player1.Y <= 0)
            {
                scorePlayer1++;
                player1.Y = this.Height - player1.Height;
                sp3.Play();
            }

            // Check if Player 2 reaches the top
            if (player2.Y <= 0)
            {
                player2.Y = this.Height - player2.Height;
                scorePlayer2++;
                sp3.Play();
            }

            // Create balls randomly
            if (randGen.Next(0, 101) < 5)
            {
                int y = randGen.Next(0, this.Height - 200);
                int size = randGen.Next(10, 30);  // Random size 
                int speed = randGen.Next(5, 10);  // Random speed 
                balls.Add(new Rectangle(0, y, size, size));
                ballSpeeds.Add(speed);
                ballSizes.Add(size);
            }
            else if (randGen.Next(0, 101) < 5)
            {
                int y = randGen.Next(0, this.Height);
                int size = randGen.Next(10, 30);  // Random size 
                int speed = randGen.Next(5, 10);  // Random speed 
                balls.Add(new Rectangle(this.Width, y, size, size));  // Ball starts from right
                ballSpeeds.Add(-speed);
                ballSizes.Add(size);
            }

            // Move balls left or right
            for (int i = 0; i < balls.Count; i++)
            {
                balls[i] = new Rectangle(balls[i].X + ballSpeeds[i], balls[i].Y, ballSizes[i], ballSizes[i]);

                // Change direction when ball hits sides
                if (balls[i].X <= 0 || balls[i].X >= this.Width - balls[i].Width)
                    ballSpeeds[i] = -ballSpeeds[i];
            }

            // Check if Player 1 or Player 2 intersects with balls
            for (int i = 0; i < balls.Count; i++)
            {
                if (player1.IntersectsWith(balls[i]))
                {
                    balls.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                    ballSizes.RemoveAt(i);
                    sp.Play();
                    player1.Y = this.Height - player1.Height - 50;  // Reset Player 1 to bottom
                }
            }

            for (int i = 0; i < balls.Count; i++)
            {
                if (player2.IntersectsWith(balls[i]))
                {
                    balls.RemoveAt(i);
                    ballSpeeds.RemoveAt(i);
                    ballSizes.RemoveAt(i);
                    sp3.Play();
                    player2.Y = this.Height - player2.Height - 50;  // Reset Player 2 to bottom
                }
            }

            // Check for win condition
            if (scorePlayer1 >= 5 || scorePlayer2 >= 5)
            {
                gameOver = true;
                winnerMessage = scorePlayer1 >= 5 ? "Player 1 Wins!" : "Player 2 Wins!";
            }

            // Refresh the screen
            Refresh();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            // Draw the balls
            for (int i = 0; i < balls.Count; i++)
                e.Graphics.FillEllipse(greenBrush, balls[i]);

            // Draw players
            e.Graphics.FillRectangle(blueBrush, player1);
            e.Graphics.FillRectangle(blueBrush, player2);

            // Draw scores
            e.Graphics.DrawString($"Player 1: {scorePlayer1}", new Font("Arial", 12), blackBrush, 10, 10);
            e.Graphics.DrawString($"Player 2: {scorePlayer2}", new Font("Arial", 12), blackBrush, this.Width - 120, 10);

            // Draw the winner message if the game is over
            if (gameOver)
            {
                Font font = new Font("Arial", 24, FontStyle.Bold);
                SolidBrush brush = new SolidBrush(Color.Red);
                e.Graphics.DrawString(winnerMessage, font, brush, this.Width / 2 - e.Graphics.MeasureString(winnerMessage, font).Width / 2, this.Height / 2);
            }
        }    
    }
}
