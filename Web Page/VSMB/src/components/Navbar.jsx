import './navbar.css';
import { useEffect, useState } from 'react';
import UserModal from './UserModal'; // 👈 importá el modal

function Navbar({ onRegisterClick, onLoginClick, onHomeClick }) {
  const [userName, setUserName] = useState('');
  const [userId, setUserId] = useState('');
  const [userEmail, setUserEmail] = useState('');
  const [mostrarModal, setMostrarModal] = useState(false);

  useEffect(() => {
    const name = localStorage.getItem("userName");
    const id = localStorage.getItem("userId");
    const email = localStorage.getItem("userEmail");
    if (name) setUserName(name);
    if (id) setUserId(id);
    if (email) setUserEmail(email);
  }, []);

  const cerrarSesion = () => {
    localStorage.removeItem("userId");
    localStorage.removeItem("userName");
    window.location.reload();
  };

  return (
    <div className="container">
      <nav className='navbar'>
        <div className="brand-logo">
          <a onClick={onHomeClick} className="menu-item">V S M B</a>
        </div>
        <div className='auth-buttons'>
          <div id='login_btns'>
            {userName ? (
              <span className="estado-logeado" onClick={() => setMostrarModal(true)}>
                 Hola, {userName}
              </span>
            ) : (
              <>
                <button className='menu-item' onClick={onLoginClick} id='login'>Iniciar Sesión</button>
                <button className='menu-item' onClick={onRegisterClick} id='register'>Registrarse</button>
              </>
            )}
          </div>
        </div>
      </nav>

      {mostrarModal && (
        <UserModal
          userName={userName}
          userId={userId}
          userEmail={userEmail}
          onClose={() => setMostrarModal(false)}
          onLogout={cerrarSesion}
        />
      )}
    </div>
  );
}

export default Navbar;
