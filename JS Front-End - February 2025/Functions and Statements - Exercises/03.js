function charsInRange(char1, char2) {
  let result = "";

  if (char1 < char2) {
    char1 = String.fromCharCode(char1.charCodeAt(0) + 1);
    while (char1 < char2) {
      result += char1 + " ";

      char1 = String.fromCharCode(char1.charCodeAt(0) + 1);
    }
  } else if (char1 > char2) {
    char2 = String.fromCharCode(char2.charCodeAt(0) + 1);
    while (char1 > char2) {
      result += char2 + " ";

      char2 = String.fromCharCode(char2.charCodeAt(0) + 1);
    }
  }

  console.log(result.trimEnd());
}

charsInRange('C', '#');