using System;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaAmiguinho : TelaBase, ICadastravel
    {
        private ControladorAmiguinho controladorAmiguinho;
        public TelaAmiguinho(ControladorAmiguinho controlador)
            : base("Cadastro de Amiguinhos")
        {
            controladorAmiguinho = controlador;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo um novo Amiguinho...");

            bool conseguiuGravar = GravarAmiguinho(0);

            if (conseguiuGravar)
                ApresentarMensagem("Amiguinho registrado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar registrar o amiguinho", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando um Amiguinho...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do amiguinho que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarAmiguinho(id);

            if (conseguiuGravar)
                ApresentarMensagem("Amiguinho editado com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar o amiguinho", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo um amiguinho...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número do amiguinho que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorAmiguinho.ExcluirAmiguinho(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Amiguinho excluído com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir o amiguinho", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando os amiguinhos...");

            string configuracaColunasTabela = "{0,-10} | {1,-55} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Amiguinho[] amiguinhos = controladorAmiguinho.SelecionarTodosAmiguinhos();

            if (amiguinhos.Length == 0)
            {
                ApresentarMensagem("Nenhum amiguinho cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < amiguinhos.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   amiguinhos[i].Id, amiguinhos[i].Nome, amiguinhos[i].NomeResponsavel, amiguinhos[i].Telefone, amiguinhos[i].Cidade);
            }
        }

        public string ObterOpcao()
        {
            Console.WriteLine("==================Registro==================");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=                 Digite:                  =");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=       1 para inserir novo amiguinho      =");
            Console.WriteLine("=       2 para visualizar amiguinhos       =");
            Console.WriteLine("=       3 para editar um amiguinho         =");
            Console.WriteLine("=       4 para excluir um amiguinho        =");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=            S para sair                   =");
            Console.WriteLine("=                                          =");
            Console.WriteLine("============================================");

            string opcao = Console.ReadLine();

            return opcao;
        }

        #region métodos privados
        private static void MontarCabecalhoTabela(string configuracaoColunasTabela)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine(configuracaoColunasTabela, "Id", "Nome", "Nome do Responsavel", "Telefone", "Cidade");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarAmiguinho(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o nome do amiguinho: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o nome do Responsavel do amiguinho: ");
            string nomeResponsavel = Convert.ToString(Console.ReadLine());

            Console.Write("Digite o telefone do amiguinho: ");
            int telefone = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a cidade do amiguinho: ");
            string cidade = Console.ReadLine();

            resultadoValidacao = controladorAmiguinho.RegistrarAmiguinho(
                id, nome, nomeResponsavel, telefone, cidade);

            if (resultadoValidacao != "AMIGUINHO_VALIDO")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        #endregion
    }
}
