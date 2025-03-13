using Lanchonete;
using System.Security.Cryptography.X509Certificates;
using System.Xml;

class Program
{
    public static void Main(String[] args)
    {
        try
        {
            List<Produto> produtos = MapearProdutos();
            List<Pedido> Pedidos = new List<Pedido>();
            var pedido = new Pedido();


            int sair = 0;
            int sairpedido = 0;
            while (sair == 0)
            {
                
                Console.WriteLine("Digite 1 para criar um novo pedido 2 para por itens no pedido 3 para finalizar o pedido  ");
                int opção = int.Parse(Console.ReadLine());
                switch (opção)
                {
                    case 1:
                        {
                            pedido = new Pedido
                            {
                                Numcomanda = Pedidos.Count() + 1,
                                Items = new List<Produto>(),
                                total = 0

                            };
                            Pedidos.Add(pedido);

                            Console.WriteLine("Pedido criado");
                            Console.WriteLine("Faça seu pedido");
                            AddItemNoPedido(produtos, pedido, sairpedido);
                            Console.WriteLine("Digite alguma coisa para continuar: ");
                            Console.ReadLine();
                            Console.Clear();    
                            break;
                        }
                    case 2:
                        {

                            Console.WriteLine("escolha um pedido");
                            foreach (var ped in Pedidos)
                            {
                                Console.WriteLine($"{ped.Numcomanda}");
                            }
                            int escolha = int.Parse(Console.ReadLine());
                            pedido = Pedidos.FirstOrDefault(p => p.Numcomanda == escolha);
                            if (pedido == null)
                            {
                                Console.WriteLine($"Pedido invalido");
                                return;
                            }

                            AddItemNoPedido(produtos, pedido, sairpedido);

                            Console.WriteLine("Digite alguma coisa para continuar: ");
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("escolha um pedido");
                            foreach (var ped in Pedidos)
                            {
                                Console.WriteLine($"{ped.Numcomanda}");
                            }
                            int escolha = int.Parse(Console.ReadLine());
                            pedido = Pedidos.FirstOrDefault(p => p.Numcomanda == escolha);
                            if (pedido == null)
                            {
                                Console.WriteLine($"Pedido invalido");
                                return;
                            }
                            Console.WriteLine($"Pedido nª{pedido.Numcomanda}");
                            Console.WriteLine($"Produtos");
                            foreach (var itens in pedido.Items)
                            {
                                Console.WriteLine($"{itens.Nome} - Preço:{itens.Preco}");
                            }
                            Console.WriteLine($"Total dos Produtos:{pedido.total}");

                            Console.WriteLine("Digite alguma coisa para continuar: ");
                            Console.ReadLine();
                            Console.Clear();

                            break;
                        }
                }

            }


        }
        catch (FormatException)
        {
            Console.WriteLine("Formato errado");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }

    private static void AddItemNoPedido(List<Produto> produtos, Pedido pedido, int sairpedido)
    {
        int escolha = 9;
        while (escolha == 9)
        {
            foreach (var produto in produtos)
            {
                Console.WriteLine($"Digite:{produto.Codigo} para {produto.Nome} com o preço de : {produto.Preco}");
            }
             escolha = int.Parse(Console.ReadLine());
            
            var item = produtos.FirstOrDefault(x => x.Codigo == escolha);
            if (item != null)
            {

                pedido.Items.Add(item);
                pedido.total = pedido.Items.Sum(x => x.Preco);
                escolha = 9;
                Console.WriteLine($"produto {item.Nome} Registrado");
                Console.WriteLine("Digite alguma coisa para continuar: ");
                Console.ReadLine();
                Console.Clear();
            }
            else
            {
                Console.WriteLine($"produto invalido, dite 0 para sair ou qualquer tecla para continuar");
               var key =Console.ReadLine();
                if(key != "0")
                {
                    escolha = 9;
                }
                else
                {
                    escolha = 0;
                }
            }
        }
    }

    private static List<Produto> MapearProdutos()
    {
        List<Produto> produtos = new List<Produto>();

        Produto hamburguer = new Produto
        {
            Codigo = 1,
            Nome = "X-Salada",
            Preco = 26.90M,

        };

        produtos.Add(hamburguer);

        produtos.Add(new Produto
        {
            Codigo = 2,
            Nome = "X-Burguer",
            Preco = 24.90M
        });
        produtos.Add(new Produto
        {
            Codigo = 3,
            Nome = "X-Bacon",
            Preco = 36.90M,
        });

        produtos.Add(new Produto
        {
            Codigo = 4,
            Nome = "Batata frita",
            Preco = 25.90M
        });
        produtos.Add(new Produto
        {
            Codigo = 5,
            Nome = "Nugets",
            Preco = 15.90M
        });

        produtos.Add(new Produto
        {
            Codigo = 6,
            Nome = "Água",
            Preco = 5.00M
        });




        return produtos;
    }
}

