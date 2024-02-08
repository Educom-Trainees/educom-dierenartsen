import React from 'react';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from '../src/components/pages/HomePage/HomePage';
import SecondPage from '../src/components/pages/secondPage/secondPage';

const App = () => {
  return (
    <Router>
      <Routes>
        <Route path="/Homepage" element={<HomePage />} />
        <Route path="/secondPage" element={<SecondPage />} />
      </Routes>
    </Router>
  );
};

export default App;