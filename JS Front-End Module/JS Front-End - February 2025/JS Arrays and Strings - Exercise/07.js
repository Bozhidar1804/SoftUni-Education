function stringSubstring(searchedWord, text) {
  let textArr = text.split(" ");
  let isWordFound = false;

  for (let word of textArr) {
    if (word.toLowerCase() == searchedWord) {
      isWordFound = true;
    }

    if (isWordFound) {
      console.log(searchedWord);
      break;
    }
  }

  if (!isWordFound) {
    console.log(`${searchedWord} not found!`);
  }
}

stringSubstring('python', 'JavaScript is the best programming language');