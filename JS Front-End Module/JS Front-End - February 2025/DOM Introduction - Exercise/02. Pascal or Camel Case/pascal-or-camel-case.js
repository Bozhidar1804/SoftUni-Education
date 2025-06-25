function solve() {
  let convention = document.getElementById('naming-convention').value;
  let text = document.getElementById('text').value;
  let resultElement = document.getElementById('result');

  let finalStr = "";

  if (convention == "Camel Case") {
    let allWords = text.toLowerCase().split(' ');
    finalStr += allWords[0];
    for (let i = 1; i < allWords.length; i++) {
      let currentWord = allWords[i];
      let transformed = currentWord[0].toUpperCase() + currentWord.slice(1);
      finalStr += transformed;
    }

    resultElement.textContent = finalStr;
  } else if (convention == "Pascal Case") {
    let allWords = text.toLowerCase().split(' ');
    for (let word of allWords) {
      let transformed = word[0].toUpperCase() + word.slice(1);
      finalStr += transformed;
    }

    resultElement.textContent = finalStr;
  } else {
    resultElement.textContent = "Error!";
  }
}