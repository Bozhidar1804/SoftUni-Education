function oddOccurrences(input) {
  input = input.toLowerCase();
  let splitted = input.split(" ");
  let allWords = [];

  for (let word of splitted) {
    let currentWord = {};
    currentWord.name = word;

    if (allWords.some(w => w.name == currentWord.name)) {
      let existingWord = allWords.find(w => w.name == currentWord.name);
      existingWord.count++;
    } else {
      currentWord.count = 1;
      allWords.push(currentWord);
    }
  }

  let result = "";
  for (let word of allWords.filter(w => w.count % 2 != 0)) {
    result += word.name + " ";
  }

  console.log(result.trimEnd());
}

oddOccurrences('Cake IS SWEET is Soft CAKE sweet Food');