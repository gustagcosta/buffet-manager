namespace Buffet.RequestModels
{
    public class StoreEnderecoRequest
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Bairro { get; set; }
        public string Rua { get; set; }
        public int Numero { get; set; }
    }
}