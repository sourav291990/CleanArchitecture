import {
  makeAutoObservable,
  makeObservable,
  observable,
  runInAction,
} from "mobx";
import { IActivity } from "../models/IActivity";
import activityAgent from "../apis/activityAgent";
import { v4 as uuid } from "uuid";

export default class ActivityStore {
  activities: IActivity[] = [];
  selectedActivity: IActivity | undefined | null = null;
  editMode = false;
  loading = false;
  loadingInitial = false;

  constructor() {
    makeAutoObservable(this);
  }

  loadActivities = async () => {
    this.setLoadInitial(true);
    try {
      const activities = await activityAgent.Activities.list();
      debugger;
      this.activities = activities;
      this.setLoadInitial(false);
    } catch (error) {
      console.log(error);
      this.setLoadInitial(false);
    }
  };

  setLoadInitial = (state: boolean) => {
    this.loadingInitial = state;
  };

  selectActivity = (id: string) => {
    this.selectedActivity = this.activities.find((a) => a.id === id);
  };

  cancelSelectedActivity = () => {
    this.selectedActivity = undefined;
  };

  openForm = (id?: string) => {
    id ? this.selectActivity(id) : this.cancelSelectedActivity();
    this.editMode = true;
  };

  closeForm = () => {
    this.editMode = false;
  };

  createActivity = async (activity: IActivity) => {
    this.loading = true;
    activity.id = uuid();
    try {
      await activityAgent.Activities.create(activity);
      runInAction(() => {
        this.activities.push(activity);
        this.selectedActivity = activity;
        this.editMode = false;
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loading = false;
      });
    }
  };

  updateActivity = async (activity: IActivity) => {
    this.loading = true;
    try {
      await activityAgent.Activities.update(activity);
      runInAction(() => {
        this.activities = [
          ...this.activities.filter((a) => a.id !== activity.id),
          activity,
        ];
        this.selectedActivity = activity;
        this.editMode = false;
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(() => {
        this.loading = false;
      });
    }
  };

  deleteActivity = async (id: string) => {
    this.loading = true;
    try {
      await activityAgent.Activities.delete(id);
      runInAction(() => {
        this.activities = [...this.activities.filter((a) => a.id !== id)];
        if(this.selectedActivity?.id === id) 
            this.cancelSelectedActivity();
        this.loading = false;
      });
    } catch (error) {
      console.log(error);
      runInAction(()=>{
        this.loading = false;
      })
    }
  };
}
