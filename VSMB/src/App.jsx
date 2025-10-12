import Navbar from './components/Navbar';
import Footer from './components/Footer'
import Home from './components/Home';
function App() {
  return (
    <div className="layout">
      <Navbar />
      <main className="content">
        <Home />
      </main>
      <Footer />
    </div>
  );
}


export default App;