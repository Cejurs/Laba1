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
    public partial class FinalForm : Form
    {
        private Game game;
        private MainForm parent;
        public FinalForm(Game game, MainForm parent)
        {
            InitializeComponent();
            this.game = game;
            this.parent = parent;
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void Okbtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AnalisBtn_Click(object sender, EventArgs e)
        {
            var str = new StringBuilder();
            game.Analisis.ForEach(p => str.Append("\n"+p.Item1.ToString() + "\n" + p.Item2.ToString()));
            MessageBox.Show(str.ToString());
            this.Close();
        }

        private void FinalForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.End();
            parent.Show();
        }
    }
}
