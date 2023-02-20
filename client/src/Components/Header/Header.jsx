import React from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Box from "@mui/material/Box";
import { Icon } from "@iconify/react";
import { Link, useNavigate } from "react-router-dom";
import "./Header.css";
import AddShoppingCartIcon from "@mui/icons-material/AddShoppingCart";
import { useSelector } from "react-redux";
import { selectMenuItemsNumber } from "../../slices/orderSlices/currentOrderSlice";

function Header() {
  const navigate = useNavigate();
  const [selectedTab, setSelectedTab] = React.useState("/");

  const menuItemsNumber = useSelector(selectMenuItemsNumber);

  const handleSelectedTabChange = (event, newSelectedTab) => {
    setSelectedTab(newSelectedTab);
    navigate(newSelectedTab);
  };
  return (
    <Box sx={{ width: "100%" }}>
      <Tabs
        value={selectedTab}
        onChange={handleSelectedTabChange}
        variant="fullWidth"
        textColor="secondary"
        indicatorColor="secondary"
      >
        <Tab
          iconPosition="start"
          icon={
            <Icon icon="material-symbols:list-alt-outline" className="icon" />
          }
          value="/"
          label={<div className="iconLabel">Menu</div>}
        />
        <Tab
          className="myOrdersTab"
          iconPosition="start"
          icon={
            <Icon icon="icon-park-outline:transaction-order" className="icon" />
          }
          value="/MyOrders"
          label={
            <div className="iconLabel">
              <div className="iconLabelValue"> My Orders</div>
              <div className="menuItemsNumberInCurrentOrder">
                {menuItemsNumber >= 1 ? (
                  <div>
                    <AddShoppingCartIcon />
                    <div>{menuItemsNumber}</div>
                  </div>
                ) : (
                  ""
                )}
              </div>
            </div>
          }
        />
        <Tab
          iconPosition="start"
          icon={
            <Icon icon="mdi:clipboard-text-history-outline" className="icon" />
          }
          value="/OrderHistory"
          label={<div className="iconLabel">Order History</div>}
        />
      </Tabs>
    </Box>
  );
}

export default Header;
