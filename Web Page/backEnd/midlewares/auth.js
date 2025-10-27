import User from '../model/user.js'; 

export const isAuth = async (req, res, next) => {
  const authHeader = req.headers['authorization'];

  if (!authHeader) {
    return res.status(401).json({ message: "No existe id" });
  }
  const user = await User.findByPk(authHeader);
  if (!user) {
    return res.status(403).json({ message: "Usuario no válido" });
  }
  next();
};

export const isAdmin = (req, res, next) => {
  const user = req.user;
  if (user && user.isAdmin) {
    next();
  } else {
    res.status(401).send('No es admin');
  }
};
