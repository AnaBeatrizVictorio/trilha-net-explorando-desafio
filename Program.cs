using System.Text;
using DesafioProjetoHospedagem.Models;

Console.OutputEncoding = Encoding.UTF8;

// Cria a suíte
Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

// Cria uma nova reserva, passando a suíte e os hóspedes
Reserva reserva = new Reserva(diasReservados: 5);
reserva.CadastrarSuite(suite);


bool exibirMenu = true;

while (exibirMenu)
{
    Console.Clear();
    Console.WriteLine("===== Menu =====");
    Console.WriteLine("1 - Cadastrar hóspedes");
    Console.WriteLine("2 - Mostrar quantidade de hóspedes");
    Console.WriteLine("3 - Listar hóspedes");
    Console.WriteLine("4 - Calcular valor da diária");
    Console.WriteLine("0 - Sair");
    Console.Write("Escolha uma opção: ");
    
     switch (Console.ReadLine())
    {
        case "1": // Cadastrar hóspedes
            List<Pessoa> hospedes = new List<Pessoa>();
            Console.Write("Quantos hóspedes deseja cadastrar? ");
            int quantidade = int.Parse(Console.ReadLine());

            for (int i = 0; i < quantidade; i++)
            {
                Console.Write($"Nome do hóspede {i + 1}: ");
                string nome = Console.ReadLine();
                hospedes.Add(new Pessoa(nome));
            }

            try
            {
                reserva.CadastrarHospedes(hospedes);
                Console.WriteLine("Hóspedes cadastrados com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
            }

            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;

        case "2": // Mostrar quantidade de hóspedes
            Console.WriteLine("Quantidade de hóspedes: " + reserva.ObterQuantidadeHospedes());
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;

        case "3": // Listar hóspedes
            if (reserva.Hospedes != null && reserva.Hospedes.Count > 0)
            {
                Console.WriteLine("Hóspedes cadastrados:");
                foreach (var h in reserva.Hospedes)
                {
                    Console.WriteLine("- " + h.NomeCompleto);
                }
            }
            else
            {
                Console.WriteLine("Nenhum hóspede cadastrado ainda.");
            }
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;

        case "4": // Calcular valor da diária
            Console.WriteLine("Valor total da diária: " + reserva.CalcularValorDiaria());
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
            break;

        case "0": // Sair
            exibirMenu = false;
            break;

        default:
            Console.WriteLine("Opção inválida!");
            Console.ReadKey();
            break;
    }
}

// Exibe a quantidade de hóspedes e o valor da diária
Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
