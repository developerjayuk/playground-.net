import { Button, Container, Divider, Typography } from "@mui/material";
import { ErrorResponse } from "../../app/models/errorResponse";
import { Link } from "react-router-dom";

export default function ServerError() {
  let error: ErrorResponse = window.history.state.data;

  return (
    <Container>
      <Typography variant="h4" gutterBottom>
        {error?.title || "Server Error"}
      </Typography>
      <Divider sx={{ m: 2 }} />
      <Typography>{error?.detail || "Internal server error"}</Typography>
      <Divider sx={{ m: 2 }} />
      <Button component={Link} to={"/catalog"}>
        Go back to the store
      </Button>
    </Container>
  );
}
