import { Container } from "@mui/system";
import React from "react";
import { Grid } from "@mui/material";
import { SocialIcon } from "react-social-icons";
import "./css/Footer.css";
export default function () {
  return (
    <Container
      maxWidth="md"
      sx={{ bgcolor: "yellow", borderTop: 3, height: "20%" }}
    >
      <Grid
        container
        justifyContent="space-between"
        flexDirection={{ sm: "column", md: "row" }}
      >
        <div style={{ textAlign: "left" }}>
          <span style={{ fontSize: 25 }}>Contacts:</span>
          <span style={{ fontSize: 20 }}>
            <br></br>Address: Ivana Fedorova street, 10
          </span>
          <span style={{ fontSize: 20 }}>
            <br></br>Phone number: 050-458-34-41
          </span>
        </div>
        <div className="networks">
          <div>
            <SocialIcon network="twitter" />
          </div>
          <div>
            <SocialIcon network="facebook" />
          </div>
          <div>
            <SocialIcon network="instagram" />
          </div>
        </div>
      </Grid>
    </Container>
  );
}
