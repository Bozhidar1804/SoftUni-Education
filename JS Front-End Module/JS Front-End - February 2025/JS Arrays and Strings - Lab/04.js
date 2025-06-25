function substring(stringInput, startingIndex, count) {
  let result = "";
  result = stringInput.substring(startingIndex, startingIndex + count);
  console.log(result);
}

substring('ASentence', 1, 8);