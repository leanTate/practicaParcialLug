using BE;
using BE.DTO;
using BLL;
using System.Data;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        DataSet mydatset;
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
            mydatset = action.GetPersons();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = mydatset.Tables[0];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var action = new PersonActions();
            mydatset = action.GetPersons();
            mydatset.Tables[0].TableName = "personas";
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = mydatset.Tables[0];
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var action = new PersonActions();
            foreach (DataRow row in mydatset.Tables[0].Select($"dni = {txtdnidel.Text}"))
            {
                row.Delete();
            }
            bool res = action.DeletePersonD(mydatset);
            MessageBox.Show(res ? "se elimino correctamente" : "no se logro eliminar");
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var action = new PersonActions();
            Person req = new(txtName.Text, txtLastName.Text, int.Parse(txtDni.Text), int.Parse(txtPhone.Text));
            mydatset.Tables[0].Rows.Add(null,req.Name, req.LastName,req.Dni,req.Phone);
            var output = action.AddPersonD(mydatset);
            MessageBox.Show(output ? $"Se inserto correctamente a {req.Name} {req.LastName}" : "No se pudo insertar en la db");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var action = new PersonActions();
            UpdateDto req = new(txtnew.Text, int.Parse(txtupdni.Text), comboBox1.Text);
            int i = 0;
            foreach (DataRow row in mydatset.Tables[0].Rows) {
                if (Convert.ToInt32(row["dni"]) == req.Dni)
                {
                    mydatset.Tables[0].Rows[i][req.Type] = req.Newdata;
                }
                i++;
            }
            bool res = action.UpdatePersonD(mydatset);
            MessageBox.Show(res ? "se actualizo correctamente" : "no se logro actualizar");
        }
    }
}