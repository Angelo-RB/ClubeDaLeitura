using System;
using System.Collections.Generic;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorRevista : ControladorBase
    {

        public string RegistrarRevista(int id, string tipoColecao, int numeroEdicao,
            int anoRevista, int idCaixa)
        {
            Revista revista;

            int posicao = 0;

            if (id == 0)
            {
                revista = new Revista();
                posicao = ObterPosicaoVaga();
            }
            else
            {
                revista = (Revista)registros[posicao];
                posicao = ObterPosicaoOcupada(revista);
            }

            revista.TipoColecao = tipoColecao;
            revista.NumeroEdicao = numeroEdicao;
            revista.AnoRevista = anoRevista;
            revista.IdCaixa = idCaixa;


            string resultadoValidacao = revista.Validar();

            if (resultadoValidacao == "REVISTA_VALIDO")
                registros[posicao] = revista;

            return resultadoValidacao;
        }

        public Revista SelecionarRevistaPorId(int id)
        {
            return (Revista)SelecionarRegistroPorId(new Revista(id));
        }

        public bool ExcluirRevista(int idSelecionado)
        {
            return ExcluirRegistro(new Revista(idSelecionado));
        }

        public Revista[] SelecionarTodasRevistas()
        {
            Revista[] revistasAux = new Revista[QtdRegistrosCadastrados()];

            Array.Copy(SelecionarTodosRegistros(), revistasAux, revistasAux.Length);

            return revistasAux;
        }
    }

}
