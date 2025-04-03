import { useState } from "react";
import { getTotais } from "../services/api";

interface Totais {
  PessoaId: number;
  Nome: string;
  TotalReceitas: number;
  TotalDespesas: number;
  Saldo: number;
}

interface TotalGeral {
  TotalReceitas: number;
  TotalDespesas: number;
  SaldoGeral: number;
}

const TotaisList = () => {
  const [totais, setTotais] = useState<Totais[]>([]);
  const [totalGeral, setTotalGeral] = useState<TotalGeral | null>(null);
  const [erro, setErro] = useState<string | null>(null);
  const [carregado, setCarregado] = useState<boolean>(false); // Estado para indicar se já carregou

  const fetchTotais = async () => {
    const data = await getTotais();
    if (data) {
      setTotais(data.Pessoas);
      setTotalGeral(data.TotalGeral);
      setCarregado(true);
    } else {
      setErro("Erro ao carregar os totais");
    }
  };

  return (
    <div>
      <h2>Totais por Pessoa</h2>
      {erro && <p style={{ color: "red" }}>{erro}</p>}

      <button onClick={fetchTotais}>Carregar Totais</button> {/* Botão adicionado */}

      {carregado && ( // Só mostra a tabela se os dados já foram carregados
        <>
          <table border={1}>
            <thead>
              <tr>
                <th>Nome</th>
                <th>Total de Receitas</th>
                <th>Total de Despesas</th>
                <th>Saldo</th>
              </tr>
            </thead>
            <tbody>
              {totais.map((t) => (
                <tr key={t.PessoaId}>
                  <td>{t.Nome}</td>
                  <td>R$ {t.TotalReceitas.toFixed(2)}</td>
                  <td>R$ {t.TotalDespesas.toFixed(2)}</td>
                  <td>R$ {t.Saldo.toFixed(2)}</td>
                </tr>
              ))}
            </tbody>
          </table>

          {totalGeral && (
            <div>
              <h3>Total Geral</h3>
              <p>Total de Receitas: R$ {totalGeral.TotalReceitas.toFixed(2)}</p>
              <p>Total de Despesas: R$ {totalGeral.TotalDespesas.toFixed(2)}</p>
              <p>Saldo Geral: R$ {totalGeral.SaldoGeral.toFixed(2)}</p>
            </div>
          )}
        </>
      )}
    </div>
  );
};

export default TotaisList;
