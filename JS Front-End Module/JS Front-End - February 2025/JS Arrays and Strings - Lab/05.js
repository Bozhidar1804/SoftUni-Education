function replace(input, word) {
  let text = input;
  while (text.includes(word)) {
    text = text.replace(word, '*'.repeat(word.length));
  }

  console.log(text);
}

replace('A small sentence with some words',

  'small');