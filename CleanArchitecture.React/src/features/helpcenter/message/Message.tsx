import bot from "../../../assets/bot.png";
import user from "../../../assets/user.png";

import styles from "./Message.module.css";

interface IProps {
  role?: string;
  content?: string;
}

export default function Message({ role, content }: IProps) {
  return (
    <div className={styles.wrapper}>
      <div>
        <img
          src={role === "assistant" ? bot : user}
          className={styles.avatar}
          alt="profile avatar"
        />
      </div>
      <div>
        <p>{content}</p>
      </div>
    </div>
  );
}
