import styles from "./Input.module.css";

interface IProps {
  value: string;
  onChange: any;
  onClick: any;
}

export default function Input({ value, onChange, onClick }: IProps) {
  return (
    <div className={styles.wrapper}>
      <input
        className={styles.text}
        placeholder="Your prompt here..."
        value={value}
        onChange={onChange}
      />
      <button className={styles.btn} onClick={onClick}>
        Go
      </button>
    </div>
  );
}
