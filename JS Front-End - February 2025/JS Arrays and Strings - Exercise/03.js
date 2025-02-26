function names(names) {
  let reOrderedArr = names.sort((a, b) => a.localeCompare(b));

  reOrderedArr.forEach((word, index) => {
    console.log(`${index + 1}.${word}`);
  });
}

names(["John",

  "Bob",

  "Christina",

  "Ema"]);