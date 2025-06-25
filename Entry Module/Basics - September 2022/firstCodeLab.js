function squareArea(input) {
  let a = Number(input[0]);
  let area = a * a;
  console.log(area);
}
squareArea([4]); // 03

function inchToCm(input) {
  let inches = input[0];
  let convertor = inches * 2.54;
  console.log(convertor);
}
inchToCm([5]); // 04


function greeting(input) {
  let name = input[0];
  console.log(`Hello, ${name}!`);
}
greeting(['Bozhidar']);  // 05


function concatenateData(input) {
  let firstName = input[0];
  let lastName = input[1];
  let age = Number(input[2]);
  let town = input[3];
  let result = `You are ${firstName} ${lastName}, a ${age}-years old person from ${town}.`
  console.log(result);
}
concatenateData(['Bozhidar', 'Ivanov', 16, 'Yambol']); // 06

function projectsCreation(input) {
  let name = input[0];
  let projects = input[1];
  let hours = projects * 3;
  let result = `The architect ${name} will need ${hours} hours to complete ${projects} project/s.`
  console.log(result);
}

projectsCreation(['Bozhidar', '3']); // 07

function petShop(input) {
  let dogfood = input[0];
  let catfood = input[1];
  let result = (dogfood * 2.5) + (catfood * 4);
  console.log(`${result} lv.`); 
}

petShop(['5', '4']); // 08

function yardGreeing(input) {
  let squareMeters = input[0];
  let wholePrice = squareMeters * 7.61;
  let discount = 0.18 * wholePrice;
  let finalPrice = wholePrice - discount;
  console.log(`The final price is: ${finalPrice} lv.`);
  console.log(`The discount is: ${discount} lv.`);
}

yardGreeing([550]); // 09
