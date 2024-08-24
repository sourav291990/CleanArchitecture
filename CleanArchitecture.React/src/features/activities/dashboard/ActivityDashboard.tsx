import { Grid } from "semantic-ui-react";
import ActivityList from "../ActivityList";
import { IActivity } from "../../../app/models/IActivity";

interface Props {
    activities: IActivity[];
  }

export default function ActivityDashboard({ activities }: Props) {
  return (
    <Grid>
      <Grid.Column width="10">
        <ActivityList activities={activities} />
      </Grid.Column>
    </Grid>
  );
}
