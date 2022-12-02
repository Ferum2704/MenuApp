import React from "react";
import Header from "./Header";
import Footer from "./Footer";
import { Container } from "reactstrap";
import "./css/Layout.css";
export default function Layout(props) {
  return (
    <div>
      <Header />
      <Container>{props.children}</Container>
      <Footer />
    </div>
  );
}
