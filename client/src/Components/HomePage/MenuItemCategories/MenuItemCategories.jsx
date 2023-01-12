import React from "react";
import { useEffect } from "react";
import { Container } from "@mui/system";
import MenuItemCategory from "./MenuItemCategory/MenuItemCategory";
import "./MenuItemCategories.css";
import { useSelector, useDispatch } from "react-redux";
import Spinner from "react-bootstrap/Spinner";
import {
  selectAllMenuItems,
  selectMenuItemsStatus,
  selectMenuItemsError,
  fetchCategorizedItems,
} from "../../../slices/menuItemsSlice";
import { REQUEST_STATUSES } from "../../../constants/apiRequestStatus";

export default function MenuItemCategories() {
  const dispatch = useDispatch();
  const categorizedItems = useSelector(selectAllMenuItems);

  const menuItemsStatus = useSelector(selectMenuItemsStatus);
  const error = useSelector(selectMenuItemsError);

  useEffect(() => {
    if (menuItemsStatus === REQUEST_STATUSES.idle) {
      dispatch(fetchCategorizedItems());
    }
  }, [menuItemsStatus, dispatch]);

  const renderMenuItems = (status) => {
    switch (status) {
      case REQUEST_STATUSES.loading:
        return (
          <div>
            <Spinner
              as="span"
              animation="border"
              size="sm"
              role="status"
              aria-hidden="true"
            />
            Loading...
          </div>
        );
      case REQUEST_STATUSES.succeeded:
        return (
          categorizedItems &&
          categorizedItems.map((category) => (
            <MenuItemCategory key={category.id} category={category} />
          ))
        );
      case REQUEST_STATUSES.failed:
        return <div className="error">{error}</div>;
      default:
        break;
    }
  };
  return (
    <Container maxWidth="lg" className="menuItemCategories">
      {renderMenuItems(menuItemsStatus)}
    </Container>
  );
}
