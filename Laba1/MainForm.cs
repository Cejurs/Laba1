namespace Laba1
{
    public partial class MainForm : Form
    {
        private Game game;
        private bool lastClick;
        public MainForm()
        {
            InitializeComponent();
            game = new Game();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            StartGame();
        }

        private void StartGame()
        {
            lastClick = false;
            YesButton.Enabled = true;
            NoButton.Enabled = true;
            game.Start();
            CheckEndGame();
        }
        private void CheckEndGame()
        {
            if(game.IsOver)
            {
                YesButton.Enabled = false;
                NoButton.Enabled = false;
                if(lastClick==false)
                {
                    AddForm form = new AddForm(game,this);
                    form.Show();
                    this.Hide();
                }
                else
                {
                    FinalForm form = new FinalForm(game,this);
                    form.Show();
                    this.Hide();
                }
                return;
            }
            if (game.CurentQuestion != null)
            {
                QuestionLabel.Text = game.CurentQuestion.Text;
            }
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

        private void button1_Click(object sender, EventArgs e)
        {
            var baseform = new BaseForm(game);
            baseform.Show();
        }
    }
}