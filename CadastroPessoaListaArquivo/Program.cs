namespace CadastroPessoaListaArquivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string nome, mensagem;
            Console.WriteLine("Digite o nome do arquivo: ");
            nome = Console.ReadLine();
            Arquivo a = new Arquivo(nome);
            int op;
            List<Pessoa> lista = new List<Pessoa>();
            while (true)
            {
                Console.WriteLine("Menu do sistema de pessoas: ");
                Console.WriteLine("1 - Cadastrar uma pessoa");
                Console.WriteLine("2 - para ler todas as pessoas");
                op = int.Parse(Console.ReadLine());
                if (op == 1)
                {
                    
                    Pessoa p = new Pessoa();
                    Console.WriteLine("Digite o id da pessoa: ");
                    p.Id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o nome da pessoa: ");
                    p.Nome = Console.ReadLine();
                    Console.WriteLine("Digite o e-mail da pessoa: ");
                    p.Email = Console.ReadLine();
                    a.CriaAbreArquivo();
                    mensagem = p.Id+";"+p.Nome+";"+p.Email;
                    a.GravarMensagem(mensagem);
                    a.FecharArquivo();
                    lista.Add(p);
                }
                if (op == 2)
                {
                    lista.Clear();
                    string[] vetorPessoa = a.LerTodasLinhas();
                    for(int i = 0; i< vetorPessoa.Length; i++)
                    {   
                        Pessoa paux = new Pessoa();
                        string[] auxiliar = vetorPessoa[i].Split(';');
                        paux.Id = Convert.ToInt32(auxiliar[0]);
                        paux.Nome = auxiliar[1];
                        paux.Email = auxiliar[2];
                        lista.Add(paux);
                    }

                    foreach (Pessoa item in lista)
                    {
                        Console.Write("ID: " + item.Id);
                        Console.Write(" - Nome: " + item.Nome);
                        Console.WriteLine(" - E-mail: " + item.Email);
                    }
                }
            }
        }
    }
}