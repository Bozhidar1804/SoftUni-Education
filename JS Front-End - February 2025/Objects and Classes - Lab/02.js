function city(object) {
  let entries = Object.entries(object);

  for (let [key, value] of entries) {
    console.log(`${key} -> ${value}`);
  }
}