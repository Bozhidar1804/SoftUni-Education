function pcStore(input) {
  let processorPrice = Number(input[0]);
  processorPriceInLv = processorPrice * 1.57;
  let videoCardPrice = Number(input[1]);
  videoCardPriceInLv = videoCardPrice * 1.57;
  let RAMPrice = Number(input[2]);
  RAMPriceInLv = RAMPrice * 1.57;
  let RAMCount = Number(input[3]);
  let discount = Number(input[4]);

  totalRam = RAMPriceInLv * RAMCount;
  let processorPriceAfterDiscount = processorPriceInLv - (processorPriceInLv * discount);
  let videoCardPriceAfterDiscount = videoCardPriceInLv - (videoCardPriceInLv * discount);

  let total = processorPriceAfterDiscount + videoCardPriceAfterDiscount + totalRam;

  console.log(`Money needed - ${total.toFixed(2)} leva.`)
}
pcStore(['1200', '850', '120', '4', '0.1']) // 01

function footballKit(input) {
  let shirt = Number(input[0]);
  let priceForBall = Number(input[1]);

  let shorts = shirt * 0.75;
  let socks = shorts * 0.20;
  let buttons = (shirt + shorts) * 2;

  let total = shirt + shorts + socks + buttons;

  let totalAfterDiscount = total - (total * 0.15)
  if (totalAfterDiscount >= 100) {
    console.log(`Yes, he will earn the world-cup replica ball!`);
    console.log(`His sum is ${totalAfterDiscount.toFixed(2)} lv.`);
  } else {
    console.log(`No, he will not earn the world-cup replica ball.`);
    console.log(`He needs ${priceForBall - totalAfterDiscount} lv. more.`);
  }
}
footballKit(['25', '100']); // 02

function courierExpress(input) {
  let weight = Number(input[0]);
  let type = input[1];
  let distance = Number(input[2]);

  let cost = 0;
  let markupForKg = 0;
  let markupForKm = 0;
  let priceAfterMarkUp = 0;
  let totalCost = 0;

  if (type === 'standard') {
    if (weight < 1) {
      totalCost = distance * 0.03;
    } else if (weight < 10) {
      totalCost = distance * 0.05;
    } else if (weight < 40) {
      totalCost = distance * 0.10;
    } else if (weight < 90) {
      totalCost = distance * 0.15;
    } else if (weight <= 150) {
      totalCost = distance * 0.20;
    }
  } else if (type === 'express') {
    if (weight < 1) {
      cost = distance * 0.03;
      let markupForKg = 0.8 * 0.03;
      let markupForKm = weight * markupForKg;
      priceAfterMarkUp = distance * markupForKm;
      totalCost = cost + priceAfterMarkUp;
    } else if (weight < 10) {
      cost = distance * 0.05;
      let markupForKg = 0.4 * 0.05;
      let markupForKm = weight * markupForKg;
      priceAfterMarkUp = distance * markupForKm;
      totalCost = cost + priceAfterMarkUp;
    } else if (weight < 40) {
      cost = distance * 0.10;
      let markupForKg = 0.05 * 0.10;
      let markupForKm = weight * markupForKg;
      priceAfterMarkUp = distance * markupForKm;
      totalCost = cost + priceAfterMarkUp;
    } else if (weight < 90) {
      cost = distance * 0.15;
      let markupForKg = 0.02 * 0.15;
      let markupForKm = weight * markupForKg;
      priceAfterMarkUp = distance * markupForKm;
      totalCost = cost + priceAfterMarkUp;
    } else if (weight <= 150) {
      cost = distance * 0.20;
      let markupForKg = 0.01 * 0.20;
      let markupForKm = weight * markupForKg;
      priceAfterMarkUp = distance * markupForKm;
      totalCost = cost + priceAfterMarkUp;
    }
  }

  console.log(`The delivery of your shipment with weight of ${weight.toFixed(3)} kg. would cost ${totalCost.toFixed(2)} lv.`);
}
courierExpress(["20", "standard", "349"]); // 03

function computerFirm(input) {
  let n = Number(input[0]);
  let index = 1;
  let command = input[index];

  let possibleSellings = 0;

  let sellings = 0;
  let totalRating = 0;


  for (let i = 1; i <= n; i++) {
    let currentNumber = command;

    let currentRating = Number(currentNumber[2]);

    let convertPossibleSellings = Number(command.slice(0, 2));

    if (currentRating === 2) {
      possibleSellings = convertPossibleSellings * 0;
    } else if (currentRating === 3) {
      possibleSellings = convertPossibleSellings * 0.50;
    } else if (currentRating === 4) {
      possibleSellings = convertPossibleSellings * 0.70;
    } else if (currentRating === 5) {
      possibleSellings = convertPossibleSellings * 0.85;
    } else if (currentRating === 6) {
      possibleSellings = convertPossibleSellings;
    }

    sellings += possibleSellings;

    totalRating += currentRating;

    index++;
    command = input[index];
  }

  finalRating = totalRating / n;

  console.log(sellings.toFixed(2));
  console.log(finalRating.toFixed(2));
}
computerFirm(["5", "122", "156", "202", "214", "185"]); // 04

function bestPlayer(input) {
  let index = 0;
  let command = input[index];
  let goals = 0;
  let bestPlayerName;

  while (command !== 'END') {
    index++
    let currentGoals = Number(input[index]);

    if (currentGoals > goals) {
      bestPlayerName = command;
      goals = currentGoals;
    }

    if (currentGoals >= 10) {
      break;
    }

    index++;
    command = input[index];
  }

  if (goals >= 3) {
    console.log(`${bestPlayerName} is the best player!`);
    console.log(`He has scored ${goals} goals and made a hat-trick !!!`)
  } else {
    console.log(`${bestPlayerName} is the best player!`);
    console.log(`He has scored ${goals} goals.`)
  }
}
bestPlayer(["Silva", "5", "Harry Kane", "10"]); // 05


function multiplyTable(input) {
  let theString = input[0];
  let n = Number(input[0]);

  let firstNumber = theString[2];
  let secondNumber = theString[1];
  let thirdNumber = theString[0];

  for (let i = 1; i <= firstNumber; i++) {
    for (let j = 1; j <= secondNumber; j++) {
      for (let k = 1; k <= thirdNumber; k++) {
        console.log(`${i} * ${j} * ${k} = ${i * j * k};`);
      }
    }
  }
}
multiplyTable(['324']); // 06