using System;

namespace ExemploCRUD
{
    public class Cliente
    {
        public int Id{ get; set; }
        public string NomeCliente{ get; set; }
        public string Email{ get; set; }
        public string CPF{ get; set; }
        public DateTime DataCadastro{ get; set; }
        
        public Cliente()
        {
            
        }
    }
}