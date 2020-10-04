using System;
using System.Data;
using static BuscaCEP.model.CamposSQL;

namespace BuscaCEP.model
{
    public class Cep
    {
        private Int64 _IdCEP = -1;
        private string _NrCEP = string.Empty;
        private string _Estado = string.Empty;
        private string _Cidade = string.Empty;
        private string _Bairro = string.Empty;
        private string _Rua = string.Empty;

        public Int64 IdCEP
        {
            get { return _IdCEP; }
            set { _IdCEP = value; }
        }

        public string NrCEP
        {
            get { return _NrCEP; }
            set { _NrCEP = value; }
        }
        public string Estado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        public string Cidade
        {
            get { return _Cidade; }
            set { _Cidade = value; }
        }
        public string Bairro
        {
            get { return _Bairro; }
            set { _Bairro = value; }
        }
        public string Rua
        {
            get { return _Rua; }
            set { _Rua = value; }
        }
        public Cep(IDataReader oIDataReader)
        {
            SetarCampos.RetonarValor(oIDataReader, this);
        }

        public Cep()
        {
        }
    }
}
