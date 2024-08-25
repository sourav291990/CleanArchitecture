import axios, { AxiosResponse } from "axios";
import { IActivity } from "../models/IActivity";

axios.defaults.baseURL = "https://localhost:7104/api/v1";

const responseBody = <T>(response: AxiosResponse<T>) => response.data;

const request = {
  get: <T>(url: string) => 
    axios.get<T>(url).then(responseBody),
  post: <T>(url: string, body: {}) =>
    axios.post<T>(url, body).then(responseBody),
  put: <T>(url: string, body: {}) => 
    axios.put<T>(url, body).then(responseBody),
  delete: <T>(url: string) => 
    axios.delete<T>(url).then(responseBody),
};

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
