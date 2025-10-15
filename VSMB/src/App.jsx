import Navbar from './components/Navbar';
import Footer from './components/Footer'
import Home from './components/Home';
import Login from './components/Login';
import Register from './components/Register';
import { useState } from 'react';


function App() {
  const [view, setView] = useState('home'); 

  let content;
  if (view === 'home') {
    content = <Home />;
  } else if (view === 'register') {
    content = <Register />;
  } else if (view === 'login') {
    content = <Login />;
  }

  return (
    <div className="layout">
      <Navbar onRegisterClick={() => setView('register')} onLoginClick={() => setView('login')} />
      <main className="content">
        {content}
      </main>
      <Footer />
    </div>
  );
}

export default App;

