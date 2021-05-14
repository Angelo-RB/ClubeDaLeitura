using System;
using System.Collections.Generic;
using System.Text;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
    public class Revista
    {
        private int id;
        private string tipoColecao;
        private int numeroEdicao;
        private int anoRevista;
        private int idCaixa;

        public int Id { get => id; set => id = value; }
        public string TipoColecao { get => tipoColecao; set => tipoColecao = value; }
        public int NumeroEdicao { get => numeroEdicao; set => numeroEdicao = value; }
        public int AnoRevista { get => anoRevista; set => anoRevista = value; }
        public int IdCaixa { get => idCaixa; set => idCaixa = value; }

        public Revista()
        {
            id = GeradorId.GerarIdRevista();
        }

        public Revista(int idSelecionado)
        {
            id = idSelecionado;
        }

        public string Validar()
        {
            string resultadoValidacao = " ";

            if (string.IsNullOrEmpty(tipoColecao))
                resultadoValidacao += "O campo Tipo coleção é obrigatório \n";

            if (string.IsNullOrEmpty(resultadoValidacao))
                resultadoValidacao = "REVISTA_VALIDA";

            return resultadoValidacao;
        }

        public override bool Equals(object obj)
        {
            Revista revista = (Revista)obj;

            if (id == revista.id)
                return true;
            else
                return false;
        }
    }
}
