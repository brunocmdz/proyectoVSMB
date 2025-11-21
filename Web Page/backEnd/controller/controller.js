const User = require('../model/user');
const Template = require('../model/templates');
const Record = require('../model/record');
const Notification = require('../model/notifications');

const editUser = async(req, res) => {
    try {
        const { email, firstName, lastName, id } = req.query;
        const users = await User.update(
            { firstName, lastName, email },
            { where: { id } }
        );
        res.json(users);
    } catch (err) {
        console.error('Error al obtener los usuarios:', err);
        res.status(500).json({ message: 'Error interno del servidor', error });
    }
};
const getUser = async(_req, res) => {
    try {
        const users = await User.findAll();
        res.json(users);
    } catch (err) {
        console.error('Error al obtener los usuarios:', err);
        res.status(500).json({ message: 'Error interno del servidor', error });
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
        res.status(500).json({ message: 'Error interno del servidor', error });
    }
};
async function registerUser(req, res) {
    try {
        const { email, password, firstName, lastName } = req.query;
        const users = await User.create({
            email,
            password,
            firstName,
            lastName
        });
        res.json(users);
    } catch (err) {
        console.error('Error al obtener los usuarios:', err);
        res.status(500).json({ message: 'Error interno del servidor', error });
    }
};
async function login(req, res) {
  try {
    const { email, password } = req.query;
    const user = await User.findOne({ where: { email, password } });

    if (!user) {
      return res.status(401).json({ message: "Credenciales inválidas" });
    }

    res.json({
        id: user.id,
        firstName: user.firstName,
        lastName: user.lastName,
        email: user.email
    });
  } catch (err) {
    console.error("Error al obtener los usuarios:", err);
    res.status(500).json({ message: "Error interno del servidor", err });
  }
};
module.exports = { getUser, registerUser, getUserByEmail, login, editUser };

