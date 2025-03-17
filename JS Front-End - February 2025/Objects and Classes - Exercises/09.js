function dictionary(input) {
  let all = [];
  for (let pair of input) {
    let currentPair = JSON.parse(pair);
    let term = Object.keys(currentPair)[0];
    let definition = currentPair[term];

    // Find index of existing term
    let existingIndex = all.findIndex(entry => entry.term === term);

    if (existingIndex !== -1) {
      // Update definition if term exists
      all[existingIndex].definition = definition;
    } else {
      // Otherwise, add new term-definition pair
      all.push({ term, definition });
    }
  }

  //  Correct sorting (sort array of objects by term)
  all.sort((a, b) => a.term.localeCompare(b.term));

  //  Correct iteration and printing
  for (let entry of all) {
    console.log(`Term: ${entry.term} => Definition: ${entry.definition}`);
  }
}

dictionary(['{"Cup":"A small bowl-shaped container for drinking from, typically having a handle"}', '{"Cake":"An item of soft sweet food made from a mixture of flour, fat, eggs, sugar, and other ingredients, baked and sometimes iced or decorated."}', '{"Watermelon":"The large fruit of a plant of the gourd family, with smooth green skin, red pulp, and watery juice."}', '{"Music":"Vocal or instrumental sounds (or both) combined in such a way as to produce beauty of form, harmony, and expression of emotion."}', '{"Art":"The expression or application of human creative skill and imagination, typically in a visual form such as painting or sculpture, producing works to be appreciated primarily for their beauty or emotional power."}']
);