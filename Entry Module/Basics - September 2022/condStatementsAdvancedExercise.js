function cinema(input) {
  let projectionType = input[0];
  let rows = Number(input[1]);
  let columns = Number(input[2]);

  let totalIncome = 0;
  let ticket = 0;

  if (projectionType === 'Premiere') {
    ticket = 12.00;
    totalIncome = (rows * columns) * ticket;
  } else if (projectionType === 'Normal') {
    ticket = 7.50;
    totalIncome = (rows * columns) * ticket
  } else if (projectionType === 'Discount') {
    ticket = 5.00;
    totalIncome = (rows * columns) * ticket
  }

  console.log(`${(totalIncome).toFixed(2)} leva`);
}
cinema(["Premiere", "10", "12"]); // 01

function summerOutfit(input) {
  let degrees = Number(input[0]);
  let period = input[1];

  let outfit;
  let shoes;

  if (10 <= degrees && degrees <= 18) {
    switch (period) {
      case 'Morning': outfit = 'Sweatshirt', shoes = 'Sneakers'; break;
      case 'Afternoon': outfit = 'Shirt', shoes = 'Moccasins'; break;
      case 'Evening': outfit = 'Shirt', shoes = 'Moccasins'; break;
    }
  }
  if (18 < degrees && degrees <= 24) {
    switch (period) {
      case 'Morning': outfit = 'Shirt', shoes = 'Moccasins'; break;
      case 'Afternoon': outfit = 'T-Shirt', shoes = 'Sandals'; break;
      case 'Evening': outfit = 'Shirt', shoes = 'Moccasins'; break;
    }
  }
  if (degrees >= 25) {
    switch (period) {
      case 'Morning': outfit = 'T-Shirt', shoes = 'Sandals'; break;
      case 'Afternoon': outfit = 'Swim Suit', shoes = 'Barefoot'; break;
      case 'Evening': outfit = 'Shirt', shoes = 'Moccasins'; break;
    }
  }
  console.log(`It's ${degrees} degrees, get your ${outfit} and ${shoes}.`);
}
summerOutfit(["16", "Morning"]); // 02

function newHouse(input) {
  let flowersType = input[0];
  let flowersCount = Number(input[1]);
  let budget = Number(input[2]);

  let flowersPrice = 0;

  switch (flowersType) {
    case 'Roses':
      flowersPrice = flowersCount * 5;
      if (flowersCount > 80) {
        flowersPrice = flowersPrice * 0.90;
      }
      break;
    case 'Dahlias':
      flowersPrice = flowersCount * 3.80;
      if (flowersCount > 90) {
        flowersPrice = flowersPrice * 0.85;
      }
      break;
    case 'Tulips':
      flowersPrice = flowersCount * 2.80;
      if (flowersCount > 80) {
        flowersPrice = flowersPrice * 0.85;
      }
      break;
    case 'Narcissus':
      flowersPrice = flowersCount * 3;
      if (flowersCount < 120) {
        flowersPrice = flowersPrice * 1.15;
      }
      break;
    case 'Gladiolus':
      flowersPrice = flowersCount * 2.5;
      if (flowersCount < 80) {
        flowersPrice = flowersPrice * 1.20;
      }
      break;
  }

  if (budget >= flowersPrice) {
    console.log(`Hey, you have a great garden with ${flowersCount} ${flowersType} and ${(budget - flowersPrice).toFixed(2)} leva left.`)
  } else {
    console.log(`Not enough money, you need ${(flowersPrice - budget).toFixed(2)} leva more.`)
  }
}
newHouse(["Roses", "55", "250"]); // 03

function fishingBoat(input) {
  let budget = Number(input[0]);
  let season = input[1];
  let fisherman = Number(input[2]);

  let boatRentPrice = 0;

  switch (season) {
    case 'Spring': boatRentPrice = 3000; break;
    case 'Summer':
    case 'Autumn': boatRentPrice = 4200; break;
    case 'Winter': boatRentPrice = 2600; break;
  }

  if (fisherman <= 6) {
    boatRentPrice = boatRentPrice * 0.90;
  } else if (fisherman <= 11) {
    boatRentPrice = boatRentPrice * 0.85;
  } else if (fisherman >= 12) {
    boatRentPrice = boatRentPrice * 0.75;
  }

  if (fisherman % 2 === 0 && season !== 'Autumn') {
    boatRentPrice = boatRentPrice * 0.95;
  }

  if (budget >= boatRentPrice) {
    console.log(`Yes! You have ${(budget - boatRentPrice).toFixed(2)} leva left.`)
  } else {
    console.log(`Not enough money! You need ${(boatRentPrice - budget).toFixed(2)} leva.`)
  }
}
fishingBoat(["3000", "Summer", "11"]); // 04

