using ControleDeGastos.Model;
using controleDeGastos.Service;

namespace controleDeGastos.Service
{

    public class ServiceTransacao
    {
        private static List<Transacao> transacoes = new List<Transacao>();  // Lista para armazenar as transa��es
        private static int proximoIdTransacao = 1;  // Controle do pr�ximo ID de transa��o

        // M�todo para cadastrar uma nova transa��o
        public Transacao CriarTransacao(int pessoaId, string descricao, decimal valor, string tipo)
        {
            var pessoa = ServicePessoa.GetPessoaById(pessoaId);  // Verifica se a pessoa existe
            if (pessoa == null)
            {
                throw new Exception("Pessoa n�o encontrada.");
            }

            // Se a pessoa for menor de idade, s� poder� registrar despesas
            if (pessoa.Idade < 18 && tipo == "Receita")
            {
                throw new Exception("Menores de idade s� podem registrar despesas.");
            }

            var transacao = new Transacao
            {
                Id = proximoIdTransacao++,    // Atribui um ID �nico � transa��o
                PessoaId = pessoaId,          // Associa a transa��o � pessoa
                Descricao = descricao,        // Descri��o da transa��o
                Valor = valor,                // Valor da transa��o
                Tipo = tipo                   // Tipo da transa��o ("Despesa" ou "Receita")
            };

            transacoes.Add(transacao);  // Adiciona a transa��o � lista
            return transacao;           // Retorna a transa��o criada
        }

        // M�todo para listar todas as transa��es
        public List<Transacao> GetTransacoes()
        {
            return transacoes;  // Retorna a lista de transa��es
        }

        public bool DeletarTransacao(int pessoaId)
        {
            var transacao = transacoes.Where(p => p.PessoaId == pessoaId);  // Busca a pessoa pelo ID
            if (transacao == null) return false;  // Se n�o encontrar a pessoa, retorna false

            transacoes.RemoveAll(x => transacao.Contains(x));

            return true;

        }



    }

}
