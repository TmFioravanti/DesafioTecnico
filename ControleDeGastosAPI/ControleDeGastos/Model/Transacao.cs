namespace ControleDeGastos.Model;

//Transação  com os parâmetros exigidos, ID da transação, decrição, o tipo que pode ser Receita ou Despesa e o PessoaId que serve para referenciar a pessoa.
public class Transacao
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public int PessoaId { get; set; }

}
