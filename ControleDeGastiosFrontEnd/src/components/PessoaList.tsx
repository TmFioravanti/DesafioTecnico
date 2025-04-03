import { useEffect, useState } from "react";
import api from "../services/api";
import { Pessoa } from "../types";

const PessoaList = () => {
  const [pessoas, setPessoas] = useState<Pessoa[]>([]);

  useEffect(() => {
    api.get("/pessoas").then((res) => setPessoas(res.data));
  }, []);

  return (
    <ul>
      {pessoas.map((pessoa) => (
        <li key={pessoa.id}>
          {pessoa.nome} - {pessoa.idade} anos
        </li>
      ))}
    </ul>
  );
};

export default PessoaList;
