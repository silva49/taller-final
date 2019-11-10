using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.Data;
using System.Data.SqlClient;
using MODELO;

namespace CONTROLADOR
{
    public class PacienteDAO
    {
        ClsDatos clsDatos = null;
     PacienteDTO pacienteDTO = null;
        DataTable listaDatos = null;

        public PacienteDAO(PacienteDTO pacienteDTO)
        {
            this.pacienteDTO = pacienteDTO;
        }


        public DataTable ListarPaciente()
        {
            listaDatos = new DataTable();

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametros = null;

                if (this.pacienteDTO == null)
                {

                    parametros = new SqlParameter[3];

                    parametros[0] = new SqlParameter();
                    parametros[0].ParameterName = "@id";
                    parametros[0].SqlDbType = SqlDbType.Int;
                    parametros[0].SqlValue = pacienteDTO.getId();

                    parametros[1] = new SqlParameter();
                    parametros[1].ParameterName = "@Nombre";
                    parametros[1].SqlDbType = SqlDbType.VarChar;
                    parametros[1].Size = 50;
                    parametros[1].SqlValue = pacienteDTO.getNombre();

                    parametros[2] = new SqlParameter();
                    parametros[2].ParameterName = "@Apellido";
                    parametros[2].SqlDbType = SqlDbType.VarChar;
                    parametros[2].Size = 50;
                    parametros[2].SqlValue = pacienteDTO.getApellido();

           
                }
                else
                {

                    parametros = null;
                }

                listaDatos = clsDatos.RetornarTabla(parametros, "spConsultaPaciente");
            }
            catch (Exception exception)
            {

                throw new Exception(exception.Message);
            }
            return listaDatos;
        }

        public void GuardarPaciente()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[3];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@Id";
                parametro[0].SqlDbType = SqlDbType.Int;
             
                parametro[0].SqlValue = pacienteDTO.getId();

                parametro[1] = new SqlParameter();
                parametro[1].ParameterName = "@Nombre";
                parametro[1].SqlDbType = SqlDbType.VarChar;
                parametro[1].Size = 50;
                parametro[1].SqlValue = pacienteDTO.getNombre();



                parametro[2] = new SqlParameter();
                parametro[2].ParameterName = "@Apellido";
                parametro[2].SqlDbType = SqlDbType.VarChar;
                parametro[2].Size = 50;
                parametro[2].SqlValue = pacienteDTO.getApellido();


                listaDatos = clsDatos.RetornarTabla(parametro, "spNuevoNombre");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public void GuardarCambios()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[3];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@id";
                parametro[0].SqlDbType = SqlDbType.Int;
                parametro[0].SqlValue = pacienteDTO.getId();


                parametro[1] = new SqlParameter();
                parametro[1].ParameterName = "@Nombre";
                parametro[1].SqlDbType = SqlDbType.VarChar;
                parametro[1].Size = 50;
                parametro[1].SqlValue = pacienteDTO.getNombre();

                parametro[2] = new SqlParameter();
                parametro[2].ParameterName = "@Apellido";
                parametro[2].SqlDbType = SqlDbType.VarChar;
                parametro[2].Size = 50;
                parametro[2].SqlValue = pacienteDTO.getApellido();

                clsDatos.EjecutaSP(parametro, "spGuardarCambiosPaciente");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }
        public void EliminarPaciente()
        {

            try
            {
                clsDatos = new ClsDatos();
                SqlParameter[] parametro = new SqlParameter[1];

                parametro[0] = new SqlParameter();
                parametro[0].ParameterName = "@Id";
                parametro[0].SqlDbType = SqlDbType.Int;

                parametro[0].SqlValue = pacienteDTO.getId();

                clsDatos.EjecutaSP(parametro, "spEliminarPaciente");
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

    }
}
