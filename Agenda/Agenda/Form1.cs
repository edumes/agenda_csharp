using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlServerCe;

namespace Agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'agendaDataSet.tb_amigos' table. You can move, or remove it, as needed.
            this.tb_amigosTableAdapter.Fill(this.agendaDataSet.tb_amigos);

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_cadastrar_Click(object sender, EventArgs e)
        {
            SqlCeConnection cn = new SqlCeConnection(
                @"Data Source=C:\Users\DESKTOP-E\Desktop\Agenda\Database\Agenda.sdf"
                );

            SqlCeCommand cm = new SqlCeCommand(
                "INSERT INTO tb_amigos(nome, zap)" +
                " VAlUES (@nome_cliente, @tel_cliente)", cn
                );
            cm.Parameters.AddWithValue("@nome_cliente", input_nome.Text);
            cm.Parameters.AddWithValue("@tel_cliente", input_zap.Text);

            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();

            MessageBox.Show("Cadastro realizado com sucesso!");
        }
    }
}
