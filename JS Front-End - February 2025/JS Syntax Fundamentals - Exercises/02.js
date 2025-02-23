function calculate(numberOfPeople, typeGroup, day) {
  let pricePerPerson;
  let totalPrice;
  if (typeGroup == `Students`) {
    if (day == `Friday`) {
      pricePerPerson = 8.45;
    } else if (day == `Saturday`) {
      pricePerPerson = 9.80;
    } else if (day == `Sunday`) {
      pricePerPerson = 10.46;
    }
    totalPrice = numberOfPeople * pricePerPerson;

    if (numberOfPeople >= 30) {
      totalPrice = totalPrice - (totalPrice * 0.15);
    }

  } else if (typeGroup == `Business`) {
    if (day == `Friday`) {
      pricePerPerson = 10.90;
    } else if (day == `Saturday`) {
      pricePerPerson = 15.60;
    } else if (day == `Sunday`) {
      pricePerPerson = 16;
    }

    totalPrice = numberOfPeople * pricePerPerson;

    if (numberOfPeople >= 100) {
      let promo = pricePerPerson * 10;
      totalPrice = totalPrice - promo;
    }
  } else if (typeGroup == `Regular`) {
    if (day == `Friday`) {
      pricePerPerson = 15;
    } else if (day == `Saturday`) {
      pricePerPerson = 20;
    } else if (day == `Sunday`) {
      pricePerPerson = 22.50;
    }

    totalPrice = numberOfPeople * pricePerPerson;

    if (numberOfPeople >= 10 && numberOfPeople <= 20) {
      totalPrice = totalPrice - (totalPrice * 0.05);
    }
  }

  return console.log(`Total price: ${totalPrice.toFixed(2)}`);
}