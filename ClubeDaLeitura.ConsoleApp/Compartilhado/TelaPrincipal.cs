namespace ClubeDaLeitura.ConsoleApp.Compartilhado
{
    internal static class TelaPrincipal
    {
        public static char ApresentarMenuPrincipal()
        {
            Console.Clear();

            Console.WriteLine("----------------------------------------");
            Console.WriteLine("|           Clube da Leitura           |");
            Console.WriteLine("----------------------------------------");

            Console.WriteLine();

            Console.WriteLine("1 - Cadastro de Amigo");
            Console.WriteLine("2 - Cadastro de Caixa");
            Console.WriteLine("3 - Cadastro de Revista");
            Console.WriteLine("4 - Cadastro de Empréstimo");
            Console.WriteLine("5 - Cadastro de Reserva");
            Console.WriteLine();
            Console.WriteLine("S - Sair");

            Console.WriteLine();

            Console.Write("Escolha uma das opções: ");

            char opcaoEscolhida = Console.ReadLine()[0];

            
            return opcaoEscolhida;
        }
    }
}
