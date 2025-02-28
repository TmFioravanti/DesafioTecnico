using ControleDeGastos.Model;
using controleDeGastos.Service;

namespace controleDeGastos.Service
{

    public class ServiceTransacao
    {
        private static List<Transacao> transacoes = new List<Transacao>();  // Lista para armazenar as transações
        private static int proximoIdTransacao = 1;  // Controle do próximo ID de transação

        // Método para cadastrar uma nova transação
        public Transacao CriarTransacao(int pessoaId, string descricao, decimal valor, string tipo)
        {
            var pessoa = ServicePessoa.GetPessoaById(pessoaId);  // Verifica se a pessoa existe
            if (pessoa == null)
            {
                throw new Exception("Pessoa não encontrada.");
            }

            // Se a pessoa for menor de idade, só poderá registrar despesas
            if (pessoa.Idade < 18 && tipo == "Receita")
            {
                throw new Exception("Menores de idade só podem registrar despesas.");
            }

            var transacao = new Transacao
            {
                Id = proximoIdTransacao++,    // Atribui um ID único à transação
                PessoaId = pessoaId,          // Associa a transação à pessoa
                Descricao = descricao,        // Descrição da transação
                Valor = valor,                // Valor da transação
                Tipo = tipo                   // Tipo da transação ("Despesa" ou "Receita")
            };

            transacoes.Add(transacao);  // Adiciona a transação à lista
            return transacao;           // Retorna a transação criada
        }

        // Método para listar todas as transações
        public List<Transacao> GetTransacoes()
        {
            return transacoes;  // Retorna a lista de transações
        }

        public bool DeletarTransacao(int pessoaId)
        {
            var transacao = transacoes.Where(p => p.PessoaId == pessoaId);  // Busca a pessoa pelo ID
            if (transacao == null) return false;  // Se não encontrar a pessoa, retorna false

            transacoes.RemoveAll(x => transacao.Contains(x));

            return true;

        }



    }

}
