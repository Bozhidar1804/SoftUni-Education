function oldBooks(input) {
  let theBook = input[0];
  let index = 1;
  let searching = input[index];
  let bookIsFound = false;

  while (searching !== 'No More Books') {
    if (searching == theBook) {
      bookIsFound = true;
      break;
    }
    index++;
    searching = input[index];
  }

  if (bookIsFound === false) {
    console.log(`The book you search is not here!`);
    console.log(`You checked ${index - 1} books.`);
  } else {
    console.log(`You checked ${index - 1} books and found it.`)
  }
}
oldBooks(["The Spot", "Hunger Games", "Harry Potter", "Torronto", "Spotify", "No More Books"]); // 01

function examPreparation(input) {
  let acceptablePoorGrades = Number(input[0]);
  let index = 1;
  let currentInput = input[index];
  let poorGrades = 0;
  let sum = 0;
  let dividingSum = 0;
  let numberOfProblems = 0;
  let currentProblem = '';

  while (currentInput !== 'Enough') {
    currentProblem = currentInput;
    index++;
    currentInput = Number(input[index]);
    sum += currentInput;
    dividingSum++;
    if (currentInput <= 4) {
      poorGrades++;
      if (poorGrades >= acceptablePoorGrades) {
        console.log(`You need a break, ${poorGrades} poor grades.`);
        break;
      }
    }

    numberOfProblems++;

    index++;
    currentInput = input[index];
  }
  let average = sum / dividingSum;

  if (currentInput === 'Enough') {
    console.log(`Average score: ${average.toFixed(2)}`);
    console.log(`Number of problems: ${numberOfProblems}`);
    console.log(`Last problem: ${currentProblem}`)
  }
}
examPreparation(['4', 'Stone Age', "5", 'Freedom', "5", 'Storage', "3", 'Enough']); // 02

function vacation(input) {
  let needMoney = Number(input[0]);
  let currentMoney = Number(input[1]);
  let spendDays = 0;
  let days = 0;
  let index = 2;
  let currentInput = input[index];

  while (currentMoney < needMoney) {
    days++;
    index++;

    if (currentInput === 'spend') {
      spendDays++;

      if (spendDays === 5) {
        console.log(`You can't save the money.`)
        console.log(days)
        break;
      }
      let moneyToSpend = Number(input[index]);
      currentMoney = currentMoney - moneyToSpend;

      if (currentMoney < 0) {
        currentMoney = 0;
      }

    } else if (currentInput === 'save') {
      spendDays = 0;
      let MoneyToSave = Number(input[index]);
      currentMoney = currentMoney + MoneyToSave
    }
    index++;
    currentInput = input[index];
  }

  if (currentMoney >= needMoney) {
    console.log(`You saved the money for ${days} days.`)
  }
}
vacation(["2000", "1000", "spend", "1200", "save", "2000"]); // 03

function walking(input) {
  let stepsGoal = 10000;
  let stepsSum = 0;
  let index = 0;
  let command = input[index];

  while (command !== 'Going home') {
    let steps = Number(command);
    stepsSum += steps;

    if (stepsSum >= stepsGoal) {
      console.log(`Goal reached! Good job!`);
      console.log(`${stepsSum - stepsGoal} steps over the goal!`);
      break;
    }

    index++;
    command = input[index];
  }

  if (command === 'Going home') {
    let stepsToHome = Number(input[index + 1]);
    stepsSum += stepsToHome;

    if (stepsSum >= stepsGoal) {
      console.log(`Goal reached! Good job!`);
      console.log(`${stepsSum - stepsGoal} steps over the goal!`);
    }
    if (stepsSum <= stepsGoal) {
      console.log(`${stepsGoal - stepsSum} more steps to reach goal.`)
    }
  }

}
walking(['1500', '3000', '250', '1548', '2000', 'Going home', '2000']); // 04

function coins(input) {
  let change = Number(input[0]);
  let inCoins = Math.floor(change * 100);
  let coinsCounter = 0;

  while (inCoins > 0) {
    if (inCoins >= 200) {
      inCoins = inCoins - 200;
      coinsCounter++;
    } else if (inCoins >= 100) {
      inCoins = inCoins - 100;
      coinsCounter++;
    } else if (inCoins >= 50) {
      inCoins = inCoins - 50;
      coinsCounter++;
    } else if (inCoins >= 20) {
      inCoins = inCoins - 20;
      coinsCounter++;
    } else if (inCoins >= 10) {
      inCoins = inCoins - 10;
      coinsCounter++;
    } else if (inCoins >= 5) {
      inCoins = inCoins - 5;
      coinsCounter++;
    } else if (inCoins >= 2) {
      inCoins = inCoins - 2;
      coinsCounter++;
    } else if (inCoins >= 1) {
      inCoins = inCoins - 1;
      coinsCounter++;
    }
  }
  console.log(coinsCounter);
}
coins(["1.23"]); // 05

function cake(input) {
  let length = Number(input[0]);
  let width = Number(input[1]);
  let cakeSize = length * width;
  let index = 2;
  let command = input[index];
  let pieces = 0;

  while (command !== 'STOP') {
    let numPieces = Number(command);
    pieces += numPieces;

    if (pieces > cakeSize) {
      console.log(`No more cake left! You need ${pieces - cakeSize} pieces more.`);
      break;
    }

    index++;
    command = input[index];
  }
  if (command === 'STOP' && cakeSize > pieces) {
    console.log(`${cakeSize - pieces} pieces are left.`)
  }
}
cake(["10", "2", "2", "4", "6", "STOP"]); // 06