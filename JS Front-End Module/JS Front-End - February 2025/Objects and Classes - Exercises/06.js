function wordTracker(allWords) {
  let searchedWords = allWords[0].split(" ");
  allWords.shift();
  let results = [];

  for (let word of searchedWords) {
    let currentWord = {};
    currentWord.name = word;
    currentWord.count = 0;
    for (let trackedWord of allWords) {
      if (trackedWord == currentWord.name) {
        currentWord.count++;
      }
    }

    results.push(currentWord);
  }

  for (let word of results.sort((a, b) => b.count - a.count)) {
    console.log(`${word.name} - ${word.count}`);
  }
}

wordTracker([

  'this sentence',

  'In', 'this', 'sentence', 'you', 'have',

  'to', 'count', 'the', 'occurrences', 'of',

  'the', 'words', 'this', 'and', 'sentence',

  'because', 'this', 'is', 'your', 'task'

]);