import axios from "axios";

const api = axios.create({
  baseURL: "https://localhost:7101/api", // URL da API
});


export const getTotais = async () => {
  const response = await axios.get("https://localhost:7101/api/transacoes/totais");
  return response.data;
};

export default api;