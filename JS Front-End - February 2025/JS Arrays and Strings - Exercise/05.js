// maybe this exercise could be solved much easier with string methods

function revealWords(find, sentence) {
  let wordsToFind = find.split(', ');
  let sentenceArr = sentence.split(' ');
  let wordIndex = 0;

  for (let word of sentenceArr) {
    let isAsteriskWord = false;
    for (let char of word) {
      if (char == "*") {
        isAsteriskWord = true;
        break;
      }
    }

    if (isAsteriskWord) {
      for (let wordToFind of wordsToFind) {
        if (word.length == wordToFind.length) {
          word = wordToFind;
          sentenceArr[wordIndex] = word;
        }
      }
    }
    wordIndex++;
  }

  console.log(sentenceArr.join(" "));
}

revealWords('great, learning', 'softuni is ***** place for ******** new programming languages');