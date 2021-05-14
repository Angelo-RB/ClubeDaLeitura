using System;
using ClubeDaLeitura.ConsoleApp.Telas;
using ClubeDaLeitura.ConsoleApp.Controladores;

namespace ClubeDaLeitura.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            object a = new TelaAmiguinho(null);

            TelaBase b = new TelaAmiguinho(null);

            TelaAmiguinho c = new TelaAmiguinho(null);

            ICadastravel d = new TelaAmiguinho(null);

            ControladorAmiguinho ctrlAmiguinho = new ControladorAmiguinho();

            ControladorCaixa ctrlCaixa = new ControladorCaixa();

            TelaPrincipal telaPrincipal = new TelaPrincipal(ctrlAmiguinho);

            while (true)
            {
                ICadastravel telaSelecionada = telaPrincipal.ObterOpcao();

                if (telaSelecionada == null)
                    break;

                Console.Clear();

                if (telaSelecionada is TelaBase)
                    Console.WriteLine(((TelaBase)telaSelecionada).Titulo); Console.WriteLine();

                string opcao = telaSelecionada.ObterOpcao();

                if (opcao.Equals("s", StringComparison.OrdinalIgnoreCase))
                    continue;

                if (opcao == "1")
                    telaSelecionada.InserirNovoRegistro();

                else if (opcao == "2")
                {
                    telaSelecionada.VisualizarRegistros();
                    Console.ReadLine();
                }

                else if (opcao == "3")
                    telaSelecionada.EditarRegistro();

                else if (opcao == "4")
                    telaSelecionada.ExcluirRegistro();

                Console.Clear();
            }
        }
    }
}
