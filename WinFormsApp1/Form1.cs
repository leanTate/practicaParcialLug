using BE;
using BE.DTO;
using BLL;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var action = new PersonActions();
            Person req = new(txtName.Text, txtLastName.Text, int.Parse(txtDni.Text), int.Parse(txtPhone.Text));
            bool output = action.AddPerson(req);
            MessageBox.Show(output ? $"Se inserto correctamente a {req.Name} {req.LastName}" : "No se pudo insertar");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var action = new PersonActions();
            UpdateDto req = new(txtnew.Text, int.Parse(txtupdni.Text), comboBox1.Text);
            bool res = action.UpdatePerson(req);
            MessageBox.Show(res ? "se actualizo correctamente" : "no se logro actualizar");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var action = new PersonActions();
            bool res = action.DeletePerson(int.Parse(txtdnidel.Text));
            MessageBox.Show(res ? "se elimino correctamente" : "no se logro eliminar");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            var action = new PersonActions();
            List<Person> res = action.GetPersons();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = res;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var action = new PersonActions();
            List<Person> res = action.GetPersons();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = res;
        }
    }
}