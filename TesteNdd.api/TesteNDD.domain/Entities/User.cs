using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteNDD.domain.Entities
{
    public class User : BaseEntity
    {
        public User(string nome, string cPF, string sexo, string telefone, string email, DateTime dataNascimento, string observacao)
        {
            Nome = nome;
            CPF = cPF;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            Observacao = observacao;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Sexo { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Observacao { get; private set; } 

        public void Update(string telefone, string email, string observacao)
        {
            Telefone = telefone;
            Email = email;
            Observacao = observacao;
        }
    }
}