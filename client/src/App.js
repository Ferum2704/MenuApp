import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Layout from "./Layout";
import MenuItems from "./HomePageComponents/MenuItems";
import MenuItemInfo from "./MenuItemPageComponents/MenuItemInfo";
import MyOrders from "./MyOrdersPageComponents/MyOrders";
import OrderHistory from "./OrderHistoryPageComponents/OrderHistory";
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
