import './App.css'
import Home from './pages/Home'
import ComponentsPage from './pages/ComponentsPage'
import { Route, Routes } from 'react-router-dom'

function App() {
  return (
    <Routes>
      <Route path="/" element={<Home />} />
      <Route path="/:alimentId" element={<ComponentsPage />} />
    </Routes>
  )
}

export default App
