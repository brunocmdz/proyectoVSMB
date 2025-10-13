import Navbar from './components/Navbar';
import Footer from './components/Footer'
import Home from './components/Home';
import Login from './components/Login';
function App() {
  return (
    <div className="layout">
      <Navbar />
      <main className="content">
        <Login />
      </main>
      <Footer />
    </div>
  );
}


export default App;