function sumSeconds(input) {
  let firstTime = Number(input[0]);
  let secondTime = Number(input[1]);
  let thirdTime = Number(input[2]);

  let totalTimeInSec = firstTime + secondTime + thirdTime;

  let timeInMin = Math.floor(totalTimeInSec / 60);
  let timeInSec = totalTimeInSec % 60;

  if (timeInSec < 10) {
    console.log(`${timeInMin}:0${timeInSec}`);
  } else {
    console.log(`${timeInMin}:${timeInSec}`);
  }
}
sumSeconds(["35", "45", "44"]); // 01

function bonusScore(input) {
  let num = Number(input[0]);
  let bonus = 0;

  if (num <= 100) {
    bonus = 5;
  } else if (num > 1000) {
    bonus = num * 0.10;
  } else {
    bonus = num * 0.20;
  }

  if (num % 2 === 0) {
    bonus = bonus + 1;
  } else if (num % 10 === 5) {
    bonus = bonus + 2;
  }

  console.log(bonus);
  console.log(num + bonus);
}
bonusScore(['20']); // 02

function timeAdd15Minutes(input) {
  let h = Number(input[0]);
  let m = Number(input[1]);

  let time = h * 60 + m + 15;

  let totalH = Math.floor(time / 60);
  let totalM = time % 60;

  if (totalH > 23) {
    totalH = 0;
  }

  if (totalM < 10) {
    console.log(`${totalH}:0${totalM}`);
  } else {
    console.log(`${totalH}:${totalM}`)
  }
}
timeAdd15Minutes(['23', '59']); // 03

function toyShop(input) {
  let excursion = Number(input[0]);
  let puzzle = Number(input[1]);
  let doll = Number(input[2]);
  let bear = Number(input[3]);
  let minion = Number(input[4]);
  let truck = Number(input[5]);

  let purchase = puzzle + doll + bear + minion + truck;
  let purchasePrice = puzzle * 2.60 + doll * 3 + bear * 4.10 + minion * 8.20 + truck * 2.00;

  if (purchase >= 50) {
    purchasePrice = purchasePrice * 0.75
  }

  purchasePrice = purchasePrice * 0.90;
  let diff = Math.abs(purchasePrice - excursion);


  if (purchasePrice >= excursion) {
    console.log(`Yes! ${diff.toFixed(2)} lv left.`)
  } else {
    console.log(`Not enough money! ${diff.toFixed(2)} lv needed.`)
  }
}
toyShop(["40.8", "20", "25", "30", "50", "10"]); // 04

function godzillaVsKingKong(input) {
  let movieBudget = Number(input[0]);
  let extras = Number(input[1]);
  let clothingPer1 = Number(input[2]);

  let decor = movieBudget * 0.10;
  let clothingSum = clothingPer1 * extras;

  if (extras > 150) {
    clothingSum = clothingSum - (clothingSum * 0.10);
  }

  let totalPrice = decor + clothingSum;
  let diff = Math.abs(movieBudget - totalPrice);

  if (totalPrice > movieBudget) {
    console.log(`Not enough money!`);
    console.log(`Wingard needs ${diff.toFixed(2)} leva more.`);
  } else {
    console.log(`Action!`);
    console.log(`Wingard starts filming with ${diff.toFixed(2)} leva left.`)
  }
}
godzillaVsKingKong(["15437.62", "186", "57.99"]); // 05

function worldSwimmingRecord(input) {
  let worldRecord = Number(input[0]);
  let distance = Number(input[1]);
  let timeForM = Number(input[2]);

  let totalTime = distance * timeForM
  let slowTime = Math.floor(distance / 15);
  totalTime = totalTime + (slowTime * 12.5);

  if (totalTime < worldRecord) {
    console.log(`Yes, he succeeded! The new world record is ${totalTime.toFixed(2)} seconds.`);
  } else {
    let diff = Math.abs(totalTime - worldRecord);
    console.log(`No, he failed! He was ${diff.toFixed(2)} seconds slower.`);
  }


}
worldSwimmingRecord(["10464", "1500", "20"]); // 06

function shopping(input) {
  let budget = Number(input[0]);
  let videocards = Number(input[1]);
  let processors = Number(input[2]);
  let ram = Number(input[3]);

  let videocardsPrice = videocards * 250;
  let processorsPrice = videocardsPrice * 0.35;
  let processorsCost = processorsPrice * processors;
  let ramPrice = videocardsPrice * 0.10;
  let ramCost = ramPrice * ram;

  let totalPrice = videocardsPrice + processorsCost + ramCost;

  if (videocards > processors) {
    totalPrice = totalPrice - (totalPrice * 0.15);
  }
  let diff = Math.abs(totalPrice - budget);
  if (budget >= totalPrice) {
    console.log(`You have ${diff.toFixed(2)} leva left!`)
  } else {
    console.log(`Not enough money! You need ${diff.toFixed(2)} leva more!`)
  }
}
shopping(["900", "2", "1", "3"]); // 07

function lunchBreak(input) {
  let name = input[0];
  let durationEP = Number(input[1]);
  let durationBreak = Number(input[2]);

  let lunch = durationBreak / 8;
  let relax = durationBreak / 4;

  let totalFreeTime = durationBreak - lunch - relax;
  let diff = Math.abs(totalFreeTime - durationEP);

  if (totalFreeTime >= durationEP) {
    console.log(`You have enough time to watch ${name} and left with ${Math.ceil(diff)} minutes free time.`);
  } else {
    console.log(`You don't have enough time to watch ${name}, you need ${Math.ceil(diff)} more minutes.`);
  }
}
lunchBreak(["Game of Thrones", "60", "96"]); // 08