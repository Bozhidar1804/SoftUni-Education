function fruit(fruit, grams, price) {
  let convertedWeight = grams / 1000;
  let moneyNeeded = price * convertedWeight;
  console.log(`I need $${moneyNeeded.toFixed(2)} to buy ${convertedWeight.toFixed(2)} kilograms ${fruit}.`);
}