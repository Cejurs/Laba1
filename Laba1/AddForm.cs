
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
    }
}
