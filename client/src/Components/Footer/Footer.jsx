import { Container } from "@mui/system";
import React from "react";
import { Grid } from "@mui/material";
import { SocialIcon } from "react-social-icons";
import "./Footer.css";
export default function () {
  return (
    <Container maxWidth="lg" className="footer">
      <Grid
        container
        justifyContent="space-between"
        flexDirection={{ sm: "column", md: "row" }}
      >
        <div className="footerText">
          <b>Contacts:</b>
          <div>Address: Ivana Fedorova street, 10</div>
          <div>Phone number: 050-458-34-41</div>
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
