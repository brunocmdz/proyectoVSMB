import './navbar.css';

function Navbar() {
  return (
    <div className="container">
      <nav className='navbar'>
        <div className="brand-logo">
          <a href="#" className="menu-item">V S M B</a>
        </div>
        <div className='auth-buttons'>
          <div id='login_btns'>
            <button href='#' className='menu-item' id='login'>Iniciar Sesión</button>
            <button href='#' className='menu-item' id='register'>Registrarse</button>
          </div>
        </div>
      </nav>
    </div>
  )}

export default Navbar;  