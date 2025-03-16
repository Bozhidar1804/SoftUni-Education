function towns(input) {
  let objectsToPrint = [];

  for (let town of input) {
    let infoSplitted = town.split(" | ");
    let currentTown = {};
    currentTown.town = infoSplitted[0];
    currentTown.latitude = Number(infoSplitted[1]).toFixed(2);
    currentTown.longitude = Number(infoSplitted[2]).toFixed(2);

    objectsToPrint.push(currentTown);
  }

  for (let object of objectsToPrint) {
    console.log(object);
  }
}

towns(['Sofia | 42.696552 | 23.32601',

  'Beijing | 39.913818 | 116.363625']);