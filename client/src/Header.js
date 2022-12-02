import React from "react";
import Tabs from "@mui/material/Tabs";
import Tab from "@mui/material/Tab";
import Box from "@mui/material/Box";
import { Icon } from "@iconify/react";
import ListAltIcon from "@mui/icons-material/ListAlt";
import { Link, useNavigate } from "react-router-dom";
import useWindowWidth from "./hooks/getWindowWidth";
function Header() {
  const navigate = useNavigate();
  const [value, setValue] = React.useState("/");

  const handleChange = (event, newValue) => {
    setValue(newValue);
    navigate(newValue);
  };
  const width = useWindowWidth();
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
          icon={<ListAltIcon style={{ fontSize: "30px" }} />}
          value="/"
          label={width > 400 ? "Menu" : ""}
        />
        <Tab
          iconPosition="start"
          icon={
            <Icon
              icon="icon-park-outline:transaction-order"
              style={{ fontSize: "30px" }}
            />
          }
          value="/MyOrders"
          label={width > 400 ? "My Orders" : ""}
        />
        <Tab
          iconPosition="start"
          icon={
            <Icon
              icon="mdi:clipboard-text-history-outline"
              style={{ fontSize: "30px" }}
            />
          }
          value="/OrderHistory"
          label={width > 400 ? "Order History" : ""}
        />
      </Tabs>
    </Box>
  );
}

export default Header;
