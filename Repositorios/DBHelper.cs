using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PPAI_DSI.Repositorios
{
    public class DBHelper
    {
        private string string_conexion;
        private static DBHelper instance = new DBHelper();

        //declaro variable que almacerá un objeto <cmd> del tipo <SqlConnection>
        private SqlConnection _conexion;

        //declaro variable que almacerá un objeto <cmd> del tipo <SqlCommand>
        private SqlCommand _cmd;

        private DBHelper()
        {

            // string_conexion_local = "Data Source=DESKTOP-LBVUJ09\\SQLEXPRESS;Initial Catalog=BTSPAVI3K220201;Integrated Security=True;MultipleActiveResultSets=True";
            string_conexion = "Data Source=200.69.137.167,11333;Initial Catalog=PAVI3k2BTS_2022;User ID=PAVI3k2BTS_2022;Password=PAVI3k2BTS#2022";
        }

        public static DBHelper GetDBHelper() //Solo puede existir una instancia del DBHelper, y mediante este metodo se accede a los demas. Implementacion del Patron Singleton
        {
            if (instance == null)
                instance = new DBHelper();
            return instance;
        }

        /// Resumen:
        ///     Se utiliza para sentencias SQL del tipo “Select”. Recibe por valor una sentencia sql como string
        /// Devuelve:
        ///      un objeto de tipo DataTable con el resultado de la consulta
        public DataTable ConsultaSQL(string strSql)
        {
            try
            {
                SqlConnection cnn = new SqlConnection(); //Permite la conexion con Servidor BD
                SqlCommand cmd = new SqlCommand(); //Permite armar la consulta SQL
                DataTable tabla = new DataTable(); //Para almacenar el resultado de la consulta SQL en forma de tabla
                cnn.ConnectionString = string_conexion; //Seteo el string de conexion
                cnn.Open(); //Inicia la conexion y llega a la BD
                cmd.Connection = cnn; //Le dice al comando q utilice la conexion del cnn
                cmd.CommandType = CommandType.Text; //Indicamos el tipo de consulta q le pasamos
                cmd.CommandText = strSql; //Indico cual es la consulta q quiero q ejecute en la BD, ingresada por parametro
                tabla.Load(cmd.ExecuteReader()); //Ejecuta la consulta y trae los resultados q se guardan en el datatable
                this.CloseConnection(cnn); //CERRAR LA CONEXION, utilizando el metodo y pasando por parametro la conexion cnn
                return tabla;
            }
            catch (Exception ex)
            {
                throw new ApplicationException("Ocurrio un problema desconocido con el almacenamento de datos");
            }

        }

        /// Resumen:
        ///     Se utiliza para sentencias SQL del tipo “Insert/Update/Delete”. Recibe por valor una sentencia sql como string
        /// Devuelve:
        ///      un valor entero con el número de filas afectadas por la sentencia ejecutada
        public int EjecutarSQL(string strSql)
        {
            int afectadas = 0;
            SqlConnection cnn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            cnn.ConnectionString = string_conexion;
            cnn.Open();
            cmd.Connection = cnn;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strSql;
            afectadas = cmd.ExecuteNonQuery();
            this.CloseConnection(cnn);
            return afectadas;
        }


        private void CloseConnection(SqlConnection cnn)
        {
            if (cnn.State == ConnectionState.Open) //Si el estado de mi conexion es abierto, entra al if y cierra la conexion 
            {
                cnn.Close();
                cnn.Dispose();
            }
        }

        public void CloseConnection()
        {
            if (_conexion.State == ConnectionState.Open)
            {
                //cierra la conexión con la base de datos
                _conexion.Close();
            }
        }

        public void Conectar()
        {
            _conexion = new SqlConnection();
            _cmd = new SqlCommand();
            //asigan al objeto <conexion> la cadena de conexion
            _conexion.ConnectionString = string_conexion;
            //agrega la conexion (se crea el pipe entre la aplicación y la base de datos)
            _conexion.Open();
            //se comunica al objeto <cmd> sobre que conexion debe trabajar
            _cmd.Connection = _conexion;
            //se establece el tipo de comando que va ha ejecutar
            _cmd.CommandType = CommandType.Text;
        }

        public SqlTransaction IniciarTransaccion()
        {
            Conectar();
            var transaccion = _conexion.BeginTransaction();
            _cmd.Transaction = transaccion;
            return transaccion;
        }

        public int EjecutarTransaccionSQL(string strSql)
        {
            var id = 0;
            _cmd.CommandText = strSql;

            if (_cmd.ExecuteNonQuery() > 0)
            {
                string consultaGetId = "Select @@Identity";
                _cmd.CommandText = consultaGetId;
                var idDevuelto = _cmd.ExecuteScalar();
                //id = int.Parse(idDevuelto?.ToString());
                //id = int.Parse(null);
                if (idDevuelto != null)
                    id = int.Parse(idDevuelto.ToString());

            }
            return id;
        }

        public void EjecutarUpdateTransaccionSQL(string strSql)
        {
            _cmd.CommandText = strSql;
            _cmd.ExecuteNonQuery();
        }

        public DataTable ConsultaDuranteTransaccion(string comando)
        {

            _cmd.CommandText = comando;
            //instancia un objeto <tabla> del tipo DataTable
            DataTable tabla = new DataTable();

            tabla.Load(_cmd.ExecuteReader());

            //devuelve el valor calculado a través de la función
            return tabla;
        }
    }
}
