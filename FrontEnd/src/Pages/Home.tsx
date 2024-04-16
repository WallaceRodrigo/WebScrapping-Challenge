import { useEffect, useState } from 'react';
import axios from 'axios';
import './Home.css'
import { Spinner } from 'react-bootstrap';

function App() {
  const [apiResponse, setApiResponse] = useState([]);
  const [isLoading, setIsLoading] = useState(true);

  const fetchData = async () => {
    try {
      const response = await axios.post('https://localhost:7070/addAliment', [{}]);

      setApiResponse(response.data);
    } catch (error) {
      console.log('Ocorreu um erro ao fazer a requisição', error);
    }
  }

  useEffect(() => {
    fetchData();
  }, [apiResponse])

  useEffect(() => {
    const didMount = async () => {
      await fetchData()
      setIsLoading(false);
    }

    didMount();
  }, [])

  return (
    <div>
      <h1>Home</h1>
      {
        isLoading ? <h3><Spinner animation="border"/></h3> :
        <ul>
          {apiResponse.map((item, index) => (
            <li key={index}>{item}</li>
          ))}
          </ul>
      }
    </div>
  )
}

export default App
