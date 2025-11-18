using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjADONET
{
    public class Pessoa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public DateOnly DataNascimento { get; private set; }
        public List<Telefone> Telefones { get; private set; }
        public List<Endereco> Enderecos { get; private set; }

        public Pessoa(string nome, string cpf, DateOnly dataNascimento)
        {
            Nome = nome;
            Cpf = cpf;
            DataNascimento = dataNascimento;
            this.Telefones = new List<Telefone>();
            this.Enderecos = new List<Endereco>();
        }


        public void setId(int id)
        {
            Id = id;
        }
        public override string? ToString()
        {
                string dados =  $"Id: {this.Id} \n" +
                $"Nome: {this.Nome}\n" +
                $"Cpf: {this.Cpf}\n" +
                $"Data Nascimento: {this.DataNascimento}\n";

                if (this.Telefones.Count > 0)
                {
                    foreach (Telefone t in this.Telefones)
                    {
                        dados += $"{t.Tipo}: {t.ToString()}";
                    }
                }
                else{

                    dados += $"Telefone: - ";
                }

                 int enderecos = 1;
                if (this.Enderecos.Count > 0)
                {
                    foreach (Endereco e in this.Enderecos)
                    {
                        dados += $" Endereço {enderecos}: {e.ToString()}";
                        enderecos++;
                    }
                }
                else
                {

                    dados += $"Endereço: - ";
                }

                return dados;
        }
    }
}
