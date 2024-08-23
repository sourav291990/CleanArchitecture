import { useEffect, useState } from "react";
import "../../App.css";
import axios from "axios";
import { IActivity } from "../models/IActivity";
import Navbar from "./Navbar";

function App() {
  const [activities, setActivities] = useState<IActivity[]>([]);

  useEffect(() => {
    axios.get<IActivity[]>("https://localhost:7104/api/v1/activity").then((response) => {
      console.log(response.data);
      setActivities(response.data);
    });
  },[]);

  return (
    <>
    <Navbar/>
      <h1>Activities</h1>
      <ul>
        {activities.map((activity)=>(
          <li key={activity.id}>{activity.title}</li>
        ))}
      </ul>
    </>
  );
}

export default App;
