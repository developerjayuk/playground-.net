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
import LoginForm from "../users/LoginForm";

export default observer(function HomePage() {
  const { userStore, modalStore } = useStore();

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
          <>
            <Button
              onClick={() => modalStore.openModal(<LoginForm />)}
              size="huge"
              inverted
            >
              Login
              <Icon
                name="arrow alternate circle up"
                style={{ marginLeft: 5 }}
              />
            </Button>
            <Button
              onClick={() => modalStore.openModal(<h1>Register</h1>)}
              size="huge"
              inverted
            >
              Register
              <Icon
                name="arrow alternate circle up"
                style={{ marginLeft: 5 }}
              />
            </Button>
          </>
        )}
      </Container>
    </Segment>
  );
});
