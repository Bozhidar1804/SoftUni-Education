function hotelRoom(input) {
  let month = input[0];
  let nights = Number(input[1]);

  let apartmentPricePerNight = 0;
  let apartmentPrice = 0;
  let studioPricePerNight = 0;
  let studioPrice = 0;
  let roomType;


  if (month == 'May' && month == 'October') {
    studioPricePerNight = 50;
    studioPrice = studioPricePerNight * nights;
    apartmentPricePerNight = 65;
    apartmentPrice = apartmentPricePerNight * nights;
  } else if (month == 'June' && month == 'September') {
    studioPricePerNight = 75.20;
    studioPrice = studioPricePerNight * nights;
    apartmentPricePerNight = 68.70;
    apartmentPrice = apartmentPricePerNight * nights;
  } else if (month == 'July' && month == 'August') {
    studioPricePerNight = 76;
    studioPrice = studioPricePerNight * nights;
    apartmentPricePerNight = 77;
    apartmentPrice = apartmentPricePerNight * nights;
  }

  if (roomType == 'studio' && nights > 7 && (month == 'May' || month == 'October')) {
    studioPrice = studioPrice * 0.95;
  } else if (roomType == 'studio' && nights > 14 && (month == 'May' || month == 'October')) {
    studioPrice = studioPrice * 0.70;
  } else if (roomType == 'studio' && nights > 14 && (month == 'June' || month == 'September')) {
    studioPrice = studioPrice * 0.80;
  } else if (roomType == 'apartment' && nights > 14) {
    apartmentPrice = apartmentPrice * 0.90;
  }

  console.log(`Apartment: ${apartmentPrice.toFixed(2)} lv.`);
  console.log(`Studio: ${studioPrice.toFixed(2)} lv.`);
}
hotelRoom(["May", "15"]);