using System;
using System.Data;

namespace BuscaCEP.business
{
    public class Cep
    {
        public string sMensagem = string.Empty;

        public DataTable Lista(model.Cep omCEP)
        {
            try
            {
                sMensagem = null;

                if (string.IsNullOrEmpty(omCEP.NrCEP))
                {
                    sMensagem = "CEP não informado";
                    return new DataTable();
                }

                using (data.Cep odCEP = new data.Cep())
                {
                    DataTable tableDados = odCEP.Listar(omCEP);
                    sMensagem = odCEP.sMensagem;
                    return tableDados;
                }
            }
            catch (Exception ex)
            {
                sMensagem = ex.Message.ToString();
                return new DataTable();
            }
        }

        public Int64 Salvar(model.Cep omCEP)
        {
            try
            {
                sMensagem = null;
                using (data.Cep odCEP = new data.Cep())
                {
                    Int64 nIdCEP = odCEP.Salvar(omCEP);
                    sMensagem = odCEP.sMensagem;
                    return nIdCEP;
                }
            }
            catch (Exception ex)
            {
                sMensagem = ex.Message;
                return -1;
            }
        }
    }
}