function journey(input) {
  let budget = Number(input[0]);
  let season = input[1];

  if (budget <= 100) {
    console.log(`Somewhere in Bulgaria`)
    switch (season) {
      case 'summer':
        budget = budget * 0.30;
        console.log(`Camp - ${budget.toFixed(2)}`);
        break;
      case 'winter':
        budget = budget * 0.70;
        console.log(`Hotel - ${budget.toFixed(2)}`)
        break;
    }
  } else if (budget <= 1000) {
    console.log(`Somewhere in Balkans`)
    switch (season) {
      case 'summer':
        budget = budget * 0.40;
        console.log(`Camp - ${budget.toFixed(2)}`)
        break;
      case 'winter':
        budget = budget * 0.80;
        console.log(`Hotel - ${budget.toFixed(2)}`)
        break;
    }
  } else if (budget > 1000) {
    console.log(`Somewhere in Europe`);
    budget = budget * 0.90;
    console.log(`Hotel - ${budget.toFixed(2)}`);
  }
}
journey(['50', 'summer']); // 05

function operationsBetweenNumbers(input) {
  let firstNumber = Number(input[0]);
  let secondNumber = Number(input[1]);
  let operator = input[2];

  switch (operator) {
    case '+':
      if ((firstNumber + secondNumber) % 2 === 0) {
        console.log(`${firstNumber} + ${secondNumber} = ${firstNumber + secondNumber} - even`)
      } else {
        console.log(`${firstNumber} + ${secondNumber} = ${firstNumber + secondNumber} - odd`)
      }
      break;
    case '-':
      if ((firstNumber - secondNumber) % 2 === 0) {
        console.log(`${firstNumber} - ${secondNumber} = ${firstNumber - secondNumber} - even`)
      } else {
        console.log(`${firstNumber} - ${secondNumber} = ${firstNumber - secondNumber} - odd`)
      }
      break;
    case '*':
      if ((firstNumber * secondNumber) % 2 === 0) {
        console.log(`${firstNumber} * ${secondNumber} = ${firstNumber * secondNumber} - even`)
      } else {
        console.log(`${firstNumber} * ${secondNumber} = ${firstNumber * secondNumber} - odd`)
      }
      break;
    case '/':
      if (secondNumber === 0) {
        console.log(`Cannot divide ${firstNumber} by zero`)
      } else {
        console.log(`${firstNumber} / ${secondNumber} = ${(firstNumber / secondNumber).toFixed(2)}`)
      }
      break;
    case '%':
      if (secondNumber === 0) {
        console.log(`Cannot divide ${firstNumber} by zero`)
      } else {
        console.log(`${firstNumber} % ${secondNumber} = ${firstNumber % secondNumber}`)
      }
  }
}
operationsBetweenNumbers(["10", "12", "+"]); // 06

function skiTrip(input) {
  let days = Number(input[0]);
  let roomType = input[1];
  let feedback = input[2];

  let nights = days - 1;
  let price = 0;

  switch (roomType) {
    case 'room for one person':
      price = nights * 18;
      break;
    case 'apartment':
      price = nights * 25
      if (nights < 10) {
        price = price * 0.70;
      } else if (nights <= 15) {
        price = price * 0.65;
      } else if (nights > 15) {
        price = price * 0.50;
      }
      break;
    case 'president apartment':
      price = nights * 35
      if (nights < 10) {
        price = price * 0.90;
      } else if (nights <= 15) {
        price = price * 0.85;
      } else if (nights > 15) {
        price = price * 0.80;
      }
      break;
  }

  if (feedback === 'positive') {
    price = price * 1.25;
  } else if (feedback === 'negative') {
    price = price * 0.90;
  }
  console.log((price).toFixed(2));
}
skiTrip(["14", "apartment", "positive"]); // 09


function hotelRoom(input) {
  let month = input[0];
  let nights = Number(input[1]);

  let studioNight = 0;
  let apartmentNight = 0;

  let studioPrice = 0;
  let apartmentPrice = 0;

  switch (month) {
    case 'May':
    case 'October': studioNight = 50; apartmentNight = 65; break;
    case 'June':
    case 'September': studioNight = 75.20; apartmentNight = 68.70; break;
    case 'July':
    case 'August': studioNight = 76; apartmentNight = 77; break;
  }

  if (nights > 7 && (month == 'May' || month == 'October')) {
    studioPrice = (studioNight * 0.95) * nights;
  } else if (nights > 14 && (month == 'May' || month == 'October')) {
    studioPrice = (studioNight * 0.70) * nights;
  } else if (nights > 14 && (month == 'June' || month == 'September')) {
    studioPrice = (studioNight * 0.80) * nights;
  } else if (nights > 14) {
    apartmentPrice = (apartmentNight * 0.90) * nights;
  }

  console.log(`Apartment: ${apartmentPrice.toFixed(2)} lv.`);
  console.log(`Studio: ${studioPrice.toFixed(2)} lv.`);
}
hotelRoom(["May", "15"]); // 07 (not finished)