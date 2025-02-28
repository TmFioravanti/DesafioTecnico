using Microsoft.AspNetCore.Mvc;
using ControleDeGastos.Model;
using controleDeGastos.Service;

namespace ControleDeGastos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TransacoesController : ControllerBase
{
    private readonly ServiceTransacao _transacaoService;
    private readonly ServicePessoa _pessoaService;

    public TransacoesController(ServiceTransacao serviceTransacao, ServicePessoa pessoaService)
    {
        _transacaoService = serviceTransacao;  // Instancia o serviço de transações
        _pessoaService = pessoaService;
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
    [HttpGet("totais")]
    public ActionResult<object> GetTotais()
    {
        var totais = _pessoaService.ObterTotais(); // Certifique-se de que esse método existe  
        return Ok(totais);
    }


}
