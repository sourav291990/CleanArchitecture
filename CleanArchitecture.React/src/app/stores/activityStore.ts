import {
  makeAutoObservable,
  runInAction,
} from "mobx";
import { IActivity } from "../models/IActivity";
import activityAgent from "../apis/activityAgent";
import { v4 as uuid } from "uuid";
import moment from "moment";

export default class ActivityStore {
  activityRegistry = new Map<string, IActivity>();
  selectedActivity: IActivity | undefined | null = null;
  editMode = false;
  loading = false;
  loadingInitial = false;

  constructor() {
    makeAutoObservable(this);
  }

  get activitiesByDate(){
    return Array.from(this.activityRegistry.values()).sort((a,b)=>
      Date.parse(a.date)- Date.parse(b.date));
  }

  loadActivities = async () => {
    this.setLoadInitial(true);
    try {
      const activities = await activityAgent.Activities.list();
      activities.forEach(activity=>{
        activity.date = moment(activity.date).format('yyyy-MM-DD');
        console.log(activity.date);
        this.activityRegistry.set(activity.id, activity);
      });
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
    this.selectedActivity = this.activityRegistry.get(id);
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
        this.activityRegistry.set(activity.id, activity);
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
        this.activityRegistry.set(activity.id, activity);
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
        this.activityRegistry.delete(id);
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
