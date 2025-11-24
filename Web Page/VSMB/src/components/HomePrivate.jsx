import React, { useState, useEffect } from 'react';
import axios from 'axios';

const HomePrivate = () => {
  const [templates, setTemplates] = useState([]);
  const [selectedId, setSelectedId] = useState(null);
  const [fileData, setFileData] = useState({ name: '', content: '' });

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

  const handleFileChange = (e) => {
    const file = e.target.files[0];
    if (file && file.type === 'text/plain') {
      const reader = new FileReader();
      reader.onload = () => {
        setFileData({ name: file.name, content: reader.result });
      };
      reader.readAsText(file);
    } else {
      alert('Por favor selecciona un archivo .txt');
    }
  };

  const uploadFile = async () => {
    try {
      const userId = localStorage.getItem('userId');
      const { name, content } = fileData;
  
      if (!name || !content) {
        alert('No se ha seleccionado un archivo válido.');
        return;
      }
  
      if (!selectedId) {
        alert('Por favor selecciona una plantilla.');
        return;
      }
  
      const res = await axios.post('http://localhost:3000/fixFile', {
        userId,
        fileName: name,
        fileContent: content,
        templateId: selectedId, // Enviar el ID de la plantilla seleccionada
      });
  
      alert('Archivo y plantilla enviados con éxito:', res.data);
    } catch (err) {
      console.error('Error al subir el archivo y la plantilla:', err);
    }
  };

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
            {templates.map((t) => (
              <option key={t.idPlantilla || t.id} value={t.idPlantilla || t.id}>
                {t.nameTemplate} (v{t.versionTemplate})
              </option>
            ))}
          </select>
        </div>

        <div className="file-upload-section">
          <h3>Subir archivo</h3>
          <input type="file" accept=".txt" onChange={handleFileChange} />
          <button onClick={uploadFile}>Subir archivo</button>
        </div>
      </div>
    </div>
  );
};

export default HomePrivate;