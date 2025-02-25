function occurrences(sentence, word) {
  let resultCount = 0;

  let words = sentence.split(' ');
  for (let currentWord of words) {
    if (currentWord == word) {
      resultCount++;
    }
  }

  console.log(resultCount);
}

occurrences('This is a word and it also is a sentence', 'is');