import './App.css';
import {Router, BrowserRouter as Router, Route} from "react-router-dom";
import Layout from './Layout';
import MenuItems from './HomePageComponents/MenuItems';
function App() {
  return (
    <div className="App">
      <Router>
        <Layout>
          <Routes>
            <Route path='/' element={<MenuItems/>}/>
          </Routes>
        </Layout>
      </Router>
    </div>
  );
}

export default App;
