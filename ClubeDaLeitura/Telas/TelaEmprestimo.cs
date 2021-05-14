using System;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaEmprestimo : TelaBase
    {
        private readonly ControladorEmprestimo ctrlEmprestimo;
        private readonly TelaRevista telaRevista;
        private readonly TelaAmiguinho telaAmigo;

        public TelaEmprestimo(ControladorEmprestimo ctrlEmprestimo,
            TelaRevista telaRevista, TelaAmiguinho telaAmigo) : base("==========Cadastro de Empréstimos==========")
        {
            this.ctrlEmprestimo = ctrlEmprestimo;
            this.telaRevista = telaRevista;
            this.telaAmigo = telaAmigo;
        }

        public string ObterOpcao()
        {
            Console.WriteLine("==================Registro==================");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=                 Digite:                  =");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=       1 para inserir novo emprestimo     =");
            Console.WriteLine("=       2 para visualizar emprestimo       =");
            Console.WriteLine("=       3 para editar um emprestimo        =");
            Console.WriteLine("=       4 para excluir um emprestimo       =");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=            S para sair                   =");
            Console.WriteLine("=                                          =");
            Console.WriteLine("============================================");

            string Opcao = Console.ReadLine();

            return Opcao;
        }

        public void InserirNovoRegistro(int id)
        {
            VisualizarRegistros();

            Console.Write("Digite o ID do amiguinho emprestando: ");
            int idAmiguinhoEmprestimo = Convert.ToInt32(Console.ReadLine());

            telaRevista.VisualizarRegistros();

            Console.Write("Digite o ID da revista a ser emprestada: ");
            int idRevistaEmprestimo = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a data de abertura: ");
            DateTime dataEmprestimo = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Digite a data de devolução: ");
            DateTime dataDevolucao = Convert.ToDateTime(Console.ReadLine());

            string resultadoValidacao = ctrlEmprestimo.RegistrarEmprestimo(id, idAmiguinhoEmprestimo,
                idRevistaEmprestimo, dataEmprestimo, dataDevolucao);

            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
                ApresentarMensagem("Registro feito com sucesso!", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
            }

            Console.Clear();
        }

        public void FecharEmprestimo()
        {
            ConfigurarTela("Fechando um empréstimo...");

            VisualizarEmprestimosAbertos();

            Console.Write("Digite o ID do empréstimo que deseja fechar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuFechar = ctrlEmprestimo.FecharEmprestimo(new Emprestimo(id));

            if (conseguiuFechar)
                ApresentarMensagem("Empréstimo fechado com sucesso!", TipoMensagem.Sucesso);
            else
                ApresentarMensagem("Falha ao tentar fechar o empréstimo!", TipoMensagem.Erro);
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando registros...");

            MontarCabecalhoTabela();

            Emprestimo[] emprestimos = ctrlEmprestimo.SelecionarTodosEmprestimos();

            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3, -16} | {4, -16}", emprestimo.id, emprestimo.amiguinho.Nome,
                    emprestimo.revista.TipoColecao, emprestimo.data, emprestimo.dataDevolucao);

                Console.WriteLine();
            }

            if (emprestimos.Length == 0)
                ApresentarMensagem("Nenhum registro encontrado!", TipoMensagem.Atencao);

            Console.ReadLine();
        }
        public void VisualizarEmprestimosAbertos()
        {
            MontarCabecalhoTabela();

            Emprestimo[] emprestimos = ctrlEmprestimo.SelecionarEmprestimosEmAberto();

            foreach (Emprestimo emprestimo in emprestimos)
            {
                Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3, -16} | {4, -16}", emprestimo.id, emprestimo.amiguinho.Nome,
                    emprestimo.revista.TipoColecao, emprestimo.data, emprestimo.dataDevolucao);

                Console.WriteLine();
            }

            if (emprestimos.Length == 0)
                ApresentarMensagem("Nenhum registro encontrado!", TipoMensagem.Atencao);

            Console.ReadLine();
        }       

        public void MontarCabecalhoTabela()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("{0,-3} | {1,-20} | {2,-20} | {3, -16} | {4, -16}", "Id", "Amiguinho", "Revista",
                "Data Empréstimo", "Data Devolução");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }
    }
}