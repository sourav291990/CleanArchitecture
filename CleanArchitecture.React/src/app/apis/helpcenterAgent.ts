import axios from "axios";
import request from "./request";

axios.defaults.baseURL = "https://api.openai.com/v1/chat/completions";

const HelpCenter = {
  ask: (question: string) => request.post<string>("", question),
};

const helpCenterAgent = {
  HelpCenter,
};
export default helpCenterAgent;
