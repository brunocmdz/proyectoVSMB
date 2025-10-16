const User = require("../models/User");
async function getUsers(req, res) {
  try {
    const users = await User.findAll();
    res.json(users);
  } catch (err) {
    console.error('Error al obtener los usuarios:', err);
    res.status(500).json({ message: 'Error interno del servidor', error });
  }
}

async function createUser(req, res) {
  try {
    const user = req.body
    const newUser = await User.create(user)
    console.log(newUser.firstName);
    res.json(newUser)
  } catch (error) {
    console.log(error);
    res.status(500).json({ message: 'Error interno del servidor', error });
  }
}

async function getUserById(req, res) {
  try {
    const email = req.params.id
    const user = await User.findOne({
      where: {
        email: email
      },
      // include: [{model: User, include:[Roles]}] sirve para hacer inner join
      // attributes: ["id", "lastname"] recibe un array con los atributos especificos
    });
    res.json(user);
  } catch (err) {
    console.error('Error al obtener los usuarios:', err);
    res.status(500).json({ message: 'Error interno del servidor', error });
  }
}
async function getUserByEmail(req, res) {
  try {
    const email = req.params.email;

    const user = await User.findOne({
      where: { email }
    });

    if (!user) {
      return res.status(404).json({ message: 'Usuario no encontrado' });
    }

    res.json(user);
  } catch (error) {
    console.error('Error al obtener el usuario por email:', error);
    res.status(500).json({ message: 'Error interno del servidor', error });
  }
}
function saludar(req, res) {
  res.json({ message: 'Hola soy la API' });
}


module.exports = {
  getUserByEmail,
  getUsers,
  saludar,
  createUser,
  getUserById
};
