using controleDeGastos.Service;
using ControleDeGastos.Model;
using ControleDeGastos.Service.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeGastos.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PessoasController : ControllerBase
{
    private readonly ServicePessoa _pessoaService;

    public PessoasController(ServicePessoa pessoaService)
    {
        _pessoaService = pessoaService;
    }

    [HttpPost]
    public ActionResult<PessoaDTO> CriarPessoa([FromBody] PessoaDTO pessoa)
    {
        var novaPessoa = _pessoaService.CriarPessoa(pessoa);  // Cria a pessoa
        return Ok("Pessoa Criada com Sucesso");  // Retorna a pessoa criada
    }

    [HttpGet]
    public ActionResult<List<Pessoa>> GetPessoas()
    {
        var pessoas = _pessoaService.GetPessoas();  // Obtém todas as pessoas cadastradas
        return Ok(pessoas);  // Retorna a lista de pessoas
    }

    [HttpDelete("{id}")]
    public ActionResult DeletarPessoa(int id)
    {
        var sucesso = _pessoaService.DeletarPessoa(id);  // Tenta deletar a pessoa
        if (!sucesso)
            return NotFound("Pessoa não encontrada.");  // Se não encontrar, retorna erro
        return NoContent();  // Retorna sucesso
    }
}
