using ClubeDaLeitura.ConsoleApp.Controladores;
using System;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaPrincipal : TelaBase
    {
        private readonly ControladorAmiguinho controladorAmiguinho;
        private readonly ControladorCaixa controladorCaixa;
        private readonly ControladorEmprestimo controladorEmprestimo;
        private readonly ControladorRevista controladorRevista;        

        public TelaPrincipal(ControladorAmiguinho ctlrAmiguinho) : base("Tela Principal")
        {
            controladorAmiguinho = ctlrAmiguinho;            
        }        

        public ICadastravel ObterOpcao()
        {
            ConfigurarTela("===============Escolha uma opção===============");

            ICadastravel telaSelecionada = null;
            string opcao;
            do
            {
                Console.WriteLine("=================Menu Inicial==================");
                Console.WriteLine("=                                             =");
                Console.WriteLine("=                   Digite:                   =");
                Console.WriteLine("=                                             =");
                Console.WriteLine("=      1 para o Cadastro de Amiguinhos        =");
                Console.WriteLine("=      2 para o Cadastro de Caixas            =");
                Console.WriteLine("=      3 para o Cadastro de Emprestimo        =");
                Console.WriteLine("=      4 para o Cadastro de Revista           =");
                Console.WriteLine("=                                             =");
                Console.WriteLine("=               S para Sair                   =");
                Console.WriteLine("=                                             =");
                Console.WriteLine("===============================================");

                opcao = Console.ReadLine();

                if (opcao == "1")
                    telaSelecionada = new TelaAmiguinho(controladorAmiguinho);

                else if (opcao == "2")
                    telaSelecionada = new TelaCaixa(controladorCaixa);

                else if (opcao == "3")
                    telaSelecionada = new TelaEmprestimo(controladorEmprestimo);

                else if (opcao == "4")
                    telaSelecionada = new TelaRevista(controladorRevista);

                else if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    telaSelecionada = null;

            } while (OpcaoInvalida(opcao));

            return telaSelecionada;
        }

        private bool OpcaoInvalida(string opcao)
        {
            if (opcao != "1" && opcao != "2" && opcao != "3" && opcao != "S" && opcao != "s")
            {
                ApresentarMensagem("Opção inválida", TipoMensagem.Erro);
                return true;
            }
            else
                return false;
        }
    }
}
