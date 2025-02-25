using ControleDeGastos.Model;
using ControleDeGastos.Service.DTOs;

namespace controleDeGastos.Service
{

    public class ServicePessoa
    {
        private static List<Pessoa> pessoas = new List<Pessoa>();  // Lista para armazenar as pessoas na memória
        private static int proximoIdPessoa = 1;  // Controle do próximo ID de pessoa
        private ServiceTransacao _transacaoService;

        public ServicePessoa(ServiceTransacao transacaoService)
        {
            _transacaoService = transacaoService;
        }


        // Método para cadastrar uma pessoa
        public PessoaDTO CriarPessoa(PessoaDTO pessoaDTO)
        {
            var pessoa = new Pessoa
            {
                Id = proximoIdPessoa++,  // Atribui o ID único e incrementa para o próximo
                Nome = pessoaDTO.Nome,             // Atribui o nome
                Idade = pessoaDTO.Idade            // Atribui a idade
            };

            pessoas.Add(pessoa);  // Adiciona a pessoa à lista

            return pessoaDTO;  // Retorna a pessoa cadastrada
        }

        // Método para listar todas as pessoas cadastradas
        public List<Pessoa> GetPessoas()
        {
            return pessoas;  // Retorna a lista de pessoas
        }
        public static Pessoa GetPessoaById(int pessoaId)
        {
            return pessoas.FirstOrDefault(p => p.Id == pessoaId);
        }

        // Método para deletar uma pessoa com base no ID
        public bool DeletarPessoa(int id)
        {
            var pessoa = pessoas.FirstOrDefault(p => p.Id == id);  // Busca a pessoa pelo ID
            if (pessoa == null) return false;  // Se não encontrar a pessoa, retorna false

            pessoas.Remove(pessoa);  // Se encontrar, remove a pessoa da lista
            _transacaoService.DeletarTransacao(id);

            return true;  // Retorna true indicando sucesso
        }
    }
}