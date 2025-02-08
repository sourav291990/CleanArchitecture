import axios from "axios";
import { IActivity } from "../models/IActivity";
import request from "./request";

axios.defaults.baseURL = "https://localhost:7104/api/v1";

const Activities = {
  list: () => request.get<IActivity[]>("/activity"),
  details: (id: string) => request.get<IActivity>(`/activity/${id}`),
  create: (activity: IActivity) => request.post<void>(`/activity`, activity),
  update: (activity: IActivity) =>
    request.put(`/activity/${activity.id}`, activity),
  delete: (id: string) => request.delete<void>(`/activity/${id}`),
};

const activityAgent = {
  Activities,
};

export default activityAgent;
