using System;
using System.Collections.Generic;
using System.Text;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
        public class ControladorAmiguinho : ControladorBase
        {           
            public string RegistrarAmiguinho(int id, string nome, string nomeResponsavel,
                int telefone, string cidade)
            {
                Amiguinho amiguinho;

                int posicao = 0;

                if (id == 0)
                {
                    amiguinho = new Amiguinho();
                    posicao = ObterPosicaoVaga();
                }
                else
                {
                    amiguinho = (Amiguinho)registros[posicao];
                    posicao = ObterPosicaoOcupada(amiguinho);
                }

                 amiguinho.Nome = nome;
                 amiguinho.NomeResponsavel = nomeResponsavel;
                 amiguinho.Telefone = telefone;
                 amiguinho.Cidade = cidade;


            string resultadoValidacao = amiguinho.Validar();

                if (resultadoValidacao == "AMIGUINHO_VALIDO")
                    registros[posicao] = amiguinho;

                return resultadoValidacao;
            }

            public Amiguinho SelecionarAmiguinhoPorId(int id)
            {
                return (Amiguinho)SelecionarRegistroPorId(new Amiguinho(id));
            }

            public bool ExcluirAmiguinho(int idSelecionado)
            {
                return ExcluirRegistro(new Amiguinho(idSelecionado));
            }

            public Amiguinho[] SelecionarTodosAmiguinhos()
            {
                Amiguinho[] amiguinhosAux = new Amiguinho[QtdRegistrosCadastrados()];

                Array.Copy(SelecionarTodosRegistros(), amiguinhosAux, amiguinhosAux.Length);

                return amiguinhosAux;
            }
        }
    
}
