using Microsoft.AspNetCore.Mvc;
using ControleDeGastos.Model;
using controleDeGastos.Service;

namespace ControleDeGastos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly ServiceTransacao _transacaoService;

    public TransacoesController(ServiceTransacao serviceTransacao)
    {
        _transacaoService = serviceTransacao;  // Instancia o serviço de transações
    }

    [HttpPost]
    public ActionResult<Transacao> CriarTransacao([FromBody] Transacao transacao)
    {
        try
        {
            var novaTransacao = _transacaoService.CriarTransacao(transacao.PessoaId, transacao.Descricao, transacao.Valor, transacao.Tipo);  // Cria a transação
            return CreatedAtAction(nameof(CriarTransacao), new { id = novaTransacao.Id }, novaTransacao);  // Retorna a transação criada
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  // Se der erro, retorna mensagem de erro
        }
    }

    [HttpGet]
    public ActionResult<List<Transacao>> GetTransacoes()
    {
        var transacoes = _transacaoService.GetTransacoes();  // Obtém todas as transações cadastradas
        return Ok(transacoes);  // Retorna a lista de transações
    }
}
