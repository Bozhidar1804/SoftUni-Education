function addressBook(input) {
  let addressBook = {};

  for (let pair of input) {
    let [name, address] = pair.split(":");
    addressBook[name] = address;
  }

  let sortedAddressBook = Object.entries(addressBook).sort(([a], [b]) => a.localeCompare(b));

  for (let [name, address] of sortedAddressBook) {
    console.log(`${name} -> ${address}`);
  }
}

addressBook(['Tim:Doe Crossing',

  'Bill:Nelson Place',

  'Peter:Carlyle Ave',

  'Bill:Ornery Rd']);