using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] lines = File.ReadAllLines(@"C:\\I\\acesso.txt");
            string[] values;

            for (int i = 0; i < lines.Length; i++)
            {
                values = lines[i].ToString().Split(';');
                string[] row = new string[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    row[j] = values[j].Trim();
                }
                dataGridView1.Rows.Add(row);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            TextWriter writer = new StreamWriter(@"C:\\I\\acesso.txt");
            for (int i = 0; i < dataGridView1.Rows.Count-1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    writer.Write(dataGridView1.Rows[i].Cells[j].Value.ToString()+";");
                }
                writer.WriteLine("");
            }
            MessageBox.Show("Salvo com sucesso :)", "Sistema informa!");
            writer.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            if (txtdesc.Text == "")
            {
                MessageBox.Show("Informe a descrição", "Sistema informa!");
            }
            else if (txtacesso.Text == "")
                  {
                    MessageBox.Show("Informe o link de acesso", "Sistema informa!");
                  }
                    else
                    {
                    dataGridView1.Rows.Add(txtdesc.Text, txtacesso.Text);
                    txtacesso.Clear();
                    txtdesc.Clear();
                    }
           
        }

        private void btnremover_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.SelectedRows)
            {
                try 
                {
                    dataGridView1.Rows.RemoveAt(row.Index);
                }
                catch
                {
                    MessageBox.Show("Selecione uma linha com registros", "Sistema informa!");
                }

            }
        }

        private void btnacesso_Click(object sender, EventArgs e)
        {
            string endereco;
            DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];
            endereco = selectedRow.Cells[1].Value.ToString();
            System.Diagnostics.Process.Start(endereco);
                    
        }
    }
}
