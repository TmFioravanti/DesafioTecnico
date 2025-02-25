namespace ControleDeGastos.Model;

//Transa��o  com os par�metros exigidos, ID da transa��o, decri��o, o tipo que pode ser Receita ou Despesa e o PessoaId que serve para referenciar a pessoa.
public class Transacao
{
    public int Id { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public decimal Valor { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public int PessoaId { get; set; }

}
