import React, { Fragment, useEffect } from "react";
import NavBar from "./NavBar";
import { Container } from "semantic-ui-react";
import ActivitiesDashboard from "../../features/activities/dashboard/ActivityDashboard";
import LoadingComponent from "./LoadintComponent";
import { useStore } from "../stores/store";
import { observer } from "mobx-react-lite";

function App() {
  const { activityStore } = useStore();

  useEffect(() => {
    activityStore.loadActivities();
  }, [activityStore]);

  if (activityStore.loadingInitial)
    return <LoadingComponent content="Loading app" />;

  return (
    <Fragment>
      <NavBar />
      <Container style={{ marginTop: "7em" }}>
        <ActivitiesDashboard />
      </Container>
    </Fragment>
  );
}

export default observer(App);
