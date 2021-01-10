import React from 'react';
import { Segment, Button, Header, Icon } from 'semantic-ui-react';
import { Link } from 'react-router-dom';

const NotFound = () => {
  return (
    <Segment placeholder>
      <Header icon>
        <Icon name="search" />
        Sorry - but we couldn't find this!
      </Header>
      <Segment.Inline>
        <Button as={Link} to="/activities" primary>
          Return to Activities
        </Button>
      </Segment.Inline>
    </Segment>
  );
};

export default NotFound;
