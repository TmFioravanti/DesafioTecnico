import PessoaForm from "../components/PessoaForm";
import PessoaList from "../components/PessoaList";
import TransacaoForm from "../components/TransacaoForm";
import TotaisList from "../components/TotaisList";

const Home = () => {
  return (
    <div>
      <h1>Controle de Gastos</h1>
      <h2>Adicionar Pessoa</h2>
      <PessoaForm />
      <h2>Pessoas Cadastradas</h2>
      <PessoaList />
      <h2>Adicionar Transação</h2>
      <TransacaoForm />
      <h2>Resumo de Gastos</h2>
      <TotaisList />
    </div>
  );
};

export default Home;
