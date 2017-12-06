namespace ExemploCRUD
{
    public class Categoria
    {
        public int Id{ get; set; }
        public string Titulo{ get; set; }
        
        public Categoria()
        {
            
        }

        public Categoria(int Id, string Titulo)
        {
            this.Id = Id;
            this.Titulo = Titulo;
        }
    }
}