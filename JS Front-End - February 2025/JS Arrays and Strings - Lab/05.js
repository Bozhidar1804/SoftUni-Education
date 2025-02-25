function replace(input, word) {
  let text = input;
  while (text.includes(word)) {
    text = text.replace(word, '*'.repeat(word.length));
  }

  console.log(text);
}