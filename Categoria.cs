namespace ExemploCRUD
{
    public class Categoria
    {
        public int Id{ get; set; }
        public string Titulo{ get; set; }
        
        public Categoria()
        {
            
        }

        public Categoria(string Titulo)
        {
            this.Titulo = Titulo;
        }
    }
}