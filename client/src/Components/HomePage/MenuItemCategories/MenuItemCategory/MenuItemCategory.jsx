import React from "react";
import Accordion from "@mui/material/Accordion";
import AccordionSummary from "@mui/material/AccordionSummary";
import AccordionDetails from "@mui/material/AccordionDetails";
import ExpandMoreIcon from "@mui/icons-material/ExpandMore";
import "./MenuItemCategory.css";
import CategorizedMenuItem from "./CategorizedMenuItem/CategorizedMenuItem";
export default function MenuItemCategory({ category }) {
  const menuItems = category.menuItems;
  return (
    <Accordion className="categoryAccordion">
      <AccordionSummary
        className="categoryTitle"
        expandIcon={<ExpandMoreIcon />}
      >
        {category.name}
      </AccordionSummary>
      {menuItems &&
        menuItems.map((menuItem) => (
          <CategorizedMenuItem
            key={menuItem.id}
            name={menuItem.name}
            price={menuItem.price}
          />
        ))}
    </Accordion>
  );
}
