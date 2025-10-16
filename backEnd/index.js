const express = require('express');
const { saludar, getUsers, createUser, getUserById, getUserByEmail } = require('./controllers/controller');
const sequelize = require('./config/database');


const PORT = 3000;
const server = express();


server.use(express.json());
// Middleware para configurar los headers CORS
server.use((req, res, next) => {
  res.setHeader('Access-Control-Allow-Origin', 'http://localhost:5173')
  res.setHeader('Access-Control-Allow-Methods', 'GET, POST, PUT, DELETE, OPTIONS')
  res.setHeader('Access-Control-Allow-Headers', 'Content-Type, Authorization')
  res.setHeader('Access-Control-Allow-Credentials', 'true')
  if (req.method === 'OPTIONS') {
    return res.sendStatus(200)
  }
  next()
})
server.get('/', saludar);
server.get('/users', getUsers);
server.post('/users', createUser)
server.get('/users/:id', getUserById)
server.get('/users/:email', getUserByEmail)

sequelize.sync({ force: false })
  .then(() => {
    console.log('Base de datos conectada y sincronizada.');
    server.listen(PORT, () => {
      console.log("El server está corriendo en el puerto: " + PORT);
    });
  })
  .catch(err => {
    console.error('No se pudo conectar a la base de datos:', err);
  });
