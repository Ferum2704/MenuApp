import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Layout from "./Components/Layout/Layout";
import MenuItems from "./Components/HomePage/MenuItems";
import MyOrders from "./Components/MyOrdersPage/MyOrders";
import OrderHistory from "./Components/OrderHistoryPage/OrderHistory";
function App() {
  return (
    <div className="App">
      <Router>
        <Layout>
          <Routes>
            <Route path="/" element={<MenuItems />} />
            <Route path="/MyOrders" element={<MyOrders />} />
            <Route path="/OrderHistory" element={<OrderHistory />} />
          </Routes>
        </Layout>
      </Router>
    </div>
  );
}

export default App;
