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
        Colaborador _c;

        //contador codigo
        int _codigo;
        public Form1()
        {
            InitializeComponent();
            _d = new Distribucion();
            _c = new Colaborador();
            _codigo = 0;
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

            dataGridView1.RowHeadersWidth = 30;
            ActualizarGrilla(dataGridView1, _d.RetornarListaColaboradores());

            dataGridView2.RowHeadersWidth = 30;
            ActualizarGrilla(dataGridView2, _d.RetornarListaTareas());

            //Inteface Dispose
            if (_c is IDisposable)
            {
                _c.Dispose();
            }
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
                string _legajo = Interaction.InputBox("Legajo: ", "Agregar Cliente");
                if (_legajo.Length>0)
                {
                    _d.AgregarColaborador(new Colaborador(_legajo, Interaction.InputBox("Nombre: ", "Agregar Cliente")));
                    ActualizarGrilla(dataGridView1, _d.RetornarListaColaboradores());
                }
                else
                {
                    throw new Exception("Legajo vacío, complete el legajo!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "INGRESAR LEGAJO", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count>0)
                {
                    _d.BorrarColaborador(dataGridView1.SelectedRows[0].DataBoundItem as Colaborador);
                    ActualizarGrilla(dataGridView1, _d.RetornarListaColaboradores());
                }
                else
                {
                    throw new Exception("No hay colaboradores para borrar");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                
                DateTime fecha = DateTime.Today;
                string _cliente = Interaction.InputBox("Cliente: ", "Agregar Tarea");
                if (_cliente != null)
                {   
                    Tarea _auxTarea = new Tarea(_codigo++, Interaction.InputBox("Categoría: ", "Agregar Tarea"), _cliente, Interaction.InputBox("Descripción: ", "Agregar Tarea"), fecha);
                    _d.AgregarTarear(_auxTarea);
                    ActualizarGrilla(dataGridView2, _d.RetornarListaTareas());
                }
                else
                {
                    throw new Exception("Debe especificar un cliente");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"INGRESAR CLIENTE", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView2.Rows.Count>0)
                {
                    _d.BorrarTarea(dataGridView2.SelectedRows[0].DataBoundItem as Tarea);
                    ActualizarGrilla(dataGridView2, _d.RetornarListaTareas());
                }
                else
                {
                    throw new Exception("La lista está vacía");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message,"LISTA VACÍA", MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
            }
        }
    }
}
