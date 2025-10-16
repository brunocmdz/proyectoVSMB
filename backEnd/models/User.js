const { DataTypes } = require('sequelize');
const sequelize = require('../config/database');


const User = sequelize.define('User',
  {
    email: {
      type: DataTypes.STRING,
      unique: true,
      allowNull: false,
      validate: {
        isEmail: true
      }
    },
    password: {
      type: DataTypes.STRING,
      allowNull: false
    }

  },
  {
    tableName: 'User',
    timestamps: false
  }
);


module.exports = User;
