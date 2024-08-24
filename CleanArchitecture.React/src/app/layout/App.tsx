import { useEffect, useState } from "react";
import "../../App.css";
import axios from "axios";
import { IActivity } from "../models/IActivity";
import Navbar from "./Navbar";
import { Container } from "semantic-ui-react";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";

function App() {
  const [activities, setActivities] = useState<IActivity[]>([]);

  useEffect(() => {
    axios
      .get<IActivity[]>("https://localhost:7104/api/v1/activity")
      .then((response) => {
        console.log(response.data);
        setActivities(response.data);
      });
  }, []);

  return (
    <>
      <Navbar />
      <Container style={{ marginTop: "7em" }}>
        <h1>Activities</h1>
        <ActivityDashboard activities={activities}/>
      </Container>
    </>
  );
}

export default App;
