import { Button, Container, Typography } from "@mui/material";
import { NavLink } from "react-router-dom";

export default function NotFound() {
  return (
    <Container>
      <Typography variant="h5">404 Not Found :-(</Typography>
      <p>Please double check the url or return to the homepage.</p>
      <Button component={NavLink} to={"/catalog"}>
        Return to the store
      </Button>
    </Container>
  );
}
