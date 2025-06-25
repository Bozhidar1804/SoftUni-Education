function pascalCaseSplitter(input) {
  let indexCounter = 0;
  let indexesOfUpperCases = [];

  for (let char of input) {
    if (char == char.toUpperCase() && indexCounter !== 0) {
      indexesOfUpperCases.push(indexCounter);
    }

    indexCounter++;
  }

  indexesOfUpperCases.push(input.length);

  let resultArr = [];
  let previousIndex = 0;

  for (let index of indexesOfUpperCases) {
    let currentWord = input.substring(previousIndex, index);

    resultArr.push(currentWord);
    previousIndex = index;
  }

  console.log(resultArr.join(", "));
}

pascalCaseSplitter('HoldTheDoor');