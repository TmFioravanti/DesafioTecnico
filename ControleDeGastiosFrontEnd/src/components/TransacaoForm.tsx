import { useState } from "react";
import api from "../services/api";
import { TransacaoDTO } from "../types";

const TransacaoForm = () => {
  const [descricao, setDescricao] = useState("");
  const [valor, setValor] = useState("");
  const [tipo, setTipo] = useState("despesa");
  const [pessoaId, setPessoaId] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!descricao || !valor || !pessoaId) return;

    const novaTransacao: TransacaoDTO = {
      descricao,
      valor: parseFloat(valor),
      tipo,
      pessoaId: parseInt(pessoaId),
    };

    await api.post("/transacoes", novaTransacao);
    alert("Transação adicionada!");
    setDescricao("");
    setValor("");
    setPessoaId("");
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder="Descrição"
        value={descricao}
        onChange={(e) => setDescricao(e.target.value)}
      />
      <input
        type="number"
        placeholder="Valor"
        value={valor}
        onChange={(e) => setValor(e.target.value)}
      />
      <select value={tipo} onChange={(e) => setTipo(e.target.value)}>
        <option value="despesa">Despesa</option>
        <option value="receita">Receita</option>
      </select>
      <input
        type="number"
        placeholder="ID da Pessoa"
        value={pessoaId}
        onChange={(e) => setPessoaId(e.target.value)}
      />
      <button type="submit">Adicionar Transação</button>
    </form>
  );
};

export default TransacaoForm;
