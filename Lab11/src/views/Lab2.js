import { faWindowRestore } from "@fortawesome/free-solid-svg-icons";
import React, { useState } from "react";

const Lab2 = () => {
  const [input, setInput] = useState("");
  const [result, setResult] = useState("");

  const Calculate = () => {

        let lines = input.split("\n");

        let n, k, g, count;
        let tempstring = lines[0].split(' ');
        n=parseInt(tempstring[0]);
        k=parseInt(tempstring[1]);
        if (tempstring.length !== 2 || !parseInt(tempstring[0]) || !parseInt(tempstring[1])) {
            window.alert("Error: Incorrect format of the first line in the file input.txt");
            setResult(NaN);
        }
        let dp = [];
        for (let i = 0; i < parseInt(n) + 1; i++) {
            dp.push([0, 0]);
        }
        let w, nt, s, ch = 1, unid;
        tempstring = lines[1].split(' ');


        w=parseInt(tempstring[0]);
        nt=parseInt(tempstring[1]);
        s=parseInt(tempstring[2]);
        if (tempstring.length !== 3 || !parseInt(tempstring[0]) || !parseInt(tempstring[1]) || !parseInt(tempstring[2])) {
            window.alert("Error: Incorrect format of second line in file input.txt");
            setResult(NaN);
        }
        count = parseInt(s);
        for (let i = 0; i < parseInt(n); i++) {
            dp[i][1] = count;
            if (count === parseInt(w)) {
                count = 0;
            }
            count++;
        }
        for (let i = 0; i < parseInt(nt); i++) {
            unid = parseInt(lines[2 + i]);
            for (let z = 0; z < parseInt(n); z += parseInt(ch)) {
                if (dp[z][1] === unid) {
                    dp[z][0] = -1;
                    ch = parseInt(w);
                }
            }
        }
        ch = 1;
        g = parseInt(lines[3]);
        
        tempstring = lines[4].split(' ');
        
        if (tempstring.length !== parseInt(g)) {
            window.alert("Error: The number of numbers in the fifth line does not correspond to the specified number");
            setResult(NaN);
        }
        for (let i = 0; i < parseInt(g); i++) {
            unid = parseInt(tempstring[i]);
            dp[parseInt(unid - 1)][0] = -1;
        }

        let last = 0;
        for (let i = 0; i < parseInt(n); i++) {
            if (i + parseInt(k) > parseInt(n)) {
                break;
            }
            if (dp[i][0] === -1) {
                continue;
            }
            if (dp[i + parseInt(k) - 1][0] === -1) {
                i = i + parseInt(k) - 1;
                continue;
            }
            dp[i][0] = dp[i][0] + last + 1;
            last = parseInt(dp[i][0]);
        }
        let res = 0;
        for (let i = 0; i < parseInt(n); i++) {
            if (res < dp[i][0]) {
                res = parseInt(dp[i][0]);
            }
        }

    setResult(res);
  };


  return (
    <div style={{ marginLeft: "15px" }}>
      <h1>Лабораторна робота №2</h1>
      
      <h2>Умова задачі:</h2>
      <p>
      2127 рік. Минуло вже багато років відколи відбулася перша олімпіада з інформатики. Як і багато інших змагань, 
      наші олімпіади тепер проводяться за кілька днів. Тепер навіть завдання вибору відповідного часу для олімпіади становить певні труднощі. 
      Адже на різних планетах використовуються різні способи відліку часу: довжина місяця, кількість днів на тижні і ті дні, 
      за якими неможливе проведення олімпіади, можуть відрізнятися. Виникла необхідність написання програми, яка допоможе вирішити це завдання. 
      І тоді в журі згадають, що вже зараз ми передбачали таку ситуацію та запропонували вам вирішити подібне завдання. 
      Як перший крок знайдіть кількість способів вибрати час проведення олімпіади.<br></br>
      <h2>Вхідні дані:</h2>
        У першому рядку вхідного файлу INPUT.TXT містяться два цілих числа n і k (1 ≤ k ≤ n ≤ 100000) - 
        кількість днів місяця та тривалість олімпіади відповідно.<br></br>
        У другому рядку задаються кількість днів у тижні w, кількість днів, заборонених щотижня, dw та день тижня, 
        на який припадає перший день місяця s (1 ≤ s ≤ w ≤ n, 0 ≤ dw ≤ w).<br></br>
        Третій рядок містить dw номерів днів тижня (наприклад, вихідних), які не можна проводити олімпіаду.<br></br>
        У четвертому рядку записано кількість днів місяця dm, які не підходять для проведення олімпіади з причин, <br></br>
        відмінних від щотижневого розпорядку (наприклад, такими днями є державні свята).
        Останній рядок містить dm цілих чисел – номери цих днів. Дні місяця також нумеруються починаючи з 1. 
        Зауважимо, що деякі дні можуть бути забороненими відразу з обох причин.
      </p>
      <h2>Вихідні дані:</h2>
      <p>
      Виведіть єдине ціле число - кількість способів вибрати k поспіль днів, в які можливе проведення олімпіади.
      </p>
      <h2>Приклад</h2>
      <p>
        <b>INPUT:</b>
      </p>
      <p> 31 3 <br></br>
        7 1 7 <br></br>
        7 <br></br>
        2 <br></br>
        1 9</p>
      <p>
        <b>OUTPUT:</b>
      </p>{" "}
      <p>15</p>

      <label>
       Кількість крапок:
        <textarea value={input} rows={6} onChange={(e) => setInput(e.target.value)}>  </textarea>
      </label>
      <br />
      <br />
      <button onClick={Calculate}>Обчислити</button>
      <br />
      <div>Результат: {result}</div>
    </div>
  );
};

export default Lab2;