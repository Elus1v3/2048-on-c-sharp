namespace _2048
{
    partial class Game
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            maxScore = new Label();
            playAgain = new Button();
            Back = new Button();
            SuspendLayout();
            // 
            // maxScore
            // 
            maxScore.AutoSize = true;
            maxScore.Font = new Font("Times New Roman", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            maxScore.Location = new Point(380, 30);
            maxScore.Name = "maxScore";
            maxScore.Size = new Size(0, 21);
            maxScore.TabIndex = 0;
            // 
            // playAgain
            // 
            playAgain.CausesValidation = false;
            playAgain.Location = new Point(380, 85);
            playAgain.Name = "playAgain";
            playAgain.Size = new Size(100, 25);
            playAgain.TabIndex = 5;
            playAgain.Text = "Play Again";
            playAgain.UseVisualStyleBackColor = true;
            playAgain.Click += playAgain_Click;
            playAgain.KeyDown += Form1_KeyDown;
            // 
            // Back
            // 
            Back.Location = new Point(380, 300);
            Back.Name = "Back";
            Back.Size = new Size(75, 50);
            Back.TabIndex = 6;
            Back.Text = "Back";
            Back.UseVisualStyleBackColor = true;
            Back.Click += Back_Click;
            // 
            // Game
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1084, 561);
            Controls.Add(Back);
            Controls.Add(playAgain);
            Controls.Add(maxScore);
            KeyPreview = true;
            Name = "Game";
            Text = "Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label maxScore;
        private Button playAgain;
        private Button Back;
    }
}