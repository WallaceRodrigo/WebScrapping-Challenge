import { useEffect, useState } from "react"
import axios from 'axios';
import { useParams } from "react-router-dom";
import { Aliment, SingleComponent } from "../types/aliments.types";

function ComponentsPage() {
  const [aliment, setAliment] = useState<Aliment[]>([]);
  const [components, setComponents] = useState([]);

  const params = useParams();
  const { alimentId } = params;

  console.log(params);

  const fetchData = async () => {
    try {
      const response = await axios.get(`https://localhost:7070/GetAlimentById/${alimentId}`);

      setAliment([response.data]);
      setComponents(response.data.components);
    } catch (error) {
      console.log('Ocorreu um erro ao fazer a requisição', error);
    }
  }

  useEffect(() => {
    const didMount = async () => {
      await fetchData()
    }

    didMount();
  // eslint-disable-next-line react-hooks/exhaustive-deps
  }, [])

  return (
    <div>
      {
        aliment.length < 1 ? <h1>Alimento não encontrado</h1> :
          <div id='componentsTableDiv' className='fadeIn'>
            <table id="alimentsTable">
              <thead>
                <tr>
                  <th>Id</th>
                  <th>Alimento</th>
                  <th>Nome científico</th>
                  <th>Grupo</th>
                  <th>Marca</th>
                </tr>
              </thead>
              <tbody>
                <tr>
                  <td>{aliment[0].alimentId}</td>
                  <td>{aliment[0].name}</td>
                  <td>{aliment[0].scientificName}</td>
                  <td>{aliment[0].group}</td>
                  <td>{aliment[0].brand}</td>
                </tr>
              </tbody>
            </table>
            <table id="componentsTable">
              <thead>
                <tr>
                  <th>Componente</th>
                  <th>Unidades</th>
                  <th>Valor Por 100g</th>
                  <th>Desvio Padrão</th>
                  <th>Valor Mínimo</th>
                  <th>Valor Máximo</th>
                  <th>Número De Dados Utilizado</th>
                  <th>Referências</th>
                  <th>Tipo De Dados</th>
                </tr>
              </thead>
              <tbody>
                {
                  components.map((data: SingleComponent) => (
                    <tr>
                      <td>{data.componente}</td>
                      <td>{data.unidades}</td>
                      <td>{data.valorPor100g}</td>
                      <td>{data.desvioPadrão}</td>
                      <td>{data.valorMínimo}</td>
                      <td>{data.valorMáximo}</td>
                      <td>{data.númeroDeDadosUtilizado}</td>
                      <td>{data.referências}</td>
                      <td>{data.tipoDeDados}</td>
                    </tr>
                  ))
                }
              </tbody>
            </table>
          </div>
      }
    </div>
  )
}

export default ComponentsPage;
