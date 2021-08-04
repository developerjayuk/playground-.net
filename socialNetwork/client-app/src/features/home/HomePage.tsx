import React from "react";
import { Link } from "react-router-dom";
import {
  Container,
  Segment,
  Image,
  Header,
  Button,
  Icon,
} from "semantic-ui-react";

export default function HomePage() {
  return (
    <Segment inverted textAlign="center" vertical className="masthead">
      <Container text>
        <Header as="h1" inverted>
          <Image
            size="massive"
            src="/assets/logo.png"
            alt="logo"
            style={{ marginBottom: 12 }}
          />
        </Header>
        <Header as="h2" inverted content="Welcome to Reactivities" />
        <Button as={Link} to="/login" size="huge" inverted>
          Login
          <Icon name="arrow circle right" />
        </Button>
      </Container>
    </Segment>
  );
}
