function parkingLot(input) {
  let allCars = [];

  for (let command of input) {
    let commandSplitted = command.split(", ");
    let currentCar = {};
    currentCar.number = commandSplitted[1];

    if (commandSplitted[0] == "IN") {
      if (!allCars.some(c => c.number === currentCar.number)) {
        allCars.push(currentCar);
      }
    } else if (commandSplitted[0] == "OUT") {
      let index = allCars.findIndex(car => car.number == currentCar.number);
      if (index != -1) {
        allCars.splice(index, 1);
      }
    }
  }

  if (allCars.length > 0) {
    for (let car of allCars.sort((a, b) => a.number.localeCompare(b.number))) {
      console.log(`${car.number}`);
    }
  } else {
    console.log("Parking Lot is Empty");
  }
}

parkingLot(['IN, CA2844AA',

  'IN, CA1234TA',

  'OUT, CA2844AA',

  'OUT, CA1234TA']);