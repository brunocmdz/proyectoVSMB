const sequelize = require('../config/database');
const { DataTypes } = require('sequelize');

const Template = sequelize.define('Template',
    {
        content: {
            type: DataTypes.STRING,
            unique: true,
            allowNull: false,
            validate: {
                isEmail: true
            }
        },
        versionTemplate: {
            type: DataTypes.STRING,
            allowNull: false
        },
        nameTemplate: {
            type: DataTypes.STRING,
            allowNull: false
        },
        lastName: {
            type: DataTypes.STRING,
            allowNull: false
        },
        idPlantilla: {
            type: DataTypes.INTEGER,
            autoIncrement: true,
            primaryKey: true
        }
    },
    {
        tableName: 'Template',
        timestamps: false
    }
)

module.exports = Templates;
