import axios from "axios";
import request from "./request";

axios.defaults.baseURL = "https://localhost:7104/api/v1";

const HelpCenter = {
  ask: (question: string) => request.post<string>("/ask", question),
};

const helpCenterAgent = {
  HelpCenter,
};
export default helpCenterAgent;
