namespace _2048
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, EventArgs e)
        {
            this.Hide();
            Game game = new Game();
            game.Show();
        }

        private void Help_Click(object sender, EventArgs e)
        {
            this.Hide();
            Help help = new Help();
            help.Show();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
