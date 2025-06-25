function touristShop(input) {
  let budget = Number(input[0]);

  let index = 1;
  let command = input[index];

  let totalProducts = 0;
  let totalPrice = 0;

  while (command !== 'Stop') {
    totalProducts++;

    index++;
    command = input[index];

    currentPrice = Number(command);

    if (totalProducts % 3 === 0) {
      currentPrice = currentPrice / 2;
    }
    totalPrice += currentPrice;

    if (totalPrice > budget) {
      break;
    }

    index++;
    command = input[index];
  }

  if (totalPrice < budget) {
    console.log(`You bought ${totalProducts} products for ${totalPrice.toFixed(2)} leva.`)
  } else {
    console.log(`You don't have enough money!`)
    console.log(`You need ${(totalPrice - budget).toFixed(2)} leva!`)
  }
}
touristShop(['54', 'Thermal underwear', '24', 'Sunscreen', '45']); // 05

function vetParking(input) {
  let days = Number(input[0]);
  let hoursPerDay = Number(input[1]);

  let index = 0;
  let command = input[index];
  let currentDay;
  let sumPerDay = 0;
  let totalSum = 0;

  for (let i = 1; i <= days; i++) {
    currentDay = Number(i);
    for (let j = 1; j <= hoursPerDay; j++) {
      if (currentDay % 2 === 0) {
        if (j % 2 == 0) {
          sumPerDay += 1;
        } else {
          sumPerDay += 2.50;
        }
      } else {
        if (j % 2 == 0) {
          sumPerDay += 1.25;
        } else {
          sumPerDay += 1;
        }
      }
    }
    console.log(`Day: ${currentDay} - ${sumPerDay.toFixed(2)} leva`)
    totalSum += sumPerDay;
    sumPerDay = 0;
  }
  console.log(`Total: ${totalSum.toFixed(2)} leva`)
}
vetParking(['2', '5']); // 06