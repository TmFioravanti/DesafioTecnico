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
        _transacaoService = serviceTransacao;  // Instancia o servi�o de transa��es
        _pessoaService = pessoaService;
    }
    

    [HttpPost]
    public ActionResult<Transacao> CriarTransacao([FromBody] Transacao transacao)
    {
        try
        {
            var novaTransacao = _transacaoService.CriarTransacao(transacao.PessoaId, transacao.Descricao, transacao.Valor, transacao.Tipo);  // Cria a transa��o
            return CreatedAtAction(nameof(CriarTransacao), new { id = novaTransacao.Id }, novaTransacao);  // Retorna a transa��o criada
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);  // Se der erro, retorna mensagem de erro
        }
    }

    [HttpGet]
    public ActionResult<List<Transacao>> GetTransacoes()
    {
        var transacoes = _transacaoService.GetTransacoes();  // Obt�m todas as transa��es cadastradas
        return Ok(transacoes);  // Retorna a lista de transa��es
    }
    [HttpGet("totais")]
    public ActionResult<object> GetTotais()
    {
        var totais = _pessoaService.ObterTotais(); // Certifique-se de que esse m�todo existe  
        return Ok(totais);
    }


}
