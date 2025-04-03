import { useState } from "react";
import api from "../services/api";
import { PessoaDTO } from "../types";

const PessoaForm = () =>{
  const [nome, setNome] = useState("");
  const [idade, setIdade] = useState("");

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    if (!nome || !idade) return;

    const novaPessoa: PessoaDTO = { nome, idade: parseInt(idade) };

    await api.post("/pessoas", novaPessoa);
    alert("Pessoa adicionada!");
    setNome("");
    setIdade("");
  };

  return (
    <form onSubmit={handleSubmit}>
      <input
        type="text"
        placeholder="Nome"
        value={nome}
        onChange={(e) => setNome(e.target.value)}
      />
      <input
        type="number"
        placeholder="Idade"
        value={idade}
        onChange={(e) => setIdade(e.target.value)}
      />
      <button type="submit">Adicionar Pessoa</button>
    </form>
  );
};

export default PessoaForm;
