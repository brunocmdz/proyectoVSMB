import './Login.css';

function Login() {
  return (
    <div className="login-container">
      <div className="login-box">
        <h1>¡Inicie sesión para poder descargar<br />el comparador ahora!</h1>

        <input type="email" placeholder="Correo electrónico" />
        <input type="password" placeholder="Contraseña" />

        <div className="checkbox">
          <label>
            <input type="checkbox" /> Recuérdame
          </label>
          <a href="#">¿Olvidé mi contraseña?</a>
        </div>

        <button className="btn-siguiente">Siguiente</button>

        <div className="registro">
          <span>¿No tiene cuenta?</span>
          <a href="#" className="registrar-link">Registrar</a>
        </div>
      </div>
    </div>
  );
}

export default Login;
