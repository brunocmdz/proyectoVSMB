import './navbar.css';

function Navbar({ onRegisterClick,onLoginClick,onHomeClick }) { 
  return (
    <div className="container">
      <nav className='navbar'>
        <div className="brand-logo">
          <a onClick={onHomeClick} className="menu-item">V S M B</a>
        </div>
        <div className='auth-buttons'>
          <div id='login_btns'>
            <button className='menu-item' onClick={onLoginClick} id='login'>Iniciar Sesión</button>
            <button className='menu-item' onClick={onRegisterClick} id='register'>Registrarse</button>
          </div>
        </div>
      </nav>
    </div>
  );
}

export default Navbar;
