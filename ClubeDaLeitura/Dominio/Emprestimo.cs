using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Emprestimo : GeradorId
    {
        public int id;
        public Amiguinho amiguinho;
        public Revista revista;
        public DateTime data;
        public DateTime dataDevolucao;
        public bool emprestimoAberto;


        public Emprestimo()
        {
            id = GerarIdEmprestimo();
            emprestimoAberto = true;
        }

        public Emprestimo(int id)
        {
            this.id = id;
            VerificarStatusEmprestimo();
        }

        public string Status
        {
            get
            {
                if (emprestimoAberto)
                    return "Aberto";

                return "Fechado";
            }
        }

        public override bool Equals(object obj)
        {
            Emprestimo emp = (Emprestimo)obj;

            if (emp != null && emp.id == this.id)
                return true;

            return false;
        }

        public string Validar()
        {
            string resultadoValidacao = "";

            if (amiguinho == null)
                resultadoValidacao += "O ID do amigo informado não existe\n";

            if (revista == null)
                resultadoValidacao += "O ID da revista informada não existe\n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "EMPRESTIMO_VALIDO";

            return resultadoValidacao;
        }

        private void VerificarStatusEmprestimo()
        {
            if (DateTime.Now > dataDevolucao)
                emprestimoAberto = false;
        }
    }
}