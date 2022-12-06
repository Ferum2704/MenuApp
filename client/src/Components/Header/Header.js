import React from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Box from "@mui/material/Box";
import { Icon } from "@iconify/react";
import { Link, useNavigate } from "react-router-dom";
import "./Header.css";
function Header() {
  const navigate = useNavigate();
  const [value, setValue] = React.useState("/");

  const handleChange = (event, newValue) => {
    setValue(newValue);
    navigate(newValue);
  };
  return (
    <Box sx={{ width: "100%" }}>
      <Tabs
        value={value}
        onChange={handleChange}
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
          iconPosition="start"
          icon={
            <Icon icon="icon-park-outline:transaction-order" className="icon" />
          }
          value="/MyOrders"
          label={<div className="iconLabel">My Orders</div>}
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
