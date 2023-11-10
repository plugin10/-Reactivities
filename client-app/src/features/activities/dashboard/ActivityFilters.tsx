import React from "react";
import Calendar from "react-calendar";
import { Header, Menu } from "semantic-ui-react";

export default function Test() {
  return (
    <>
      <Menu vertical size="large" style={{ with: "100%" }}>
        <Header icon="filter" attached color="teal" content="Filters" />
        <Menu.Item content="All Activities" />
        <Menu.Item content="I'm going" />
        <Menu.Item content="I'm posting" />
      </Menu>

      <Header />
      <Calendar />
    </>
  );
}
