function numbersEndingIn7() {
  for (let i = 7; i < 1000; i++) {
    if (i % 10 == 7) {
      console.log(i);
    }
  }
}
// 01

function multiplicationTable(input) {
  let number = Number(input[0]);

  for (let i = 1; i <= 10; i++) {
    let multiplication = i * number;
    console.log(`${i} * ${number} = ${multiplication}`);
  }
}
multiplicationTable(['5']); // 02

function histogram(input) {
  let numbersCount = Number(input[0]);
  let p1 = 0;
  let p2 = 0;
  let p3 = 0;
  let p4 = 0;
  let p5 = 0;

  for (let index = 1; index <= numbersCount; index++) {
    let currentNumber = Number(input[index]);

    if (currentNumber < 200) {
      p1++;
    } else if (currentNumber <= 399) {
      p2++;
    } else if (currentNumber <= 599) {
      p3++;
    } else if (currentNumber <= 799) {
      p4++;
    } else if (currentNumber >= 800) {
      p5++;
    }
  }

  console.log(`${(p1 / numbersCount * 100).toFixed(2)}%`);
  console.log(`${(p2 / numbersCount * 100).toFixed(2)}%`);
  console.log(`${(p3 / numbersCount * 100).toFixed(2)}%`);
  console.log(`${(p4 / numbersCount * 100).toFixed(2)}%`);
  console.log(`${(p5 / numbersCount * 100).toFixed(2)}%`);
}
histogram(["3", "1", "2", "999"]); // 03

function cleverLily(input) {
  let lilisAge = Number(input[0]);
  let washingMachine = Number(input[1]);
  let toyPrice = Number(input[2]);

  let savedMoney = 0;
  let addMoney = 10;
  let toyCount = 0;
  let stolenMoney = 0;

  for (let currentAge = 1; currentAge <= lilisAge; currentAge++) {
    if (currentAge % 2 === 0) {
      savedMoney += addMoney;
      addMoney += 10;
      stolenMoney++
    } else {
      toyCount++;
    }
  }
  let totalToyPrice = toyPrice * toyCount;
  let totalMoneySaved = totalToyPrice + savedMoney - stolenMoney;

  if (totalMoneySaved >= washingMachine) {
    console.log(`Yes! ${(totalMoneySaved - washingMachine).toFixed(2)}`)
  } else {
    console.log(`No! ${(washingMachine - totalMoneySaved).toFixed(2)}`);
  }
}
cleverLily(["10", "170.00", "6"]); // 04

function salary(input) {
  let salary = Number(input[1]);

  for (let index = 2; index <= input.length; index++) {
    let currentSite = input[index];

    switch (currentSite) {
      case 'Facebook': salary -= 150; break;
      case 'Instagram': salary -= 100; break;
      case 'Reddit': salary -= 50; break;
    }
    if (salary <= 0) {
      console.log('You have lost your salary.')
      break;
    }
  }
  if (salary > 0) {
    console.log(salary);
  }
}
salary(["3", "500", "Github.com", "Stackoverflow.com", "softuni.bg"]); // 05

function trekkingMania(input) {

  let groups = Number(input[0])
  let p1 = 0
  let p2 = 0
  let p3 = 0
  let p4 = 0
  let p5 = 0

  let totalPeople = 0;

  for (i = 1; i <= groups; i++) {
    let team = Number(input[i])

    if (team <= 5) {
      p1 += team
    } else if ((team >= 6) && (team <= 12)) {
      p2 += team
    } else if ((team >= 13) && (team <= 25)) {
      p3 += team
    } else if ((team >= 26) && (team <= 40)) {
      p4 += team
    } else if (team >= 41) {
      p5 += team
    }

    totalPeople += team;
  }
  console.log(`${(p1 / totalPeople * 100).toFixed(2)}%`)
  console.log(`${(p2 / totalPeople * 100).toFixed(2)}%`)
  console.log(`${(p3 / totalPeople * 100).toFixed(2)}%`)
  console.log(`${(p4 / totalPeople * 100).toFixed(2)}%`)
  console.log(`${(p5 / totalPeople * 100).toFixed(2)}%`)
}
trekkingMania(["10", "10", "5", "1", "100", "12", "26", "17", "37", "40", "78"]); // 07