using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace DistribucionTareas
{
    public partial class Form1 : Form
    {
        Distribucion _d;
        public Form1()
        {
            InitializeComponent();
            _d = new Distribucion();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.MultiSelect = false;
            dataGridView2.MultiSelect = false;
            dataGridView3.MultiSelect = false;
            dataGridView4.MultiSelect = false;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView3.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView4.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
        }
        public void ActualizarGrilla(DataGridView pDGV, object pObjeto)
        {
            pDGV.DataSource = null;
            pDGV.DataSource = pObjeto;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string _legajo = Interaction.InputBox("Legajo: ");
                if (_legajo.Length>0)
                {
                    _d.AgregarColaborador(new Colaborador(_legajo, Interaction.InputBox("Nombre: ")));
                    ActualizarGrilla(dataGridView1, _d.RetornarListaColaboradores());
                }
                else
                {
                    throw new Exception("Legajo vacío, complete el legajo!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
