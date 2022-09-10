namespace Laba1
{
    public partial class MainForm : Form
    {
        private Game game;
        private bool lastClick;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            game = new Game();
            QuestionLabel.Text = game.CurentQuestion.Text;
            YesButton.Enabled = true;
            NoButton.Enabled = true;
        }
        private void CheckEndGame()
        {
            if(game.IsOver)
            {
                YesButton.Enabled = false;
                NoButton.Enabled = false;
                if(lastClick==false)
                {
                    var form = new AddForm(game);
                    form.ShowDialog();
                    this.Hide();
                }
                game.End();
                return;
            }
            QuestionLabel.Text=game.CurentQuestion.Text;
        }
        private void YesButton_Click(object sender, EventArgs e)
        {
            game.Yes();
            lastClick = true;
            CheckEndGame();
        }

        private void NoButton_Click(object sender, EventArgs e)
        {
            game.No();
            lastClick=false;
            CheckEndGame();
        }

        private void NewGameButton_Click(object sender, EventArgs e)
        {
            game.End();
            StartGame();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.End();
        }
    }
}