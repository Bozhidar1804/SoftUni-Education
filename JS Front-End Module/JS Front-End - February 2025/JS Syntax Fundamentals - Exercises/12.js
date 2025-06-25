function cooking(number, op1, op2, op3, op4, op5) {
  let startingNumber = Number(number);
  let combinedOperations = [op1, op2, op3, op4, op5];

  for (let operation of combinedOperations) {
    switch (operation) {
      case ("chop"):
        startingNumber = startingNumber / 2;
        console.log(startingNumber);
        break;
      case ("dice"):
        startingNumber = Math.sqrt(startingNumber);
        console.log(startingNumber);
        break;
      case ("spice"):
        startingNumber++;
        console.log(startingNumber);
        break;
      case ("bake"):
        startingNumber = startingNumber * 3;
        console.log(startingNumber);
        break;
      case ("fillet"):
        startingNumber = startingNumber - (startingNumber * 0.20);
        console.log(startingNumber);
        break;
    }
  }
}

cooking('32', 'chop', 'chop', 'chop', 'chop', "chop");