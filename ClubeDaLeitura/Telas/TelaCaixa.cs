using System;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaCaixa : TelaBase, ICadastravel
    {
        private ControladorCaixa controladorCaixa;
        public TelaCaixa(ControladorCaixa controlador)
            : base("Cadastro de Caixas")
        {
            controladorCaixa = controlador;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma nova Caixa...");

            bool conseguiuGravar = GravarCaixa(0);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa registrada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar registrar a caixa", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando uma caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarCaixa(id);

            if (conseguiuGravar)
                ApresentarMensagem("Caixa editada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar a caixa", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma caixa...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da caixa que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorCaixa.ExcluirCaixa(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Caixa excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a Caixa", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando as Caixas...");

            string configuracaColunasTabela = "{0,-10} | {1,-20} | {2,-20}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Caixa[] caixas = controladorCaixa.SelecionarTodasCaixas();

            if (caixas.Length == 0)
            {
                ApresentarMensagem("Nenhuma caixa cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < caixas.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   caixas[i].Id, caixas[i].Numero, caixas[i].Cor, caixas[i].Etiqueta);
            }
        }

        public string ObterOpcao()
        {
            Console.WriteLine("==================Registro==================");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=                 Digite:                  =");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=       1 para inserir nova caixa          =");
            Console.WriteLine("=       2 para visualizar caixas           =");
            Console.WriteLine("=       3 para editar uma caixa            =");
            Console.WriteLine("=       4 para excluir uma caixa           =");
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

            Console.WriteLine(configuracaoColunasTabela, "Id", "Número", "cor", "Etiqueta");

            Console.WriteLine("-------------------------------------------------------------------------------------------------------------------");

            Console.ResetColor();
        }

        private bool GravarCaixa(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o número da caixa: ");
            int numero = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite a cor da caixa: ");
            string cor = Convert.ToString(Console.ReadLine());

            Console.Write("Digite a etiqueta da caixa: ");
            string etiqueta = Convert.ToString(Console.ReadLine());

            resultadoValidacao = controladorCaixa.RegistrarCaixa(
                id, numero, cor, etiqueta);

            if (resultadoValidacao != "CAIXA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        #endregion
    }
}
