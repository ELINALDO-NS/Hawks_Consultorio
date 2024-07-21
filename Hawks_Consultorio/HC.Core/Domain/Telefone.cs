namespace HC.Core.Domain
{
    public class Telefone
    {
       
        public string Numero { get; set; }
        public int CLienteId { get; set; }
        public Cliente CLiente { get; set; }
    }
}