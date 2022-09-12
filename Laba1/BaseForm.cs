using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Laba1
{
    public partial class BaseForm : Form
    {
        Game game;
        public BaseForm(Game game)
        {
            InitializeComponent();
            this.game = game;
        }

        private void BaseForm_Load(object sender, EventArgs e)
        {
            var tuples = game.GetBase();
            if (tuples == null)
            {
                dataGridView1.Rows.Add("Ошибка");
                return;
            }
            foreach (var tuple in tuples)
            {
                dataGridView1.Rows.Add(tuple.Item1,tuple.Item2);
            }
        }
    }
}
