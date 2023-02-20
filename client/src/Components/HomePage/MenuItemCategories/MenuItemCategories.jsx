import React from "react";
import { useEffect } from "react";
import { Container } from "@mui/system";
import MenuItemCategory from "./MenuItemCategory/MenuItemCategory";
import "./MenuItemCategories.css";
import { useSelector, useDispatch } from "react-redux";
import {
  selectAllMenuItems,
  selectMenuItemsStatus,
  selectMenuItemsError,
  fetchCategorizedItems,
} from "../../../slices/menuItemsSlice";
import { renderResultByStatus } from "../../../helpers/renderHelper";
import { REQUEST_STATUSES } from "../../../constants/apiRequestStatus";

export default function MenuItemCategories() {
  const dispatch = useDispatch();
  const categorizedItems = useSelector(selectAllMenuItems);
  const menuItemsStatus = useSelector(selectMenuItemsStatus);
  const error = useSelector(selectMenuItemsError);

  const successResult =
    categorizedItems &&
    categorizedItems.map((category) => (
      <MenuItemCategory key={category.id} category={category} />
    ));
  useEffect(() => {
    if (
      menuItemsStatus === REQUEST_STATUSES.idle ||
      menuItemsStatus === REQUEST_STATUSES.failed
    ) {
      dispatch(fetchCategorizedItems());
    }
  }, []);

  return (
    <Container maxWidth="lg" className="menuItemCategories">
      {renderResultByStatus(menuItemsStatus, error, successResult)}
    </Container>
  );
}
