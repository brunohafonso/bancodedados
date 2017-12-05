using System;

namespace ExemploCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            //    System.Console.WriteLine("digite a categoria");
            //    string categoria = Console.ReadLine();
            //    Categoria cat = new Categoria(categoria);
            //    BancoDados banco = new BancoDados();
            //    banco.Adicionar(cat);

            System.Console.WriteLine("digite o id da categoria");
            int id = Convert.ToInt32(Console.ReadLine());
            BancoDados banco = new BancoDados();
            banco.listarCategorias(id);
        }
    }
}
