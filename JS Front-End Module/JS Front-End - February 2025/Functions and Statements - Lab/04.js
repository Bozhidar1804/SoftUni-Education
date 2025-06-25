function calculate(product, quantity) {
  let coffeePrice = 1.50;
  let waterPrice = 1.00;
  let cokePrice = 1.40;
  let snacksPrice = 2.00;

  let sum = 0;

  switch (product) {
    case "coffee":
      sum = coffeePrice * quantity;
      break;
    case "water":
      sum = waterPrice * quantity;
      break;
    case "coke":
      sum = cokePrice * quantity;
      break;
    case "snacks":
      sum = snacksPrice * quantity;
      break;
  }

  console.log(sum.toFixed(2));
}