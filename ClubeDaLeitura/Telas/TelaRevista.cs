using System;
using ClubeDaLeitura.ConsoleApp.Controladores;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Telas
{
    public class TelaRevista : TelaBase, ICadastravel
    {
        private ControladorRevista controladorRevista;
        public TelaRevista(ControladorRevista controlador)
            : base("Cadastro de Revistas")
        {
            controladorRevista = controlador;
        }

        public void InserirNovoRegistro()
        {
            ConfigurarTela("Inserindo uma nova Revista...");

            bool conseguiuGravar = GravarRevista(0);

            if (conseguiuGravar)
                ApresentarMensagem("Revista registrada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar registrar uma Revista", TipoMensagem.Erro);
                InserirNovoRegistro();
            }
        }

        public void EditarRegistro()
        {
            ConfigurarTela("Editando uma Revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja editar: ");
            int id = Convert.ToInt32(Console.ReadLine());

            bool conseguiuGravar = GravarRevista(id);

            if (conseguiuGravar)
                ApresentarMensagem("Revista editada com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar editar a Revista", TipoMensagem.Erro);
                EditarRegistro();
            }
        }

        public void ExcluirRegistro()
        {
            ConfigurarTela("Excluindo uma revista...");

            VisualizarRegistros();

            Console.WriteLine();

            Console.Write("Digite o número da revista que deseja excluir: ");
            int idSelecionado = Convert.ToInt32(Console.ReadLine());

            bool conseguiuExcluir = controladorRevista.ExcluirRevista(idSelecionado);

            if (conseguiuExcluir)
                ApresentarMensagem("Revista excluída com sucesso", TipoMensagem.Sucesso);
            else
            {
                ApresentarMensagem("Falha ao tentar excluir a Revista", TipoMensagem.Erro);
                ExcluirRegistro();
            }
        }

        public void VisualizarRegistros()
        {
            ConfigurarTela("Visualizando as Revistas...");

            string configuracaColunasTabela = "{0,-10} | {1,-20} | {2,-35}";

            MontarCabecalhoTabela(configuracaColunasTabela);

            Revista[] revista = controladorRevista.SelecionarTodasRevistas();

            if (revista.Length == 0)
            {
                ApresentarMensagem("Nenhuma revista cadastrado!", TipoMensagem.Atencao);
                return;
            }

            for (int i = 0; i < revista.Length; i++)
            {
                Console.WriteLine(configuracaColunasTabela,
                   revista[i].Id, revista[i].TipoColecao, revista[i].NumeroEdicao, revista[i].AnoRevista, revista[i].IdCaixa);
            }
        }

        public string ObterOpcao()
        {
            Console.WriteLine("==================Registro==================");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=                 Digite:                  =");
            Console.WriteLine("=                                          =");
            Console.WriteLine("=       1 para inserir nova revista        =");
            Console.WriteLine("=       2 para visualizar revista          =");
            Console.WriteLine("=       3 para editar uma revista          =");
            Console.WriteLine("=       4 para excluir uma revista         =");
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

        private bool GravarRevista(int id)
        {
            string resultadoValidacao;
            bool conseguiuGravar = true;

            Console.Write("Digite o tipo de coleção da revista: ");
            string tipoColecao = Convert.ToString(Console.ReadLine());

            Console.Write("Digite o numero da edicao da revista: ");
            int numeroEdicao = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o ano da Revista: ");
            int anoRevista = Convert.ToInt32(Console.ReadLine());

            Console.Write("Digite o id da caixa para arrumar a revista: ");
            int caixa = Convert.ToInt32(Console.ReadLine());

            resultadoValidacao = controladorRevista.RegistrarRevista(
                id, tipoColecao, numeroEdicao, anoRevista, caixa);

            if (resultadoValidacao != "REVISTA_VALIDA")
            {
                ApresentarMensagem(resultadoValidacao, TipoMensagem.Erro);
                conseguiuGravar = false;
            }

            return conseguiuGravar;
        }

        #endregion
    }
}
