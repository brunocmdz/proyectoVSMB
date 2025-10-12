import './App.css';
import logo from './assets/vsmb-logo.png';

function App() {
  return (
    <div className="container">
      {/* Navbar */}
      <nav className='navbar'>
        <div className="brand-logo">
          <a href="#" class="menu-item">VSMB</a>
        </div>
        <div className='auth-buttons'>
          <div id='login_btns'>
            <button href='#' class='menu-item' id='login'>Iniciar Sesión</button>
            <button href='#' class='menu-item' id='register'>Registrarse</button>
          </div>
        </div>
      </nav>

      {/* Top Section */}
      <header className="top-section" id="inicio">
        <div className="intro-box">
          <h1>Con VSMB comparar archivos nunca fue tan fácil</h1>
          <p>
            Descubrí las diferencias, encontrá errores, mejorá tus procesos y mantené tus documentos siempre organizados.
            Empezá ahora y dejá que VSMB haga el trabajo por vos. ¡No pierdas más tiempo y vamos a aprovecharlo al máximo!
          </p>
        </div>
      </header>

      {/* Middle Section */}
      <section className="middle-section" id="funcionalidad">
        <p>
          ¿Tenés varios archivos parecidos y no sabés cuál es la versión más reciente o cuál cambió?
          Comparador de Archivos es la herramienta ideal para detectar diferencias entre documentos, copias, o versiones.
          Este sistema fue creado especialmente para que puedas comparar de manera rápida y simple tu trabajo.
          VSMB te permite resaltar los cambios y te permite exportar los resultados. Es compatible con múltiples tipos de archivos,
          incluyendo texto, hojas de cálculo y presentaciones.
        </p>
        <button className="download-btn" id="descarga">DESCARGAR AHORA</button>
      </section>

      {/* Bottom Section */}
      <footer className="bottom-section" id="contacto">
        <p>SEGUINOS EN NUESTRAS REDES</p>
        <div className="social-icons">
          <i className="fa-brands fa-facebook"></i>
          <i className="fa-brands fa-twitter"></i>
          <i className="fa-brands fa-instagram"></i>
        </div>
        <small>
          Página desarrollada en la Escuela Técnica N°26 "Confederación Suiza"<br />
          Integrantes: Bruno Rojas-Shandee Ignacio-Marcos Ortiz-Morales Victor
        </small>
      </footer>
    </div>
  );
}

export default App;
