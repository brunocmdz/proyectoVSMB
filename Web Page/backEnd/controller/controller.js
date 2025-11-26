const User = require('../model/user');
const Template = require('../model/templates');
const Record = require('../model/record');
const Notification = require('../model/notifications');
const { Op } = require('sequelize');
const bcrypt = require('bcrypt');

const notification = async (req, res) => {
    try {
        const { userId, title, message } = req.body;
        
        // Validar campos requeridos
        if (!title || !message) {
            return res.status(400).json({ message: 'Título y mensaje son requeridos' });
        }
        
        const newNotification = await Notification.create({
            title,
            message,
            idUsuario: userId || null,
            allUsers: userId ? false : true
        });
        
        res.status(201).json({ 
            message: 'Notificación creada exitosamente',
            notification: newNotification 
        });
    } catch (err) {
        console.error('Error al crear la notificación:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
};
const getNotifications = async(req, res) => {
    try {
        const userId = req.headers.authorization;
        
        // Traer notificaciones del usuario actual o notificaciones para todos
        const notifications = await Notification.findAll({
            where: {
                [Op.or]: [
                    { idUsuario: userId },
                    { allUsers: true }
                ]
            }
        });
        res.json(notifications);
    } catch (err) {
        console.error('Error al obtener las notificaciones:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
}
const editUser = async(req, res) => {
    try {
        const {firstName, lastName,  id_usuario } = req.query;
        const users = await User.update(
            { firstName, lastName },
            { where: { id_usuario } }
        );
        res.json(users);
    } catch (err) {
        console.error('Error al obtener los usuarios:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
};
const getUser = async(_req, res) => {
    try {
        const users = await User.findAll();
        res.json(users);
    } catch (err) {
        console.error('Error al obtener los usuarios:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
};
const getUserByEmail = async(req, res) => {
    try {
        const email = req.params.email;
        const users = await User.findOne({
            where : {email}
        });
        res.json(users);
    } catch (err) {
        console.error('Error al obtener los usuarios:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
};

const fixFile = async (req, res) => {

};

const getTemplates = async(_req, res) => {
    try {
        const templates = await Template.findAll();
        res.json(templates);
    } catch (err) {
        console.error('Error al obtener las plantillas:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
};

const uploadTemplate = async (req, res) => {
    try {
        const { nameTemplate, versionTemplate, content } = req.body || {};

        let finalContent = content;
        if (!finalContent && req.file && req.file.buffer) {
            finalContent = req.file.buffer.toString('utf8');
        }
        if (!finalContent) {
            return res.status(400).json({ message: 'Falta contenido de la plantilla (campo content) o archivo .txt' });
        }
        const tpl = await Template.create({ content: finalContent, versionTemplate, nameTemplate });
        
        // Crear notificación para todos los usuarios
        await Notification.create({
            title: 'Nueva plantilla',
            message: `Se ha subido una nueva plantilla: ${nameTemplate || 'Sin nombre'}`,
            allUsers: true
        });
        
        res.json(tpl);
    } catch (err) {
        console.error('Error subiendo la plantilla:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
};

const deleteTemplate = async (req, res) => {
    try {
        const id = req.params.id;
        if (!id) return res.status(400).json({ message: 'Falta id de plantilla' });
        
        // Obtener info de la plantilla antes de borrarla
        const template = await Template.findOne({ where: { idPlantilla: id } });
        
        const deleted = await Template.destroy({ where: { idPlantilla: id } });
        if (deleted === 0) return res.status(404).json({ message: 'Plantilla no encontrada' });
        
        // Crear notificación para todos los usuarios
        await Notification.create({
            title: 'Plantilla eliminada',
            message: `Se ha eliminado la plantilla: ${template?.nameTemplate || 'ID ' + id}`,
            allUsers: true
        });
        
        res.json({ message: 'Plantilla eliminada', id });
    } catch (err) {
        console.error('Error eliminando plantilla:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
};
const setUserState = async (req, res) => {
    try {
        const { id, state } = req.query;
        if (!id) {
            return res.status(400).json({ message: 'Falta id del usuario' });
        }
        // convertir state a boolean (acepta 'true'/'false', '1'/'0', boolean)
        const newState = (state === true);

        const [updated] = await User.update(
            { state: newState },
            { where: { id_usuario: id } }
        );

        if (updated === 0) {
            return res.status(404).json({ message: 'Usuario no encontrado o sin cambios' });
        }

        const updatedUser = await User.findOne({ where: { id_usuario: id } });
        res.json({ message: 'Estado actualizado', user: updatedUser });
    } catch (err) {
        console.error('Error actualizando estado de usuario:', err);
        res.status(500).json({ message: 'Error interno del servidor' });
    }
};
async function registerUser(req, res) {
    try {
        const { email, password, firstName, lastName } = req.query;

        // Encriptar la contraseña antes de guardar
        const hashedPassword = await bcrypt.hash(password, 10);

        const users = await User.create({
            email,
            password: hashedPassword,  // ← ya encriptada
            firstName,
            lastName,
            state: true
        });

        res.json(users);

    } catch (err) {
        console.error('Error al obtener los usuarios:', err);
        res.status(500).json({ message: 'Error interno del servidor', error: err.message });
    }
};
async function login(req, res) {
  try {
    const { email, password } = req.query;

    // Buscar usuario solo por email
    const user = await User.findOne({ where: { email } });

    if (!user) {
      return res.status(401).json({ message: "Credenciales inválidas" });
    }

<<<<<<< HEAD
    // Comparar contraseña encriptada
    const isMatch = await bcrypt.compare(password, user.password);

    if (!isMatch) {
      return res.status(401).json({ message: "Credenciales inválidas" });
    }

    // impedir login si el usuario está desactivado
    if (user.state === false || user.state === 'false' || user.state === 0) {
        return res.status(403).json({ message: 'Usuario desactivado' });
    }
=======
        // impedir login si el usuario está desactivado
        if (user.state === false) {
            return res.status(403).json({ message: 'Usuario desactivado' });
        }
>>>>>>> 044c82aa6d222c77ac3cae29beb8caef741134b7

    res.json({
      id: user.id_usuario,
      firstName: user.firstName,
      lastName: user.lastName,
      email: user.email,
      isAdmin: user.isAdmin
    });

  } catch (err) {
    console.error("Error al obtener los usuarios:", err);
    res.status(500).json({ message: "Error interno del servidor", err });
  }
};
module.exports = { notification, getNotifications, getUser, registerUser, getUserByEmail, login, editUser, setUserState, getTemplates, uploadTemplate, deleteTemplate, fixFile };

