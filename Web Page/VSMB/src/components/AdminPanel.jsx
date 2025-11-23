import './styles/homePrivate.css';
import { useEffect, useState } from 'react';
import axios from 'axios';

function AdminPanel() {
  const [users, setUsers] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState(null);

  useEffect(() => {
    const fetchUsers = async () => {
      try {
        const userId = localStorage.getItem('userId');
        const res = await axios.get('http://localhost:3000/users', {
          headers: { Authorization: userId }
        });
        setUsers(res.data || []);
      } catch (err) {
        console.error('Error fetching users:', err);
        setError('No se pudieron obtener los usuarios');
      } finally {
        setLoading(false);
      }
    };

    fetchUsers();
  }, []);

  if (loading) return <div>Cargando usuarios...</div>;
  if (error) return <div>{error}</div>;

  return (
    <div className="admin-panel-container">
      <h2>Panel de administradores - Lista de usuarios</h2>
      <table className="admin-users-table">
        <thead>
          <tr>
            <th>ID</th>
            <th>Nombre</th>
            <th>Apellido</th>
            <th>Email</th>
            <th>Estado</th>
            <th>Acciones</th>
          </tr>
        </thead>
        <tbody>
          {users.map((u) => (
            <tr key={u.id_usuario || u.id || u.id}>
              <td>{u.id_usuario || u.id}</td>
              <td>{u.firstName}</td>
              <td>{u.lastName}</td>
              <td>{u.email}</td>
              <td>{String(u.state === true || u.state === 'true' ? 'Activo' : 'Inactivo')}</td>
              <td>
                <button
                  onClick={async () => {
                    const id = u.id_usuario || u.id;
                    const current = u.state === true || u.state === 'true';
                    const confirmMsg = current
                      ? `Confirmá que querés DESACTIVAR al usuario ${u.email}`
                      : `Confirmá que querés ACTIVAR al usuario ${u.email}`;
                    if (!window.confirm(confirmMsg)) return;
                    try {
                      const userId = localStorage.getItem('userId');
                      const res = await axios.put('http://localhost:3000/users/state', null, {
                        params: { id, state: !current },
                        headers: { Authorization: userId }
                      });
                      // actualizar la lista localmente
                      setUsers((prev) => prev.map((p) => (p.id_usuario === id || p.id === id ? res.data.user : p)));
                      alert(res.data.message || 'Estado actualizado');
                    } catch (err) {
                      console.error('Error cambiando estado:', err);
                      alert('No se pudo cambiar el estado');
                    }
                  }}
                >
                  {u.state === true || u.state === 'true' ? 'Desactivar' : 'Activar'}
                </button>
              </td>
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  );
}

export default AdminPanel;
