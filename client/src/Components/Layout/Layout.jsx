import React from "react";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import { Container } from "reactstrap";
import "./Layout.css";
import Login from "../Login/Login";
import { selectIsOpenDialog } from "../../slices/loginSlice";
import { useSelector } from "react-redux";
export default function Layout(props) {
  const isOpenDialog = useSelector(selectIsOpenDialog);
  return (
    <div>
      <Header />
      <Container>{props.children}</Container>
      <Footer />
      <Login isLoginDialogOpen={isOpenDialog} />
    </div>
  );
}
