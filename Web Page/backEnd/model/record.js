const sequelize = require('../config/database');
const { DataTypes } = require('sequelize');

const Record = sequelize.define('Record',
    {
        id_record: {
        type: DataTypes.INTEGER,
        autoIncrement: true,
        primaryKey: true
        },
        name: {
            type: DataTypes.STRING,
            allowNull: false
        },
        content: {
            type: DataTypes.STRING,
            allowNull: false
        },
        userId: {
            type: DataTypes.STRING,
            allowNull: false
        },
    },
    {
        tableName: 'Record',
        timestamps: true
    }
)

module.exports = Record;
