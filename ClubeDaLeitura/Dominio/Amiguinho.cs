using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Amiguinho
    {
        private int telefone;
        private string cidade;
        private int id;
        private string nome;
        private string nomeResponsavel;

        public int Id { get => id; set => id = value; }
        public int Telefone { get => telefone; set => telefone = value; }
        public string Nome { get => nome; set => nome = value; }
        public string NomeResponsavel { get => nomeResponsavel; set => nomeResponsavel = value; }
        public string Cidade { get => cidade; set => cidade = value; }

        public Amiguinho()
        {
            Id = GeradorId.GerarIdAmiguinho();
        }

        public Amiguinho(int idSelecionado)
        {
            Id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = "  ";

            if (string.IsNullOrEmpty(Nome))
                resultadoValidacao += "O campo Nome é obrigatório \n"; 

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "AMIGUINHO_VALIDO";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Amiguinho amiguinho = (Amiguinho)obj;

            if (Id == amiguinho.Id)
                return true;
            else
                return false;
        }
    }
}
