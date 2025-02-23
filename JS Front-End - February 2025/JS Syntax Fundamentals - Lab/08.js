function circleArea(argument) {
  let area;
  if (typeof (argument) == 'number') {
    area = Math.PI * Math.pow(argument, 2);
    return console.log(`${area.toFixed(2)}`);
  } else {
    let typeOfInput = typeof (argument);
    return console.log(`We can not calculate the circle area, because we receive a ${typeOfInput}.`);
  }
}