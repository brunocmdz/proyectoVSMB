import './styles/homePrivate.css';
import axios from 'axios';
import img from '../assets/imagenmuimportante.png';

function HomePrivate({ onRegisterClick }) {
  return (
    <div className="home-private-container">
      <div className="home-private-section">
        <h2>Archivo madre</h2>
        <div className="home-private-drop">
          <button className="home-private-btn">Seleccionar archivo</button>
          <p>o arrastra tu archivo aquí</p>
        </div>
      </div>

      <div className="home-private-section">
        <h2>Archivo a comparar</h2>
        <div className="home-private-drop">
          <button className="home-private-btn">Seleccionar archivo</button>
          <p>o arrastra tu archivo aquí</p>
        </div>
      </div>

      <div className="home-private-actions">
        <button className="home-private-btn">Comparar</button>
        <button className="home-private-btn">Limpiar</button>
        <button className="home-private-btn">Descargar</button>
        <button className="home-private-btn">Guardar</button>
      </div>
    </div>
  );
}

export default HomePrivate;