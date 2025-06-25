function hashtags(input) {
  let inputArr = input.split(" ");
  let resultArr = [];

  for (let word of inputArr.filter(word => word.startsWith("#"))) {
    if (word.length == 1) {
      continue;
    }

    let wordToCheck = word.substring(1);

    let isOnlyLetters = /^[A-Za-z]+$/.test(wordToCheck);
    if (isOnlyLetters) {
      resultArr.push(wordToCheck)
    }
  }

  for (let result of resultArr) {
    console.log(result);
  }
}

hashtags('The symbol # is known #variously in English-speaking #regions as the #number sign');