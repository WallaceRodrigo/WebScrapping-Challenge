import { useEffect, useState } from 'react';
import axios from 'axios';
import './Home.css'
import { Aliment, SingleComponent } from '../types/aliments.types';
// import { Spinner } from 'react-bootstrap';

function Home() {
  const [apiResponse, setApiResponse] = useState([]);
  const [alimentData, setAlimentData] = useState<SingleComponent[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  const fetchData = async () => {
    try {
      // const response = await axios.post('https://localhost:7070/addAliment', [{}]);
      const response = await axios.get('https://localhost:7070/');

      setApiResponse(response.data);
    } catch (error) {
      console.log('Ocorreu um erro ao fazer a requisição', error);
    }
  }

  useEffect(() => { }, [alimentData])

  useEffect(() => {
    const didMount = async () => {
      await fetchData()
      setIsLoading(false);
    }

    didMount();
  }, [])

  const onCLick = (data: SingleComponent[]) => {
    setAlimentData(data);
    console.log(data);
  };

  return (
    <div>
      <h1>Home</h1>
      <input type="text" placeholder="Pesquisar Alimento" />
      {
        isLoading ? <h3>Loading...</h3> :
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
            {
              apiResponse.map((data: Aliment) => (
                <tbody>
                  <tr onClick={() => onCLick(data.components)}>
                    <td>{data.alimentId}</td>
                    <td>{data.name}</td>
                    <td>{data.scientificName}</td>
                    <td>{data.group}</td>
                    <td>{data.brand}</td>
                  </tr>
                </tbody>
              ))
            }
          </table>
      }
      {
        alimentData.length < 1 ? <></> :
          <table>
            <thead>
              <tr>
                <th>Componente</th>
                <th>unidades</th>
                <th>valorPor100g</th>
                <th>desvioPadrão</th>
                <th>valorMínimo</th>
                <th>valorMáximo</th>
                <th>númeroDeDadosUtilizado</th>
                <th>referências</th>
                <th>tipoDeDados</th>
              </tr>
            </thead>
            <tbody>
              {
                alimentData.map((data: SingleComponent) => (
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
      }
    </div>
  )
}

export default Home
