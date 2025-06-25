function clock() {
  for (let h = 0; h <= 23; h++) {
    for (let m = 0; m <= 59; m++) {
      console.log(`${h}:${m}`);
    }
  }
}
clock(); // 01

function multiplicationTable() {
  for (let firstN = 1; firstN <= 10; firstN++) {
    for (let secondN = 1; secondN <= 10; secondN++) {
      console.log(`${firstN} * ${secondN} = ${firstN * secondN}`)
    }
  }
}
multiplicationTable(); // 02

function sumOfTwoNumbers(input) {
  let start = Number(input[0]);
  let final = Number(input[1]);
  let magicNumber = Number(input[2]);
  let combinations = 0;
  let flag = false;

  for (let i = start; i <= final; i++) {
    for (let j = start; j <= final; j++) {
      let sum = i + j;
      combinations++;
      if (sum === magicNumber) {
        flag = true;
        console.log(`Combination N:${combinations} (${i} + ${j} = ${magicNumber})`)
        break;
      }
    }
    if (flag === true) {
      break;
    }
  }

  if (flag === false) {
    console.log(`${combinations} combinations - neither equals ${magicNumber}`)
  }
}
sumOfTwoNumbers(["1", "10", "5"]); // 04

function building(input) {
  let floors = Number(input[0]);
  let rooms = Number(input[1]);

  for (let floorNum = floors; floorNum >= 1; floorNum--) {
    let roomType = '';
    if (floorNum === floors) {
      roomType = 'L';
    } else if (floorNum % 2 == 0) {
      roomType = 'O';
    } else {
      roomType = 'A';
    }
    let floor = '';
    for (let roomNum = 0; roomNum < rooms; roomNum++) {
      floor = floor + `${roomType}${floorNum}${roomNum} `;
    }

    console.log(floor);
  }
}
building(['6', '4']); // 06






function clock() {
  for (let h = 0; h <= 23; h++) {
    for (let m = 0; m <= 59; m++) {
      let hours = '';
      let minutes = '';

      if (h < 10) {
        hours = `0${h}`;
      } else {
        hours = `${h}`;
      }

      if (m < 10) {
        minutes = `0${m}`;
      } else {
        minutes = `${m}`;
      }

      console.log(`${hours}:${minutes}`)
    }
  }
}
clock(); // random (adding 0 to < 9)