import React from "react";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import "./MenuItemCategory.css";
import CategorizedMenuItem from "./CategorizedMenuItem/CategorizedMenuItem";
export default function MenuItemCategory(props) {
  const menuItems = props.category.menuItems;
  return (
    <Accordion className="categoryAccordion">
      <AccordionSummary
        className="categoryTitle"
        expandIcon={<ExpandMoreIcon />}
      >
        {props.category.name}
      </AccordionSummary>
      {menuItems &&
        menuItems.map((menuItem) => (
          <CategorizedMenuItem key={menuItem.id} details={menuItem} />
        ))}
    </Accordion>
  );
}
