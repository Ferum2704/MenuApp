import React from "react";
import Header from "../Header/Header";
import Footer from "../Footer/Footer";
import { Container } from "reactstrap";
import "./Layout.css";
export default function Layout(props) {
  return (
    <div>
      <Header />
      <Container>{props.children}</Container>
      <Footer />
    </div>
  );
}
