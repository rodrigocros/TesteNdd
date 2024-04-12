using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TesteNdd.application.ViewModel
{
    public class UserViewModel
    {
        public UserViewModel(Guid id,string nome, string cpf, string sexo, string telefone, string email, DateTime dataNascimento, string observacao)
        {

            Id = id;
            Nome = nome;
            Cpf = cpf;
            Sexo = sexo;
            Telefone = telefone;
            Email = email;
            DataNascimento = dataNascimento;
            Observacao = observacao;
        }

        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public string Cpf { get; private set; }
        public string Sexo { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public string Observacao { get; private set; }
    }
}
