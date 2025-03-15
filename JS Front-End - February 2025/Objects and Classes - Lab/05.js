function phoneNumbers(input) {
  let phoneBook = {};
  for (let pair of input) {
    let [name, phoneNumber] = pair.split(" ");
    phoneBook[name] = phoneNumber;
  }

  let result = "";
  for (let name in phoneBook) {
    result += `${name} -> ${phoneBook[name]}\n`;
  }

  console.log(result);
}

phoneNumbers(['Tim 0834212554',

  'Peter 0877547887',

  'Bill 0896543112',

  'Tim 0876566344']);