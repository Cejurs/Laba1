
namespace Laba1
{
    public partial class AddForm : Form
    {
        private Game game;

        public AddForm()
        {
            InitializeComponent();
        }

        public AddForm(Game game)
        {
            this.game = game;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = game.GetAllProfession();
            dataGridView2.DataSource= game.GetAllQuestion();
        }
    }
}
