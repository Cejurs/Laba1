
using System.Data;

namespace Laba1
{
    public partial class AddForm : Form
    {
        private Game game;
        private List<int> addProfessionIds;
        private List<int> addQuestionIds;
        private MainForm parent;


        public AddForm(Game game,MainForm parent)
        {
            InitializeComponent();
            this.game = game;
            addProfessionIds = new List<int>();
            addQuestionIds = new List<int>();
            this.parent=parent;
        }


        private void AddForm_Load(object sender, EventArgs e)
        {
            var datasourse1= game.GetAllProfession();
            var datasourse2= game.GetQuestionsWithoutDirect();
            if(datasourse1==null || datasourse2==null) this.Close();
            dataGridView1.DataSource = datasourse1;
            dataGridView2.DataSource= datasourse2;
            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["IsUsed"].Visible = false;
            dataGridView2.Columns["Id"].Visible = false;
            dataGridView2.Columns["IsUsed"].Visible = false;
            dataGridView2.Columns["IsDirectQuestion"].Visible = false;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id=dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            var name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dataGridView3.Rows.Add(id, name);
            dataGridView1.Rows.RemoveAt(e.RowIndex);
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {

        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int) dataGridView1.Rows[e.RowIndex].Cells[0].Value;
            if (addProfessionIds.Contains(id))
            {
                MessageBox.Show("Выбранная профессия уже в добавленных");
                return;
            }
            addProfessionIds.Add(id);
            var name = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            dataGridView3.Rows.Add(id, name);
        }

        private void dataGridView3_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)dataGridView3.Rows[e.RowIndex].Cells[0].Value;
            addProfessionIds.Remove(id);
            dataGridView3.Rows.RemoveAt(e.RowIndex);
        }

        private void dataGridView2_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)dataGridView2.Rows[e.RowIndex].Cells[0].Value;
            if (addQuestionIds.Contains(id))
            {
                MessageBox.Show("Выбранный вопрос уже в добавленных");
                return;
            }
            addQuestionIds.Add(id);
            var name = dataGridView2.Rows[e.RowIndex].Cells[1].Value.ToString();
            dataGridView4.Rows.Add(id, name);
        }

        private void dataGridView4_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var id = (int)dataGridView2.Rows[e.RowIndex].Cells[0].Value;
            addQuestionIds.Remove(id);
            dataGridView4.Rows.RemoveAt(e.RowIndex);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (Answer.Text == "")
            {
                MessageBox.Show("Не введены значение в поле вопрос");
                return;
            }
            if (Question.Text == "" && addQuestionIds.Count == 0  )
            {
                MessageBox.Show("Введите или выберите вопрос(ы)");
                return;
            }
            if (Question.Text == "") game.Add(Answer.Text, addProfessionIds, addQuestionIds);
            else game.Add(Answer.Text, addProfessionIds, addQuestionIds, Question.Text);
            this.Close();
        }

        private void AddForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            game.End();
            parent.Show();
        }
    }
}
