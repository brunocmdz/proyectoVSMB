import './styles/homePrivate.css';
import './styles/AdminPanel.css';

import { useEffect, useState } from 'react';
import axios from 'axios';

function AdminPanel() {
  const [users, setUsers] = useState([]);
  const [templates, setTemplates] = useState([]);
  const [tplName, setTplName] = useState('');
  const [tplVersion, setTplVersion] = useState('1.0');
  const [tplFile, setTplFile] = useState(null);
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

    const fetchTemplates = async () => {
      try {
        const userId = localStorage.getItem('userId');
        const res = await axios.get('http://localhost:3000/templates', { headers: { Authorization: userId } });
        setTemplates(res.data || []);
      } catch (err) {
        console.error('Error fetching templates:', err);
      }
    };

    fetchUsers();
    fetchTemplates();
  }, []);

  if (loading) return <div>Cargando usuarios...</div>;
  if (error) return <div>{error}</div>;

  return (
    <div>
      <h2>Gestion de plantillas</h2>
      <div className="templates-section">
        <form className="templates-form" onSubmit={async (e) => {
          e.preventDefault();
          if (!tplFile) return alert('Seleccioná un archivo .txt');
          if (!tplName) return alert('Ingresá un nombre para la plantilla');
          try {
            const userId = localStorage.getItem('userId');
            const text = await tplFile.text();
            const payload = { nameTemplate: tplName, versionTemplate: tplVersion, content: text };
            const res = await axios.post('http://localhost:3000/templates/upload', payload, { headers: { Authorization: userId } });
            // actualizar lista
            setTemplates((prev) => [res.data, ...prev]);
            setTplName(''); setTplVersion('1.0'); setTplFile(null);
            alert('Plantilla subida');
          } catch (err) {
            console.error('Error subiendo plantilla:', err);
            alert('No se pudo subir la plantilla');
          }
        }}>
          <div className="field">
            <label>Nombre plantilla</label>
            <input type="text" value={tplName} onChange={(e) => setTplName(e.target.value)} />
          </div>

          <div className="field">
            <label>Versión</label>
            <input type="text" value={tplVersion} onChange={(e) => setTplVersion(e.target.value)} />
          </div>

          <div className="field file-field">
            <label>Archivo .txt</label>
            <div className="file-control">
              <input id="tplFileInput" className="real-file-input" type="file" accept=".txt,text/plain" onChange={(e) => setTplFile(e.target.files?.[0] || null)} />
              <label htmlFor="tplFileInput" className="file-btn btn-ghost">Seleccionar archivo</label>
              <span className="file-name">{tplFile?.name ? tplFile.name : 'Sin archivos seleccionados'}</span>
            </div>
          </div>

          <div style={{ display: 'flex', alignItems: 'flex-end', gap: 10 }}>
            <button className="btn btn-primary" type="submit">Subir plantilla</button>
            <button type="button" className="btn btn-ghost" onClick={() => { setTplName(''); setTplVersion('1.0'); setTplFile(null); }}>Limpiar</button>
          </div>
        </form>

        <table className="templates-table" aria-label="Plantillas">
          <thead>
            <tr>
              <th>Nombre</th>
              <th>Versión</th>
              <th>Contenido (preview)</th>
              <th style={{ width: 150, textAlign: 'right' }}>Acciones</th>
            </tr>
          </thead>
          <tbody>
            {templates.map((t) => (
              <tr key={t.idPlantilla || t.id}>
                <td>{t.nameTemplate}</td>
                <td>{t.versionTemplate}</td>
                <td><div className="template-content">{t.content}</div></td>
                <td className="template-actions">
                  <button className="btn btn-ghost" onClick={() => {
                    const w = window.open('', '_blank');
                    if (w) {
                      w.document.write('<pre>' + (t.content || '').replace(/</g, '&lt;') + '</pre>');
                      w.document.title = t.nameTemplate || 'Plantilla';
                    }
                  }}>Ver</button>
                  <button className="btn btn-ghost" onClick={() => {
                    const blob = new Blob([t.content || ''], { type: 'text/plain;charset=utf-8' });
                    const url = URL.createObjectURL(blob);
                    const a = document.createElement('a');
                    a.href = url;
                    a.download = (t.nameTemplate || 'plantilla') + '.txt';
                    document.body.appendChild(a);
                    a.click();
                    a.remove();
                    URL.revokeObjectURL(url);
                  }}>Descargar</button>
                  <button className="btn btn-ghost" onClick={async () => {
                      if (!window.confirm(`Confirmá que querés eliminar la plantilla "${t.nameTemplate}"`)) return;
                      try {
                        const userId = localStorage.getItem('userId');
                        await axios.delete(`http://localhost:3000/templates/${t.idPlantilla || t.id}`, { headers: { Authorization: userId } });
                        setTemplates((prev) => prev.filter(p => (p.idPlantilla || p.id) !== (t.idPlantilla || t.id)));
                        alert('Plantilla eliminada');
                      } catch (err) {
                        console.error('Error eliminando plantilla:', err);
                        alert('No se pudo eliminar la plantilla');
                      }
                    }}>Borrar</button>
                </td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>

      <h2>Gestión de usuarios</h2>
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
                <button>
                  Notificar
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
