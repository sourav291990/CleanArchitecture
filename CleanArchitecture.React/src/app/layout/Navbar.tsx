import { Button, Container, Menu } from "semantic-ui-react";

interface IProps {
  openForm: () => void;
}

export default function Navbar({ openForm }: IProps) {
  return (
    <Menu inverted fixed="top">
      <Container>
        <Menu.Item header>
          <img src="src/assets/logo.png" alt="logo"></img>
        </Menu.Item>
        <Menu.Item name="Activities"></Menu.Item>
        <Menu.Item>
          <Button
            onClick={openForm}
            positive
            content="Create Activity"
          ></Button>
        </Menu.Item>
      </Container>
    </Menu>
  );
}
