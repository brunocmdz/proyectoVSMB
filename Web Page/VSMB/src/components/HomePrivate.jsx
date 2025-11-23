import './styles/homePrivate.css';
import axios from 'axios';
import { useEffect, useState } from 'react';

function HomePrivate() {
  // State para las plantillas y la plantilla seleccionada
  const [templates, setTemplates] = useState([]);
  const [selectedId, setSelectedId] = useState(null);

  // Plantilla seleccionada (objeto) derivado del id
  const selectedTemplate = templates.find(t => (t.idPlantilla || t.id) === selectedId) || null;

  // Al montar, traer las plantillas desde el backend
  useEffect(() => {
    const fetchTemplates = async () => {
      try {
        const userId = localStorage.getItem('userId');
        const res = await axios.get('http://localhost:3000/templates', { headers: { Authorization: userId } });
        setTemplates(res.data || []);
      } catch (err) {
        console.error('Error fetching templates:', err);
      }
    };
    fetchTemplates();
  }, []);

  return (
    <div className="home-private-container">
      <div className="home-private-section">
        <h2>Plantilla</h2>
        <div className="home-private-drop">
          {/* Menú para seleccionar una plantilla existente */}
          <select
            className="home-private-select"
            value={selectedId || ''}
            onChange={(e) => setSelectedId(e.target.value ? Number(e.target.value) : null)}
          >
            <option value="">-- Seleccioná una plantilla --</option>
            {templates.map(t => (
              <option key={t.idPlantilla || t.id} value={t.idPlantilla || t.id}>{t.nameTemplate} (v{t.versionTemplate})</option>
            ))}
          </select>
        </div>

        {/* Vista previa sencilla del contenido de la plantilla seleccionada */}
        {selectedTemplate && (
          <div style={{ marginTop: 12 }}>
            <strong>Preview:</strong>
            <pre className="home-private-preview" style={{ maxHeight: 160, overflow: 'auto', background: '#0f1112', padding: 10, color: '#fff' }}>
              {selectedTemplate.content}
            </pre>
          </div>
        )}
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