import { useState } from 'react';
import axios from 'axios';
import './Home.css'
import { Aliment, SingleComponent } from '../types/aliments.types';
// import { Spinner } from 'react-bootstrap';

function Home() {
  const [apiResponse, setApiResponse] = useState([]);
  const [alimentData, setAlimentData] = useState<SingleComponent[]>([]);
  const [isLoading, setIsLoading] = useState(true);

  //const fetchData = async () => {
  //  try {
  //    // const response = await axios.post('https://localhost:7070/addAliment', [{}]);
  //    const response = await axios.get('https://localhost:7070/getAllAliments/1/1');
//
  //    setApiResponse(response.data);
  //  } catch (error) {
  //    console.log('Ocorreu um erro ao fazer a requisição', error);
  //  }
  //}
//
  //useEffect(() => { }, [alimentData])
//
  //useEffect(() => {
    //    const didMount = async () => {
    //      await fetchData()
    //      setIsLoading(false);
    //    }
    //
    //    didMount();
  //}, [])

  const onClickExtract = async () => {
    const pageNumber = (document.querySelector('#pageInput') as HTMLInputElement).value;

    if (pageNumber === '') {
      alert('Digite o número da página que deseja extrair');
      return;
    }

    if (Number(pageNumber) < 1 || Number(pageNumber) > 57) {
      alert('Digite um número entre 1 e 57');
      return;
    }

    try {
      const response = await axios.get(`https://localhost:7070/getAllAliments/${pageNumber}`);

      //await axios.post(`https://localhost:7070/getAllAliments/${pageNumber}`)

      setApiResponse(response.data);
      setIsLoading(false);
    } catch (error) {
      console.log('Ocorreu um erro ao fazer a requisição', error);
    }
  }

  const onClickSearch = async () => {
    const searchInput = (document.querySelector('#searchInput') as HTMLInputElement).value;

    if (searchInput === '') {
      alert('Digite o nome do alimento que deseja pesquisar');
      return;
    }

    const filteredData = await axios.get(`https://localhost:7070/getAliment/${searchInput}`);

    console.log(filteredData);
    

    setApiResponse(filteredData.data);
  }

  const onCLick = (data: SingleComponent[]) => {
    const componentsTableDiv = document.getElementById('componentsTableDiv');

    componentsTableDiv?.scrollIntoView({ behavior: 'smooth' });

    setAlimentData(data);
    console.log(data);
  };

  return (
    <div className='homeDiv'>
      <h1>WebScrapping TBCA</h1>
      {
        isLoading ?
          <div className='homeDiv'>
            <p>Digite o numero da pagina que deseja extrair de TBCA.net.br</p>
            <div>
              <input id="pageInput" type="text" placeholder="De 1 a 57" />
              <button onClick={onClickExtract}>Extrair</button>
            </div>
          </div>
          :
          <div className='homeDiv'>
            <div>
              <input id="searchInput" type="text" placeholder="Pesquisar Alimento" />
              <button onClick={onClickSearch}>Pesquisar</button>
            </div>
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
                {
                  apiResponse.map((data: Aliment) => (
                    <tr onClick={() => onCLick(data.components)}>
                      <td>{data.alimentId}</td>
                      <td>{data.name}</td>
                      <td>{data.scientificName}</td>
                      <td>{data.group}</td>
                      <td>{data.brand}</td>
                    </tr>
                  ))
                }
              </tbody>
            </table>
          </div>
      }
      {
        alimentData.length < 1 ? <></> :
          <div id='componentsTableDiv' className='fadeIn'>
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
          </div>
      }
    </div>
  )
}

export default Home
