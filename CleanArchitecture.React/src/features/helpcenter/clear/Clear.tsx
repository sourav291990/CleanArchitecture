import styles from "./Clear.module.css";

export default function Clear(onClick: any) {
  return (
    <button className={styles.wrapper} onClick={onClick}>
      Clear
    </button>
  );
}
