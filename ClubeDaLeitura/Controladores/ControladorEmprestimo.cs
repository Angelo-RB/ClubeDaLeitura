using System;
using ClubeDaLeitura.ConsoleApp.Dominio;

namespace ClubeDaLeitura.ConsoleApp.Controladores
{
    public class ControladorEmprestimo : ControladorBase
    {
        private readonly ControladorAmiguinho controladorAmiguinho;
        private readonly ControladorRevista controladorRevista;

        public ControladorEmprestimo(ControladorAmiguinho ctrlAmigo, ControladorRevista ctrlRevista)
        {
            controladorAmiguinho = ctrlAmigo;
            controladorRevista = ctrlRevista;
        }

        public string RegistrarEmprestimo(int id, int idAmiguinhoEmprestimo, int idRevistaEmprestimo,
            DateTime dataEmprestimo, DateTime dataDevolucao)
        {
            Emprestimo novoEmprestimo;
            int posicao;

            if (id == 0)
            {
                posicao = ObterPosicaoVaga();
                novoEmprestimo = new Emprestimo();
            }
            else
            {
                posicao = ObterPosicaoOcupada(new Emprestimo(id));
                novoEmprestimo = (Emprestimo)registros[posicao];
            }

            novoEmprestimo.amiguinho = controladorAmiguinho.SelecionarAmiguinhoPorId(idAmiguinhoEmprestimo);
            novoEmprestimo.revista = controladorRevista.SelecionarRevistaPorId(idRevistaEmprestimo);
            novoEmprestimo.data = dataEmprestimo;
            novoEmprestimo.dataDevolucao = dataDevolucao;

            string resultadoValidacao = novoEmprestimo.Validar();

            if (resultadoValidacao == "EMPRESTIMO_VALIDO")
            {
                registros[posicao] = novoEmprestimo;                
            }

            return resultadoValidacao;
        }

        public bool FecharEmprestimo(Emprestimo emprestimo)
        {
            bool conseguiuFechar = false;

            for (int i = 0; i < registros.Length; i++)
            {
                if (registros[i] != null && registros[i].Equals(emprestimo))
                {
                    emprestimo.emprestimoAberto = false;
                    conseguiuFechar = true;
                    break;
                }
            }

            return conseguiuFechar;
        }

        public Emprestimo[] SelecionarTodosEmprestimos()
        {
            object[] arrayAux = SelecionarTodosRegistros();

            Emprestimo[] emprestimos = new Emprestimo[arrayAux.Length];

            Array.Copy(arrayAux, emprestimos, arrayAux.Length);

            return emprestimos;
        }

        public Emprestimo[] SelecionarEmprestimosEmAberto()
        {
            object[] arrayAux = SelecionarTodosRegistros();

            Emprestimo[] emprestimos = new Emprestimo[arrayAux.Length];

            Array.Copy(arrayAux, emprestimos, arrayAux.Length);

            Emprestimo[] emprestimosAbertos = new Emprestimo[emprestimos.Length];

            int i = 0;

            foreach (Emprestimo emp in emprestimos)
            {
                if (emp != null && emp.emprestimoAberto == true)
                    emprestimosAbertos[i++] = emp;
            }

            return emprestimosAbertos;
        }

        public Emprestimo[] SelecionarEmprestimosMensais(int mes)
        {
            object[] arrayAux = SelecionarTodosRegistros();

            Emprestimo[] emprestimos = new Emprestimo[arrayAux.Length];

            Array.Copy(arrayAux, emprestimos, arrayAux.Length);

            Emprestimo[] emprestimosMensais = new Emprestimo[emprestimos.Length];

            int i = 0;

            foreach (Emprestimo emp in emprestimos)
            {
                if (emp != null && emp.data.Month == mes)
                    emprestimosMensais[i++] = emp;
            }

            return emprestimosMensais;
        }

        public Emprestimo SelecionarEmprestimoPorId(int id)
        {
            return (Emprestimo)SelecionarRegistroPorId(new Emprestimo(id));
        }
    }
}