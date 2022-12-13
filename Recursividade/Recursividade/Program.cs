using System.Text.Json;
using Recursividade.Models;

namespace menu;
class Menu
{

    public const string CaminhoArquivo= "D:\\Tudo\\GitHub\\codigo-do-futuro-recursividade\\Recursividade\\Recursividade\\Clientes\\cliente";

    public static void Main(string[] args)
    {
        Menu.criarMenu();
    }

    private static void criarMenu()
    {
        Console.WriteLine("Digite o número da operação escolhida:");
        Console.WriteLine("1-Cadastro de Clientes");
        Console.WriteLine("2-Listagem de Clientes");
        Console.WriteLine("0-Sair");
        int op = Int32.Parse(Console.ReadLine());
        switch (op)
        {
            case 1:
                Menu.cadastrar();
                Console.Clear();
                break;
            case 2:
                Console.Clear();
                Menu.lerClientes(1);
                Console.WriteLine("Pressione Enter para voltar");
                string nada = Console.ReadLine();
                Console.Clear();
                break;
            default:
                return;
        }
        Menu.criarMenu();
    }
    private static string cadastrarCampo(string nomeCampo)
    {
        Console.WriteLine("Por favor, insira o " + nomeCampo + " do Cliente");
        string campo = Console.ReadLine();
        if (campo == "")
        {
            Console.Clear();
            Console.WriteLine("Insiar um " + nomeCampo + " válido");
            campo=Menu.cadastrarCampo(nomeCampo);
        }
        return campo;
    }
        private static void cadastrar()
    {
        Console.Clear();
        Cliente cliente = new Cliente();
        cliente.Nome = Menu.cadastrarCampo("Nome");
        Console.Clear();
        cliente.Telefone = Menu.cadastrarCampo("Telefone");
        var JSON = JsonSerializer.Serialize<Cliente>(cliente);
        File.WriteAllText(CaminhoArquivo + Menu.recolherId(1), JSON);
    }
    private static void lerClientes(int idAtual)
    {
        string json = "";
        try
        {
            json = File.ReadAllText(CaminhoArquivo + idAtual);
        }catch(Exception ex)
        {
            return;
        }
        var cliente=JsonSerializer.Deserialize<Cliente>(json);
        Console.WriteLine(cliente.ToString());
        Menu.lerClientes(idAtual + 1);
    }
    private static int recolherId(int idAtual)
    {
        string json = "";
        try
        {
            json = File.ReadAllText(CaminhoArquivo + idAtual);
        }
        catch (Exception ex)
        {
            return idAtual;
        }
        return Menu.recolherId(idAtual + 1);
    }
    private static void escreverClientes()
    {
        
    }
}
