using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ClinicaProject
{
    public partial class Consultas : Form
    {
        public Consultas()
        {
            InitializeComponent();
        }

        private void Consultas_Load(object sender, EventArgs e)
        {
            LlenarComboDoctor();
            LLenarGridPacientes();
            LlenarComboTratamiento();
            LoadTratamientoAsignado();
        }

        private void LoadTratamientoAsignado()
        {
            using (SqlConnection conexion = new SqlConnection(DB.ConexionDB.Cadena))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Consultas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Event", SqlDbType.VarChar, 20).Value = "ChangeTratamiento";
                cmd.Parameters.Add("@IdTratamiento", SqlDbType.Int).Value = cboTratamiento.SelectedValue;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();
             
                 txtObservaciones.Text = ""+dt.Rows[0].ItemArray[1];
                txtCostoTratamiento.Text = ""+Convert.ToDecimal(dt.Rows[0].ItemArray[2]);
            }
        }


        private void LlenarComboTratamiento ()
        {
            using (SqlConnection conexion = new SqlConnection(DB.ConexionDB.Cadena))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Consultas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Event", SqlDbType.VarChar, 20).Value = "CboTratamiento";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();
                cboTratamiento.ValueMember = "ID_tratamiento";
                cboTratamiento.DisplayMember = "Tipo_tratamiento";
                cboTratamiento.DataSource = dt;
            }



        }

        private void LlenarComboDoctor()
        {


          using (SqlConnection conexion = new SqlConnection(DB.ConexionDB.Cadena))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Consultas", conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@Event", SqlDbType.VarChar, 10).Value = "CboDoctor";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                conexion.Close();
                cboDoctorA.ValueMember = "ID_doctor";
                cboDoctorA.DisplayMember = "nombre";
                cboDoctorA.DataSource = dt;
            }


           








          //  string Conexion = Convert.ToString(DB.ConexionDb);
            //Console.WriteLine(Conexion);
          /*  SqlConnection dataConnection = new SqlConnection(Conexion);
            dataConnection.Open();
            SqlCommand cmd = new SqlCommand("Sp_GridCrud", dataConnection);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Event", SqlDbType.VarChar, 10).Value = "Combobox";


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataConnection.Close();
            cboCargo.ValueMember = "IdCargo";
            cboCargo.DisplayMember = "Cargo";

            cboCargo.DataSource = dt;*/
        }


             private void LLenarGridPacientes()
             {
        SqlConnection dataConnection = new SqlConnection(DB.ConexionDB.Cadena);
                  try
                  {

                      dataConnection.Open();
                      SqlCommand cmd = new SqlCommand("sp_Consultas", dataConnection);
                      cmd.CommandType = CommandType.StoredProcedure;
                      cmd.Parameters.Add("@Event", SqlDbType.VarChar, 20).Value = "FillPacientes";


                      SqlDataAdapter da = new SqlDataAdapter(cmd);
                      DataTable dt = new DataTable();
                      da.Fill(dt);
                      dataConnection.Close();
                      gridPacientes.DataSource = dt;

                      /*

                      SqlDataReader reader;



                      CreateConnection();
                      OpenConnection();
                      _sqlCommand.CommandText = "Sp_GridCrud";
                      _sqlCommand.CommandType = CommandType.StoredProcedure;
                      _sqlCommand.Parameters.AddWithValue("@Event", "Select");
                      reader = _sqlCommand.ExecuteReader();
                      _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
                      _dtSet = new DataSet();
                      _sqlDataAdapter.Fill(_dtSet);
                      gridEmpleado.DataSource = _dtSet;*/
                      //    gridEmpleado.DataBind();
                  }
                  catch (Exception ex)
                  {
                      MessageBox.Show("The Error is " + ex);
                  }
                  finally
                  {
                      dataConnection.Close();
                      dataConnection.Dispose();
                  }
























        //          string Conexion = @"Data Source=FISICA\MSSQLSERVER2014;Initial Catalog=FormCrud;Integrated Security=True";
        //          SqlConnection dataConnection = new SqlConnection(Conexion);
        //          try
        //          {


        //              dataConnection.Open();
        //              SqlCommand cmd = new SqlCommand("Sp_GridCrud", dataConnection);
        //              cmd.CommandType = CommandType.StoredProcedure;
        //              cmd.Parameters.Add("@Event", SqlDbType.VarChar, 10).Value = "Select";


        //              SqlDataAdapter da = new SqlDataAdapter(cmd);
        //              DataTable dt = new DataTable();
        //              da.Fill(dt);
        //              dataConnection.Close();
        //              gridEmpleado.DataSource = dt;

        //              /*

        //              SqlDataReader reader;



        //              CreateConnection();
        //              OpenConnection();
        //              _sqlCommand.CommandText = "Sp_GridCrud";
        //              _sqlCommand.CommandType = CommandType.StoredProcedure;
        //              _sqlCommand.Parameters.AddWithValue("@Event", "Select");
        //              reader = _sqlCommand.ExecuteReader();
        //              _sqlDataAdapter = new SqlDataAdapter(_sqlCommand);
        //              _dtSet = new DataSet();
        //              _sqlDataAdapter.Fill(_dtSet);
        //              gridEmpleado.DataSource = _dtSet;*/
        //              //    gridEmpleado.DataBind();
        //          }
        //          catch (Exception ex)
        //          {
        //              MessageBox.Show("The Error is " + ex);
        //          }
        //          finally
        //          {
        //              dataConnection.Close();
        //              dataConnection.Dispose();
        //          }
           }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void cboTratamiento_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadTratamientoAsignado();
        }
    }
}
