namespace _2048
{
    partial class Menu
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Play = new Button();
            Help = new Button();
            Exit = new Button();
            SuspendLayout();
            // 
            // Play
            // 
            Play.Location = new Point(300, 100);
            Play.Name = "Play";
            Play.Size = new Size(400, 50);
            Play.TabIndex = 0;
            Play.Text = "Play";
            Play.UseVisualStyleBackColor = true;
            Play.Click += Play_Click;
            // 
            // Help
            // 
            Help.Location = new Point(300, 200);
            Help.Name = "Help";
            Help.Size = new Size(400, 50);
            Help.TabIndex = 1;
            Help.Text = "Help";
            Help.UseVisualStyleBackColor = true;
            Help.Click += Help_Click;
            // 
            // Exit
            // 
            Exit.Location = new Point(300, 300);
            Exit.Name = "Exit";
            Exit.Size = new Size(400, 50);
            Exit.TabIndex = 2;
            Exit.Text = "Exit";
            Exit.UseVisualStyleBackColor = true;
            Exit.Click += Exit_Click;
            // 
            // Menu
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 461);
            Controls.Add(Exit);
            Controls.Add(Help);
            Controls.Add(Play);
            Name = "Menu";
            Text = "Menu";
            ResumeLayout(false);
        }

        #endregion

        private Button Play;
        private Button Help;
        private Button Exit;
    }
}
