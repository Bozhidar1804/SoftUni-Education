function USDtoBGN(input) {
  let usd = input[0];
  let bgn = usd * 1.79549;
  console.log(bgn);
}
USDtoBGN([3]); // 01

function radiansToDegrees(input) {
  let radians = Number(input[0]);
  let degree = radians * 180 / Math.PI;
  console.log(degree);
}
radiansToDegrees(["3.1416"]); // 02

function depositCalculator(input) {
  let depositSum = Number(input[0]);
  let depositPeriod = Number(input[1]);
  let annualInterestRate = Number(input[2]);
  let finalSum = depositSum + depositPeriod * ((depositSum * annualInterestRate / 100) / 12);
  console.log(finalSum);
}
depositCalculator(['200', '3', '5.7']); // 03

function vacationBookList(input) {
  let pages = Number(input[0]);
  let pagesPerHour = Number(input[1]);
  let days = Number(input[2]);
  let totalTime = pages / pagesPerHour;
  let everyDay = totalTime / days;
  console.log(everyDay);
}
vacationBookList(["212", "20", "2"]) // 04

function suppliesForSchool(input) {
  let pens = Number(input[0]);
  let markers = Number(input[1]);
  let liters = Number(input[2]);
  let discount = Number(input[3]);
  let pricePens = pens * 5.80;
  let priceMarkers = markers * 7.20;
  let priceLiters = liters * 1.20;
  let finalPrice = pricePens + priceMarkers + priceLiters;
  let priceAfterDiscount = finalPrice - (finalPrice * discount / 100);
  console.log(priceAfterDiscount);
}
suppliesForSchool(["2 ", "3", "4", "25"]); // 05

function repainting(input) {
  let nylon = Number(input[0]);
  let paint = Number(input[1]);
  let thinner = Number(input[2]);
  let hours = Number(input[3]);

  let nylonSum = (nylon + 2) * 1.50;
  let paintSum = (paint * 1.1) * 14.50;
  let thinnerSum = thinner * 5;
  let bags = 0.40;

  let materialsSum = nylonSum + paintSum + thinnerSum + bags;
  let workers = materialsSum * 0.3 * hours;

  let finalPrice = materialsSum + workers;
  console.log(finalPrice);
}
repainting(["10", "11", "4", "8"]); // 06

function foodDelivery(input) {
  let chickenMenus = Number(input[0]);
  let fishMenus = Number(input[1]);
  let veggieMenu = Number(input[2]);

  let chickenMenusPrice = chickenMenus * 10.35;
  let fishMenusPrice = fishMenus * 12.40;
  let veggieMenuPrice = veggieMenu * 8.15;

  let menusPrice = chickenMenusPrice + fishMenusPrice + veggieMenuPrice;
  let dessertPrice = menusPrice * 0.2;
  let delivery = 2.50;

  let finalPrice = menusPrice + dessertPrice + delivery;
  console.log(finalPrice);
}
foodDelivery(["2", "4", "3"]); // 07

function basketballEquipment(input) {
  let anualFee = Number(input[0]);

  let basketballShoes = anualFee - (anualFee * 0.4);
  let basketballSuit = basketballShoes - (basketballShoes * 0.2);
  let basketballBall = basketballSuit / 4;
  let basketballAccessories = basketballBall / 5;

  let finalPrice = anualFee + basketballShoes + basketballSuit + basketballBall + basketballAccessories;
  console.log(finalPrice);
}
basketballEquipment(["365"]); // 08

function aquarium(input) {
  let length = Number(input[0]);
  let width = Number(input[1]);
  let height = Number(input[2]);
  let percentage = Number(input[3]);

  let volumeOfAquarium = length * width * height;
  let volumeInLiters = volumeOfAquarium * 0.001
  let occupiedSpace = percentage / 100;
  let necessaryLiters = volumeInLiters * (1 - occupiedSpace);
  console.log(necessaryLiters);
}
aquarium(['85', '75', '47', '17']); // 09