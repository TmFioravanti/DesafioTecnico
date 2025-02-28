namespace ControleDeGastos.Service.DTOs
{
    //DTO para realizar a criação e trasnferência de informação sem expor o ID
    public class PessoaDTO
    {
        public string Nome { get; set; } = string.Empty;
        public int Idade { get; set; }
    }
}
