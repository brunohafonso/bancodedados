﻿using System;
using System.Collections.Generic;

namespace ExemploCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Console.WriteLine("digite o id categoria a ser atualizada");
            //    string categoria = Console.ReadLine();
            //    Categoria cat = new Categoria(categoria);
               int id = Convert.ToInt32(Console.ReadLine());
               System.Console.WriteLine("digite o titulo categoria a ser atualizada");
               string titulo = Console.ReadLine();
               Categoria cat = new Categoria(id, titulo);
               BancoDados banco = new BancoDados();
               banco.Deletar(cat);


            
            
            
            
            //System.Console.WriteLine("digite o Id da categoria");
            //int id = Convert.ToInt32(Console.ReadLine());
            // BancoDados banco = new BancoDados();
            // List<Categoria> lista = new List<Categoria>();
            // lista = banco.listarCategorias();
            // foreach(Categoria a in lista) 
            // {
            //     System.Console.WriteLine("ID: {0} \nCATEGORIA: {1} ",a.Id, a.Titulo);
            // }
        }
    }
}
