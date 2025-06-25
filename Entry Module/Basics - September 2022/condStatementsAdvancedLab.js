function dayOfWeek(input) {
  let dayOfWeek = Number(input[0]);

  switch (dayOfWeek) {
    case 1:
      console.log('Monday');
      break;
    case 2:
      console.log('Tuesday');
      break;
    case 3:
      console.log('Wednesday');
      break;
    case 4:
      console.log('Thursday');
      break;
    case 5:
      console.log('Friday');
      break;
    case 6:
      console.log('Saturday');
      break;
    case 7:
      console.log('Sunday');
      break;
    default:
      console.log('Error');
  }
}
dayOfWeek(['1']); // 01

function weekendOrWorkingDay(input) {
  let day = input[0];

  switch (day) {
    case 'Monday':
    case 'Tuesday':
    case 'Wednesday':
    case 'Thursday':
    case 'Friday':
      console.log('Working day');
      break;
    case 'Saturday':
    case 'Sunday':
      console.log('Weekend');
      break;
    default:
      console.log('Error');
      break;
  }
}
weekendOrWorkingDay(['Monday']); // 02

function animalType(input) {
  let animal = input[0];

  switch (animal) {
    case 'dog':
      console.log('mammal');
      break;
    case 'crocodile':
    case 'tortoise':
    case 'snake':
      console.log('reptile');
      break;
    default:
      console.log('unknown');
      break;
  }
}
animalType(['dog']); // 03

function personalTitles(input) {
  let age = Number(input[0]);
  let gender = input[1];

  if (gender == 'f') {
    if (age < 16) {
      console.log('Miss')
    } else {
      console.log('Ms.')
    }
  } else {
    if (age < 16) {
      console.log('Master');
    } else {
      console.log('Mr.')
    }
  }

}
personalTitles(['12', 'f']); // 04

function smallShop(input) {
  let productName = input[0];
  let townName = input[1];
  let quantity = Number(input[2]);

  let priceTotal = 0;

  if (townName == 'Sofia') {
    if (productName == 'coffee') {
      priceTotal = 0.50 * quantity;
    } else if (productName == 'water') {
      priceTotal = 0.80 * quantity;
    } else if (productName == 'beer') {
      priceTotal = 1.20 * quantity;
    } else if (productName == 'sweets') {
      priceTotal = 1.45 * quantity;
    } else if (productName == 'peanuts') {
      priceTotal = 1.60 * quantity;
    }
  } else if (townName == 'Plovdiv') {
    if (productName == 'coffee') {
      priceTotal = 0.40 * quantity;
    } else if (productName == 'water') {
      priceTotal = 0.70 * quantity;
    } else if (productName == 'beer') {
      priceTotal = 1.15 * quantity;
    } else if (productName == 'sweets') {
      priceTotal = 1.30 * quantity;
    } else if (productName == 'peanuts') {
      priceTotal = 1.50 * quantity;
    }
  } else if (townName == 'Varna') {
    if (productName == 'coffee') {
      priceTotal = 0.45 * quantity;
    } else if (productName == 'water') {
      priceTotal = 0.70 * quantity;
    } else if (productName == 'beer') {
      priceTotal = 1.10 * quantity;
    } else if (productName == 'sweets') {
      priceTotal = 1.35 * quantity;
    } else if (productName == 'peanuts') {
      priceTotal = 1.55 * quantity;
    }
  }
  console.log(priceTotal);
}
smallShop(['coffee', 'Varna', '2']); // 05

function numberInRange(input) {
  let number = Number(input[0]);

  if (number >= -100 && number !== 0 && number <= 100) {
    console.log('Yes');
  } else {
    console.log('No');
  }
}
numberInRange(); // 06

function workingHours(input) {
  let time = Number(input[0]);
  let day = input[1];

  if ((time >= 10 && time <= 18) && (day == 'Monday' || day == 'Tuesday' || day == 'Wednesday' || day == 'Thursday' || day == 'Friday' || day == 'Saturday')) {
    console.log('open');
  } else {
    console.log('closed');
  }
}
workingHours(['11', 'Monday']); // 07

function cinemaTicket(input) {
  let day = input[0];

  if (day == 'Monday' || day == 'Tuesday' || day == 'Friday') {
    console.log('12');
  } else if (day == 'Wednesday' || day == 'Thursday') {
    console.log('14');
  } else if (day == 'Saturday' || day == 'Sunday') {
    console.log('16');
  }
}
cinemaTicket(['Monday']); // 08

function fruitOrVegetable(input) {
  let food = input[0];

  switch (food) {
    case 'banana':
    case 'apple':
    case 'kiwi':
    case 'cherry':
    case 'lemon':
    case 'grapes':
      console.log('fruit');
      break;
    case 'tomato':
    case 'cucumber':
    case 'pepper':
    case 'carrot':
      console.log('vegetable');
      break;
    default:
      console.log('unknown');
      break;
  }
}
fruitOrVegetable(['banana']); // 09

function invalidNumber(input) {
  let number = Number(input[0]);
  let isValid = (number >= 100 && number <= 200) || (number == 0);

  if (!isValid) {
    console.log('invalid');
  }
}
invalidNumber(['1']); // 010

function fruitShop(input) {
  let fruit = input[0];
  let day = input[1];
  let quantity = Number(input[2]);

  let priceTotal = 0;

  if (day == 'Monday' || day == 'Tuesday' || day == 'Wednesday' || day == 'Thursday' || day == 'Friday') {
    if (fruit == 'banana') {
      priceTotal = 2.50 * quantity;
    } else if (fruit == 'apple') {
      priceTotal = 1.20 * quantity;
    } else if (fruit == 'orange') {
      priceTotal = 0.85 * quantity
    } else if (fruit == 'grapefruit') {
      priceTotal = 1.45 * quantity
    } else if (fruit == 'kiwi') {
      priceTotal = 2.70 * quantity
    } else if (fruit == 'pineapple') {
      priceTotal = 5.50 * quantity
    } else if (fruit == 'grapes') {
      priceTotal = 3.85 * quantity
    } else {
      console.log('error');
    }
  } else if (day == 'Saturday' || day == 'Sunday') {
    if (fruit == 'banana') {
      priceTotal = 2.70 * quantity;
    } else if (fruit == 'apple') {
      priceTotal = 1.25 * quantity;
    } else if (fruit == 'orange') {
      priceTotal = 0.90 * quantity
    } else if (fruit == 'grapefruit') {
      priceTotal = 1.60 * quantity
    } else if (fruit == 'kiwi') {
      priceTotal = 3.00 * quantity
    } else if (fruit == 'pineapple') {
      priceTotal = 5.60 * quantity
    } else if (fruit == 'grapes') {
      priceTotal = 4.20 * quantity
    } else {
      console.log('error');
    }
  }
  console.log(priceTotal.toFixed(2));
}
fruitShop(); // 011