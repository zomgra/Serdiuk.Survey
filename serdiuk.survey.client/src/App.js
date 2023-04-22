import './App.css';
import { Route, Routes } from 'react-router';
import HomePage from './Pages/HomePage/HomePage';
import { useState } from 'react';

function App() {

  const [pageNumber,setPageNumber] = useState();
  const [surveys, setSurveys] = useState([]);

  return (
    <Routes>
      <Route path='/' element={<HomePage pageNumber={pageNumber} setPageNumber={setPageNumber} />}></Route>
    </Routes>
  );
}

export default App;
