import React, { useState } from "react";

const Lab3 = () => {
  const [inputString, setInput] = useState("");
  const [result, setResult] = useState("");

  const Calculate = () => {

    let inputline = inputString.split("\n");
    let input = inputline[0].split(' ');
    if (input.length !== 2 || !Number.isInteger(parseInt(input[0])) || !Number.isInteger(parseInt(input[1]))) {
        console.log("Invalid input data.");
        return -1;
    }
    let N = parseInt(input[0]);
    let M = parseInt(input[1]);
    let Lines = new Array(N);
    for (let i = 0; i < N; i++) {
        let row = inputline[1 + i].split(' ');
        if (row.length !== M) {
            console.log(`Incorrect number of columns in row ${i + 1}`);
            return -2;
        }
        Lines[i] = new Array(M);
        for (let j = 0; j < M; j++) {
            let cellValue = row[j];
            Lines[i][j] = cellValue;
        }
    }
    let count = 0;
    for (let i = 0; i < N; i++) {
        for (let j = 0; j < M; j++) {
            if (Lines[i][j] === '0') {
                count++;
                Recursive(i, j, Lines, N, M);
            }
        }
    }
    setResult(count);
    
    function Recursive(i, j, Lines, N, M) {
        Lines[i][j] = '1';
        if ((j < M - 1) && (Lines[i][j + 1] === '0')) Recursive(i, j + 1, Lines, N, M);
        if ((j > 0) && (Lines[i][j - 1] === '0')) Recursive(i, j - 1, Lines, N, M);
        if ((i < N - 1) && (Lines[i + 1][j] === '0')) Recursive(i + 1, j, Lines, N, M);
        if ((i > 0) && (Lines[i - 1][j] === '0')) Recursive(i - 1, j, Lines, N, M);
    }
    
    
    

  };


  return (
    <div style={{ marginLeft: "15px" }}>
      <h1>Лабораторна робота №3</h1>
      
      <h2>Умова задачі:</h2>
      <p>
      Вася Пупкін взяв листочок у клітку і почав його різати по певних лініях. На запасному листку такого ж розміру 
      він зафарбував клітки, якими проходили лінії. Василь Васильович так захопився цим заняттям, що заплутався скільки 
      частин від аркуша в нього залишилося. Ваше завдання знайти це число.
      </p>
      <h2>Вхідні дані:</h2>
      <p>
      У першому рядку записані N та M (0 &lt; N,  M ≤ 100) – розмірність матриці.
        Далі записана матриця з N рядків, кожен з яких містить M нулів та одиниць. 0 позначає незабарвлену клітину і 1 - зафарбовану (лінію розрізу).
      </p>
      <h2>Вихідні дані:</h2>
      <p>
      Виведіть єдине ціле число - кількість способів вибрати k поспіль днів, в які можливе проведення олімпіади.
      </p>
      <h2>Приклад</h2>
      <p>
        <b>INPUT:</b>
      </p>
      <p> 4 4<br></br>
        0 0 1 0<br></br>
        0 0 1 0<br></br>
        0 1 0 0<br></br>
        1 0 0 1<br></br>
        </p>
      <p>
        <b>OUTPUT:</b>
      </p>{" "}
      <p>2</p>


      <label>
       Кількість крапок:
        <textarea value={inputString} rows={6} onChange={(e) => setInput(e.target.value)}>  </textarea>
      </label>
      <br />
      <br />
      <button onClick={Calculate}>Обчислити</button>
      <br />
      <div>Результат: {result}</div>
    </div>

    
  );
};

export default Lab3;