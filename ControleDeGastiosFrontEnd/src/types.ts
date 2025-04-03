export interface Pessoa {
    id: number;
    nome: string;
    idade: number;
  }
  
  export interface PessoaDTO {
    nome: string;
    idade: number;
  }
  
  export interface Transacao {
    id: number;
    descricao: string;
    valor: number;
    tipo: string;
    pessoaId: number;
  }
  export interface TransacaoDTO {
    descricao: string;
    valor: number;
    tipo: string;
    pessoaId: number;
  }
