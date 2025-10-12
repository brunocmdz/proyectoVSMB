import './footer.css';
import facebookIcon from '../assets/facebook-icon.png';
import instagramIcon from '../assets/instagram-icon.png';
import twitterIcon from '../assets/twitter-icon.png';

function Footer() {
  return (
    <div className="container">
        <footer className="footer">
        <div className="footer-top">
            <div className="footer-social">
                <p>Seguinos en nuestras redes:</p>
                <div className="social-icons">
                    <a href="#"><img src={facebookIcon} alt="Facebook" /></a>
                    <a href="#"><img src={instagramIcon} alt="Instagram" /></a>
                    <a href="#"><img src={twitterIcon} alt="Twitter" /></a>
                </div>
            </div>
            <div className="footer-warning">
                <p>EL JUEGO COMPULSIVO ES <strong>PERJUDICIAL</strong> PARA VOS Y TU FAMILIA.<br />COMUNICATE A LA LÍNEA
                    DE ATENCIÓN
                    <strong>GRATUITA 0800-666-6006.</strong>
                </p>
            </div>
        </div>
        <div className="footer-links">
            <a href="#">Términos y condiciones</a> |
            <a href="#">Reglas de juego</a> |
            <a href="#">Política de cookies</a> |
            <a href="#">Centro de ayuda</a> |
            <a href="#">Juego responsable</a> |
            <a href="#">Declaración de privacidad</a>
        </div>
    </footer>
    </div>
  )}

export default Footer;  