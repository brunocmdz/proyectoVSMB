const { Sequelize } = require('sequelize');

const sequelize = new Sequelize('dbVSMB' /*nombre db*/, 'postgres' /* usuario db */, '1234' /* contraseña db */, {
  host: 'localhost' /* servidor de base de datos */,
  dialect: 'postgres' /* motor de base de datos */,
  logging: false, /* muestreo en la consola de la creacion de los modelos de base de datos */
});

module.exports = sequelize;
