using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;
using System.Web.Script.Serialization;
using System.Windows.Forms;

namespace BuscaCEP
{
    public partial class frmBuscaCEP : Form
    {
        public frmBuscaCEP()
        {
            InitializeComponent();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                string cep = String.Join("", System.Text.RegularExpressions.Regex.Split(txtCEP.Text, @"[^\d]"));

                if (!string.IsNullOrEmpty(cep))
                {
                    string urlBusca = @"https://viacep.com.br/ws/" + cep + "/json";
                    string respJson = string.Empty;

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlBusca);

                    using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
                    using (Stream stream = response.GetResponseStream())
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        respJson = reader.ReadToEnd();
                    }

                    var jss = new JavaScriptSerializer();
                    var objCEP = jss.Deserialize<Dictionary<string, dynamic>>(respJson);

                    txtEstado.Text = objCEP["uf"];
                    txtCidade.Text = objCEP["localidade"];
                    txtBairro.Text = objCEP["bairro"];
                    txtRua.Text = objCEP["logradouro"];
                }
                else
                {
                    if (!string.IsNullOrEmpty(txtCEP.Text))
                    {
                        MessageBox.Show("O campo de CEP deve conter apenas números!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        MessageBox.Show("O campo de número do CEP está vazio!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }

                    txtCEP.Focus();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("CEP inválido!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            txtCEP.Text = string.Empty;
            txtEstado.Text = string.Empty;
            txtCidade.Text = string.Empty;
            txtBairro.Text = string.Empty;
            txtRua.Text = string.Empty;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtCEP.Text) && !string.IsNullOrEmpty(txtEstado.Text) && !string.IsNullOrEmpty(txtCidade.Text) && !string.IsNullOrEmpty(txtBairro.Text) && !string.IsNullOrEmpty(txtRua.Text))
            {
                business.Cep obCep = new business.Cep();
                model.Cep omCep = new model.Cep();

                omCep.NrCEP = txtCEP.Text;
                omCep.Estado = txtEstado.Text;
                omCep.Cidade = txtEstado.Text;
                omCep.Bairro = txtBairro.Text;
                omCep.Rua = txtRua.Text;

                DataTable dtCEP = obCep.Lista(omCep);
                if (dtCEP != null)
                {
                    if (dtCEP.Rows.Count == 0)
                    {
                        obCep.Salvar(omCep);

                        if (string.IsNullOrEmpty(obCep.sMensagem))
                        {
                            txtCEP.Text = string.Empty;
                            txtEstado.Text = string.Empty;
                            txtCidade.Text = string.Empty;
                            txtBairro.Text = string.Empty;
                            txtRua.Text = string.Empty;
                            MessageBox.Show("Cadastro efetuado com sucesso!", "Sucesso!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Ops, houve um erro no salvamento do CEP!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("O endereço já existe em nosso cadastro! Favor informar outro CEP", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
                else
                {
                    MessageBox.Show("Ops, houve um erro no salvamento do CEP!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Um ou mais campos do endereço estão vazios! Por favor pesquisar novamente.", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
