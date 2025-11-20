import './styles/UserModal.css';
import { useState, useEffect} from 'react';
import axios from 'axios';

function UserModalEdit({userName, userLastName, userEmail }) {
    const [email, setEmail] = useState(''); 
    const [firstName, setFirstName] = useState(''); 
    const [lastName, setLastName] = useState(''); 
    useEffect(() => {
    setEmail(userEmail);
    setFirstName(userName);
    setLastName(userLastName);
    }, [userEmail, userName, userLastName]);
    const id = localStorage.getItem("userId");
    
  const editarDatos = async () => {
    const confirmar = window.confirm("¿Seguro que querés guardar los cambios?");
    if (!confirmar) return; 

    try {
      await axios.post(`http://localhost:3000/users/editUser/?email=${email}&firstName=${firstName}&lastName=${lastName}&id=${id}`);
      localStorage.setItem("userName", firstName);
      localStorage.setItem("userLastName", lastName);
      localStorage.setItem("userEmail", email);
      alert("Datos actualizados");
      window.location.reload(); 
    } catch (error) {
      alert(error.message);
    }
  };

  return (
    <div className="modal-overlay">
      <div className="modal-content">
        <h2>Editar usuario</h2>
        <p>Nombre: <input onChange={(e) => setFirstName(e.target.value)} value={firstName} /></p>
        <p>Apellido: <input onChange={(e) => setLastName(e.target.value)} value={lastName} /></p>
        <p>Email: <input onChange={(e) => setEmail(e.target.value)} value={email} /></p>
        <button className="btn-guardar" onClick={editarDatos}>Guardar</button>
      </div>
    </div>
  );
}

export default UserModalEdit;
