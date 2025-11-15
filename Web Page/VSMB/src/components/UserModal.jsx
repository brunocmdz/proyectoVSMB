import './styles/UserModal.css';

function UserModal({ userName, userId, userEmail, onClose, onLogout }) {
  return (
    <div className="modal-overlay" onClick={onClose}>
      <div className="modal-content" onClick={(e) => e.stopPropagation()}>
        <h2>Datos del usuario</h2>
        <p><strong>Nombre:</strong> {userName}</p>
        <p><strong>ID:</strong> {userId}</p>
        <p><strong>Email:</strong> {userEmail}</p>
        <button className="btn-cerrar-sesion" onClick={onLogout}>Cerrar sesión</button>
      </div>
    </div>
  );
}

export default UserModal;
