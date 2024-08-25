import { useEffect, useState } from "react";
import "../../App.css";
import { IActivity } from "../models/IActivity";
import Navbar from "./Navbar";
import { Container } from "semantic-ui-react";
import ActivityDashboard from "../../features/activities/dashboard/ActivityDashboard";
import { v4 as uuid } from "uuid";
import LoadingComponent from "./LoadingComponent";
import activityAgent from "../apis/activityAgent";

function App() {
  const [activities, setActivities] = useState<IActivity[]>([]);
  const [selectedActivity, setSelectedActivity] = useState<
    IActivity | undefined
  >(undefined);
  const [editMode, setEditMode] = useState(false);
  const [loading, setLoading] = useState(true);
  const [submitting, setSubmitting] = useState(false);

  useEffect(() => {
    activityAgent.Activities.list().then((response) => {
      console.log(response);
      setActivities(response);
      setLoading(false);
    });
  }, []);

  function handleSelectActivity(activityId: string) {
    setSelectedActivity(activities.find((x) => x.id === activityId));
  }

  function handleCancelActivity() {
    setSelectedActivity(undefined);
  }

  function handleFormOpen(id?: string) {
    id ? handleSelectActivity(id) : handleCancelActivity();
    setEditMode(true);
  }

  function handleFormClose() {
    setEditMode(false);
  }

  function handleCreateOrEditActivity(activity: IActivity) {
    setSubmitting(true);
    if (activity.id) {
      activityAgent.Activities.update(activity)
        .then(() => {
          setActivities([
            ...activities.filter((x) => x.id !== activity.id),
            activity,
          ]);
          setSelectedActivity(activity);
          setEditMode(false);
          setSubmitting(false);
        })
        .catch((error) => {
          debugger;
          console.log(error);
        });
    } else {
      activity.id = uuid();
      activityAgent.Activities.create(activity)
        .then(() => {
          setActivities([...activities, { ...activity, id: uuid() }]);
          setSelectedActivity(activity);
          setEditMode(false);
          setSubmitting(false);
        })
        .catch((error) => {
          console.log(error);
        });
    }
  }

  function handleDeleteActivity(id: string) {
    setSubmitting(true);
    activityAgent.Activities.delete(id)
      .then(() => {
        setActivities([...activities.filter((x) => x.id !== id)]);
        setSubmitting(false);
      })
      .catch((error) => {
        console.log(error);
      });
  }
  if (loading)
    return <LoadingComponent content="Loading app"></LoadingComponent>;

  return (
    <>
      <Navbar openForm={handleFormOpen} />
      <Container style={{ marginTop: "7em" }}>
        <h1>Activities</h1>
        <ActivityDashboard
          activities={activities}
          selectedActivity={selectedActivity}
          selectActivity={handleSelectActivity}
          cancelActivity={handleCancelActivity}
          editMode={editMode}
          openForm={handleFormOpen}
          closeForm={handleFormClose}
          createOrEdit={handleCreateOrEditActivity}
          deleteActivity={handleDeleteActivity}
          submitting={submitting}
        />
      </Container>
    </>
  );
}

export default App;
