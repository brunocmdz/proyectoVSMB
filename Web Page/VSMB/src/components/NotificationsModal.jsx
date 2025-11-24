import './styles/notificationsModal.css';
import { useState, useEffect } from 'react';
import axios from 'axios';

function NotificationsModal({ onClose }) {
  // Lista de notificaciones obtenidas desde el backend
  const [contentNotification, setContentNotifications] = useState([]);
  const [loading, setLoading] = useState(false);
  const [error, setError] = useState(null);

  // Petición para obtener notificaciones
  const fetchNotifications = async () => {
    setLoading(true);
    setError(null);
    try {
      const userId = localStorage.getItem('userId');
      const res = await axios.get('http://localhost:3000/notifications', { headers: { Authorization: userId } });
      setContentNotifications(res.data || []);
    } catch (err) {
      console.error('Error fetching notifications:', err);
      setError('No se pudieron obtener las notificaciones');
    } finally {
      setLoading(false);
    }
  };

  // Al montar, cargar notificaciones
  useEffect(() => {
    fetchNotifications();
  }, []);

  return (
    <div className="notifications-modal">
      <div className="notifications-header">
        <h3>Notificaciones</h3>
        <div className="notifications-actions">
          <button className="btn" onClick={fetchNotifications}>Refrescar</button>
          {onClose && <button className="btn" onClick={onClose}>Cerrar</button>}
        </div>
      </div>

      {loading && <p>Cargando...</p>}
      {error && <p className="error">{error}</p>}

      {!loading && !error && (
        <div className="notifications-table-wrap">
          <table className="notifications-table">
            <thead>
              <tr>
                <th>ID</th>
                <th>Título</th>
                <th>Mensaje</th>
                <th>Estado</th>
                <th>Fecha</th>
              </tr>
            </thead>
            <tbody>
              {contentNotification.length === 0 ? (
                <tr><td colSpan={5} style={{ textAlign: 'center' }}>No hay notificaciones</td></tr>
              ) : (
                contentNotification.map((n) => (
                  <tr key={n.id_notification || n.id}>
                    <td>{n.id_notification || n.id}</td>
                    <td>{n.title}</td>
                    <td style={{ maxWidth: 420, whiteSpace: 'nowrap', overflow: 'hidden', textOverflow: 'ellipsis' }}>{n.message}</td>
                    <td>{n.checked ? 'Leído' : 'No leído'}</td>
                    <td>{n.createdAt ? new Date(n.createdAt).toLocaleString() : ''}</td>
                  </tr>
                ))
              )}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
}

export default NotificationsModal;
