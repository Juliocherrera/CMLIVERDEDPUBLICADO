using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APPLIVERDEDCM.Models
{
    public class ModelFact

    {
        public string uuid { get; set; }
        public string motivo { get; set; }
        public string status { get; set; }
        public string xmlDownload { get; set; }
        public string folio { get; set; }
        public string fecha { get; set; }
        public string serie { get; set; }
        public string rfc { get; set; }
        public string ord_hdrnumber { get; set; }



        public ModelFact()
        {

        }


        public void getMercancias(string Ai_orden, string Av_cmd_code, string Av_cmd_description, string Af_weight, string Av_weightunit, string Af_count, string Av_countunit)
        {
            string cadena2 = @"Data source=172.24.16.112; Initial Catalog=TMWSuite; User ID=sa; Password=tdr9312;Trusted_Connection=false;MultipleActiveResultSets=true";
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(cadena2))
            {
                using (SqlCommand selectCommand = new SqlCommand("INSERT INTO IMPORTMERLIVERDED(Ai_orden,Av_cmd_code,Av_cmd_description,Af_weight,Av_weightunit,Af_count,Av_countunit)VALUES(@Ai_orden,@Av_cmd_code,@Av_cmd_description,@Af_weight,@Av_weightunit,@Af_count,@Av_countunit)", connection))
                {
                    selectCommand.Parameters.AddWithValue("@Ai_orden", Ai_orden);
                    selectCommand.Parameters.AddWithValue("@Av_cmd_code", Av_cmd_code);
                    selectCommand.Parameters.AddWithValue("@Av_cmd_description", Av_cmd_description);
                    selectCommand.Parameters.AddWithValue("@Af_weight", Af_weight);
                    selectCommand.Parameters.AddWithValue("@Av_weightunit", Av_weightunit);
                    selectCommand.Parameters.AddWithValue("@Af_count", Af_count);
                    selectCommand.Parameters.AddWithValue("@Av_countunit", Av_countunit);

                    using (new SqlDataAdapter(selectCommand))
                    {
                        try
                        {
                            selectCommand.Connection.Open();
                            selectCommand.ExecuteNonQuery();
                        }
                        catch (SqlException ex)
                        {
                            string message = ex.Message;
                        }
                    }
                }
            }
        }


        public void GetMerc(string Ai_orden, string Av_cmd_code, string Av_cmd_description, string Af_weight, string Av_weightunit, string Af_count, string Av_countunit)
        {
            string cadena2 = @"Data source=172.24.16.112; Initial Catalog=TMWSuite; User ID=sa; Password=tdr9312;Trusted_Connection=false;MultipleActiveResultSets=true";
            //DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(cadena2))
            {

                using (SqlCommand selectCommand = new SqlCommand("sp_Obtiene_Stops_Orden_JR", connection))
                {

                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.CommandTimeout = 1000;
                    selectCommand.Parameters.AddWithValue("@Ai_orden", Ai_orden);
                    selectCommand.Parameters.AddWithValue("@Av_cmd_code", Av_cmd_code);
                    selectCommand.Parameters.AddWithValue("@Av_cmd_description", Av_cmd_description);
                    selectCommand.Parameters.AddWithValue("@Af_weight", Af_weight);
                    selectCommand.Parameters.AddWithValue("@Av_weightunit", Av_weightunit);
                    selectCommand.Parameters.AddWithValue("@Af_count", Af_count);
                    selectCommand.Parameters.AddWithValue("@Av_countunit", Av_countunit);

                    try
                    {
                        connection.Open();
                        selectCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

        }
        public void DeleteMerc(string Ai_orden)
        {
            string cadena2 = @"Data source=172.24.16.112; Initial Catalog=TMWSuite; User ID=sa; Password=tdr9312;Trusted_Connection=false;MultipleActiveResultSets=true";
            //DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(cadena2))
            {

                using (SqlCommand selectCommand = new SqlCommand("sp_ordenborrar_mercancias", connection))
                {

                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.CommandTimeout = 1000;
                    selectCommand.Parameters.AddWithValue("@Ai_orden", Ai_orden);
                    try
                    {
                        connection.Open();
                        selectCommand.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        string message = ex.Message;
                    }
                    finally
                    {
                        connection.Close();
                    }
                }
            }

        }
        public DataTable TieneMercancias(string leg)
        {
            string cadena2 = @"Data source=172.24.16.112; Initial Catalog=TMWSuite; User ID=sa; Password=tdr9312;Trusted_Connection=false;MultipleActiveResultSets=true";
            DataTable dataTable = new DataTable();
            using (SqlConnection connection = new SqlConnection(cadena2))
            {
                connection.Open();
                using (SqlCommand selectCommand = new SqlCommand("sp_ordentiene_mercancias", connection))
                {

                    selectCommand.CommandType = CommandType.StoredProcedure;
                    selectCommand.CommandTimeout = 100;
                    selectCommand.Parameters.AddWithValue("@leg", (object)leg);
                    selectCommand.ExecuteNonQuery();
                    using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(selectCommand))
                    {
                        try
                        {
                            //selectCommand.Connection.Open();
                            sqlDataAdapter.Fill(dataTable);
                        }
                        catch (SqlException ex)
                        {
                            connection.Close();
                            string message = ex.Message;
                        }
                    }
                }
            }
            return dataTable;
        }
    }
}
