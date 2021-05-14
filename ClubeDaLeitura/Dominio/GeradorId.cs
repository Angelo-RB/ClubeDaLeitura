using System;

namespace ClubeDaLeitura.ConsoleApp.Dominio
{
        public class GeradorId
        {
            private static int idAmiguinho = 0;
            private static int idCaixa = 0;
            private static int idRevista = 0;
            private static int idEmprestimo = 0;

            public static int GerarIdAmiguinho()
            {
                return ++idAmiguinho;
            }

            internal static int GerarIdCaixa()
            {
                return ++idCaixa;
            }

            public static int GerarIdRevista()
            {
                return ++idRevista;
            }

            public static int GerarIdEmprestimo()
            {
            return ++idEmprestimo;
            }
    }
    
}
