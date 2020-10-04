using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace BuscaCEP.data
{
    public class Cep : IDisposable
    {
        public string sMensagem = string.Empty;
        SqlConnection strConn = new SqlConnection(@"Data Source=robbusqlserver.database.windows.net,1433;Initial Catalog=RobbuProjects;Persist Security Info=True;User ID=ROBBU;Password=!q2w3e4r");

        public DataTable Listar(model.Cep objCEP)
        {
            StringBuilder sComando = new StringBuilder();

            try
            {
                sComando.Append(@"Select NrCEP From tbCEP with(nolock) Where NrCEP = @NrCEP");

                using (SqlCommand sqlComando = new SqlCommand(sComando.ToString(), strConn))
                {
                    if (!string.IsNullOrEmpty(objCEP.NrCEP))
                    { sqlComando.Parameters.AddWithValue("@NrCEP", objCEP.NrCEP); }
                    else
                    {
                        sqlComando.Parameters.AddWithValue("@NrCEP", string.Empty);
                    }

                    strConn.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter sqlda = new SqlDataAdapter(sqlComando);
                    sqlda.Fill(ds);
                    strConn.Close();
                    return ds.Tables[0];
                }
            }
            catch (Exception oException)
            {
                sMensagem = oException.Message;
                return null;
            }
        }

        public Int64 Salvar(model.Cep objCEP)
        {
            int IdRetorno = -1;

            try
            {
                StringBuilder sComando = new StringBuilder();

                sComando.Append("insert into tbCEP (\n");
                sComando.Append("	 NrCEP\n");
                sComando.Append("	,Estado\n");
                sComando.Append("	,Cidade\n");
                sComando.Append("	,Bairro\n");
                sComando.Append("	,Rua\n");
                sComando.Append(")\n");
                sComando.Append("values (\n");
                sComando.Append("	 @NrCEP\n");
                sComando.Append("	,@Estado\n");
                sComando.Append("	,@Cidade\n");
                sComando.Append("	,@Bairro\n");
                sComando.Append("	,@Rua\n");
                sComando.Append(")\n");

                using (SqlCommand sqlComando = new SqlCommand(sComando.ToString(), strConn))
                {
                    if (!string.IsNullOrEmpty(objCEP.NrCEP))
                    { sqlComando.Parameters.AddWithValue("@NrCEP", objCEP.NrCEP); }
                    else
                    {
                        sqlComando.Parameters.AddWithValue("@NrCEP", string.Empty);
                    }

                    if (!string.IsNullOrEmpty(objCEP.Estado))
                    { sqlComando.Parameters.AddWithValue("@Estado", objCEP.Estado); }
                    else
                    {
                        sqlComando.Parameters.AddWithValue("@Estado", string.Empty);
                    }

                    if (!string.IsNullOrEmpty(objCEP.Cidade))
                    { sqlComando.Parameters.AddWithValue("@Cidade", objCEP.Cidade); }
                    else
                    {
                        sqlComando.Parameters.AddWithValue("@Cidade", string.Empty);
                    }

                    if (!string.IsNullOrEmpty(objCEP.Bairro))
                    { sqlComando.Parameters.AddWithValue("@Bairro", objCEP.Bairro); }
                    else
                    {
                        sqlComando.Parameters.AddWithValue("@Bairro", string.Empty);
                    }

                    if (!string.IsNullOrEmpty(objCEP.Rua))
                    { sqlComando.Parameters.AddWithValue("@Rua", objCEP.Rua); }
                    else
                    {
                        sqlComando.Parameters.AddWithValue("@Rua", string.Empty);
                    }

                    strConn.Open();
                    IdRetorno = sqlComando.ExecuteNonQuery();
                    strConn.Close();
                }

                return IdRetorno;
            }
            catch (Exception ex)
            {
                sMensagem = ex.Message;
                return -1;
            }
        }

        void IDisposable.Dispose()
        {
            sMensagem = null;
        }
    }
}
