using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CONTROLADOR;

namespace TrabajoFinalAvanzado
{
    public partial class Form1 : Form
    {
        PacienteDTO pacienteDTO = null;
        PacienteDAO pacienteDAO = null;
        DataTable Dtt = null;
        public Form1()
        {
            InitializeComponent();
            ListarPacientes();
            
        }

        public void ListarPacientes()
        {

            pacienteDTO = new PacienteDTO();
            pacienteDAO= new PacienteDAO(pacienteDTO);

            Dtt = new DataTable();
            Dtt = pacienteDAO.ListarPaciente();

            if (Dtt.Rows.Count > 0)
            {
                dtpacientes.DataSource = Dtt;
            }
            else
            {
                MessageBox.Show("No hay registros de Pacientes");
            }
        }
        public void Guardar()
        {
            pacienteDTO = new PacienteDTO();
            pacienteDTO.setNombre(txtnombre.Text);
            pacienteDTO.setApellido(txtapellido.Text);
            pacienteDAO = new PacienteDAO(pacienteDTO);

            pacienteDAO.GuardarPaciente();
            MessageBox.Show("Registro Guardado");

        }

            private void btnguardar_Click(object sender, EventArgs e)
        {
            Guardar();
            ListarPacientes();
        }

        private void dtpacientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtcodigo.Text = dtpacientes.Rows[dtpacientes.CurrentRow.Index].Cells[0].Value.ToString();
            txtnombre.Text = dtpacientes.Rows[dtpacientes.CurrentRow.Index].Cells[1].Value.ToString();
            txtapellido.Text = dtpacientes.Rows[dtpacientes.CurrentRow.Index].Cells[2].Value.ToString();
        }
        public void GuardarCambios()
        {
            pacienteDTO = new PacienteDTO();
            pacienteDTO.setId(Convert.ToInt16(txtcodigo.Text));
            pacienteDTO.setNombre(txtnombre.Text);
            pacienteDTO.setApellido(txtapellido.Text);
            pacienteDAO = new PacienteDAO(pacienteDTO);

           
            

            pacienteDAO.GuardarCambios();
            MessageBox.Show("Registros Cambiados");
        }

        private void btnguardarcambios_Click(object sender, EventArgs e)
        {
            GuardarCambios();
            ListarPacientes();

        }
        public void EliminarRegistro()
        {
            pacienteDTO = new PacienteDTO();
            pacienteDTO.setId(Convert.ToInt16(txtcodigo.Text));
            pacienteDAO = new PacienteDAO(pacienteDTO);

            pacienteDAO.EliminarPaciente();
            MessageBox.Show("Registro Eliminado");
        }

        private void btneliminar_Click(object sender, EventArgs e)
        {
            EliminarRegistro();
            ListarPacientes();
        }
    }

}
