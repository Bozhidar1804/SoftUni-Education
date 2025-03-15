function convertToJSON(input) {
  let parsed = JSON.parse(input);
  let entries = Object.entries(parsed);

  for (let [key, value] of entries) {
    console.log(`${key}: ${value}`);
  }
}