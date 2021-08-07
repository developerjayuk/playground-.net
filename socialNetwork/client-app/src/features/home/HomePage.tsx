import { observer } from "mobx-react-lite";
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
import { useStore } from "../../app/stores/store";

export default observer(function HomePage() {
  const { userStore } = useStore();

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
        <Header as="h2" inverted content="Welcome to your Social Network" />

        {userStore.isLoggedIn ? (
          <Button as={Link} to="/activities" size="huge" inverted>
            View activities
            <Icon name="arrow circle right" />
          </Button>
        ) : (
          <Button as={Link} to="/login" size="huge" inverted>
            Login
            <Icon name="arrow circle right" />
          </Button>
        )}
      </Container>
    </Segment>
  );
});
