import { useState } from "react";
import Message from "./message/Message";
import Input from "./input/Input";
import Clear from "./clear/Clear";
import History from "./history/History";
import "./Helpcenter.css";
import helpCenterAgent from "../../app/apis/helpcenterAgent";

export default function HelpCenter() {
  const [input, setInput] = useState("");
  const [messages, setMessages] = useState<any>([]);
  const [history, setHistory] = useState<any>([]);

  const handleSubmit = async () => {
    const prompt = {
      role: "user",
      content: input,
    };

    setMessages([...messages, prompt]);
    const data = AskModel(input);
    console.log(data);
  };

  const clear = () => {
    setMessages([]);
    setHistory([]);
  };

  return (
    <div className="HelpCenter">
      <div className="Column">
        <h3 className="Title">Chat Messages</h3>
        <div className="Content">
          {messages.map((el: any, i: any) => {
            return <Message key={i} role={el.role} content={el.content} />;
          })}
        </div>
        <Input
          value={input}
          onChange={(e: any) => setInput(e.target.value)}
          onClick={input ? handleSubmit : undefined}
        />
      </div>
      <div className="Column">
        <h3 className="Title">History</h3>
        <div className="Content">
          {history.map((el: any, i: any) => {
            return (
              <History
                key={i}
                question={el.question}
                onClick={() =>
                  setMessages([
                    { role: "user", content: history[i].question },
                    { role: "assistant", content: history[i].answer },
                  ])
                }
              />
            );
          })}
        </div>
        <Clear onClick={clear} />
      </div>
    </div>
  );

  function AskModel(input: string) {
    debugger;
    const body = JSON.stringify({
      model: "gpt-3.5-turbo",
      messages: [...messages, input],
    });
    helpCenterAgent.HelpCenter.ask(body).then((data) => {
      setMessages((messages: string) => [
        ...messages,
        {
          role: "assistant",
          content: data,
        },
      ]);
      setHistory((history: string) => [
        ...history,
        { question: input, answer: data },
      ]);
      setInput("");
    });
  }
}
