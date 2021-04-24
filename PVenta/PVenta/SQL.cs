using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Data.SqlClient;

namespace PVenta
{
    public class SQL
    {
        // ************ [ VARIABLES, FUNCIONES Y PARAMETROS DE SQL ] ******************
        // VARIABLE Y UTILES SQL PARA SU USO, CONSULTA Y ACCESO A DB
        public static SqlConnection conSQL = new SqlConnection();
        SqlDataAdapter adaptadorSQL = new SqlDataAdapter();
        DataTable dtablaSQL = new DataTable();
        public static SqlCommand commandoSQL;
        // VARIABLE DE TRANSACCION (USADO PARA REALIZAR COMMITS Y ROLLBACKS - QUERY'S FALLIDAS)
        public static SqlTransaction transaccionSQL;
        // VAIRABLE QUE LLAMA EL APPSETTINGS.JSON
        public string configurationSettings = string.Empty;

        public SQL([FromServices] IConfiguration config)
        {
            configurationSettings = config["ConnectionStrings:SqlConection"];
        }

        // FUNCION GLOBAL DE CONECCION
        public void coneccionSQL()
        {
            try
            {
                conSQL.ConnectionString = configurationSettings;
            }
            catch(Exception e)
            {
                var d = e.ToString();
                throw new Exception();
            }
        }
        // FUNCION QUE LLENA UN COMANDO SQL PARA PARSEAR EL RESULTADO SQL Y LLENA LAS CLASES (OBJETOS)
        public SqlCommand comandoSQL(string query)
        {
            var comando = new SqlCommand(query, conSQL, transaccionSQL);
            return comando;
        }
        // FUNCION QUE GENERA EL CONSTRUCTOR DE LA TRANSACCION (ABRE LA CONEXIÓN E INICIA EL COMANDO)
        public void comandoSQLTrans(string nomtrans)
        {
            coneccionSQL();
            conSQL.Open();
            transaccionSQL = conSQL.BeginTransaction(nomtrans);
        }

        public void Commit()
        {
            transaccionSQL.Commit();
        }

        public void Rollback()
        {
            transaccionSQL.Rollback();
        }

        public void ConClose()
        {
            conSQL.Close();
        }
        // ********************************************************************************
    }
}