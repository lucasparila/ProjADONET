using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjADONET
{
    public class Endereco
    {
        public int Id { get; private set; }
        public string Logradouro { get; private set; }
        public int? Numero { get; private set; }
        public string? Complemento { get; private set; }
        public string Bairro { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string Cep {  get; private set; }
        public int PessoaId { get; private set; }

        public Endereco(string logradouro, int? numero, string? complemento, string bairro, string cidade, string estado, string cep, int pessoaId)
        {
            Logradouro = logradouro;
            Numero = numero;
            Complemento = complemento;
            Bairro = bairro;
            Cidade = cidade;
            Estado = estado;
            Cep = cep;
            PessoaId = pessoaId;
        }

        public void setId(int id)
        {
            this.Id = id;
        }

        public override string ToString()
        {
            return "Endereço: " + this.Logradouro +
                    (this.Numero != null ? this.Numero + ", " : "s/n, ") +
                    (this.Complemento != null ? this.Complemento + ", ": "") + 
                    this.Bairro + ", " +
                    this.Cidade + ", " +
                    this.Estado + ", " +
                    this.Cep + "\n";
        }
    }
}
