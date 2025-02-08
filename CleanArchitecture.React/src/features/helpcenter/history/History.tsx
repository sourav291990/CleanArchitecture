import styles from "./History.module.css";

interface IProps {
  question?: string;
  onClick?: any;
}

export default function History({ question, onClick }: IProps) {
  return (
    <div className={styles.wrapper} onClick={onClick}>
      <p>{question?.substring(0, 15)}...</p>
    </div>
  );
}
