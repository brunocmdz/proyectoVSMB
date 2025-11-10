import './navbar.css';
import { useEffect, useState } from 'react';

function Navbar({ onRegisterClick, onLoginClick, onHomeClick }) {
  const [userName, setUserName] = useState('');

  useEffect(() => {
    const name = localStorage.getItem("userName");
    if (name) {
      setUserName(name);
    }
  }, []);

  return (
    <div className="container">
      <nav className='navbar'>
        <div className="brand-logo">
          <a onClick={onHomeClick} className="menu-item">V S M B</a>
        </div>
        <div className='auth-buttons'>
          <div id='login_btns'>
            {userName ? (
              <span className="estado-logeado">Hola, {userName}</span>
            ) : (
              <>
                <button className='menu-item' onClick={onLoginClick} id='login'>Iniciar Sesión</button>
                <button className='menu-item' onClick={onRegisterClick} id='register'>Registrarse</button>
              </>
            )}
          </div>
        </div>
      </nav>
    </div>
  );
}

export default Navbar;
