import './Register.css';

export default function Register() {
  return (
    <div>
      {/* ===== Formulario ===== */}
      <div className="register-container">
        <h2>¡Regístrese para poder empezar a jugar ahora!</h2>

        <form className="form-box">
          <div className="form-row">
            <input type="text" placeholder="Nombre" />
            <input type="text" placeholder="Apellido" />
          </div>
          <input type="email" placeholder="Correo Electrónico" />
          <input type="text" placeholder="Nombre de usuario" />
          <input type="password" placeholder="Contraseña" />
          <input type="password" placeholder="Confirme la contraseña" />
          <button type="submit">Siguiente</button>
          <p className="form-terms">
            Creando una cuenta, acepta nuestra{' '}
            <a href="#">política de privacidad</a> y{' '}
            <a href="#">términos de servicio</a>.
          </p>
        </form>
      </div>

      {/* ===== Footer ===== */}
      <footer className="footer">
      </footer>
    </div>
  );
}
