using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Caixa
    {
        private int numero;
        private string etiqueta;
        private int id;
        private string cor;

        public int Id { get => id; set => id = value; }
        public int Numero { get => numero; set => numero = value; }
        public string Cor { get => cor; set => cor = value; }
        public string Etiqueta { get => etiqueta; set => etiqueta = value; }

        public Caixa()
        {
            id = GeradorId.GerarIdCaixa();
        }

        public Caixa(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = " ";

            if (string.IsNullOrEmpty(cor))
                resultadoValidacao += "O campo Cor é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "CAIXA_VALIDA";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Caixa caixa = (Caixa)obj;

            if (id == caixa.id)
                return true;
            else
                return false;
        }
    }
}
