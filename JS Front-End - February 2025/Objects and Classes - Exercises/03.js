function store(firstArray, secondArray) {
  let storeStorage = {};

  for (let i = 0; i < firstArray.length; i += 2) {
    let productName = firstArray[i];
    let nextIndex = i + 1;
    let productQuantity = Number(firstArray[nextIndex]);
    storeStorage[productName] = productQuantity;
  }

  for (let i = 0; i < secondArray.length; i += 2) {
    let productName = secondArray[i];
    let nextIndex = i + 1;
    let productQuantity = Number(secondArray[nextIndex]);

    if (storeStorage[productName]) {
      storeStorage[productName] += productQuantity;
    } else {
      storeStorage[productName] = productQuantity;
    }
  }

  for (let product in storeStorage) {
    console.log(`${product} -> ${storeStorage[product]}`);
  }
}

store([

  'Chips', '5', 'CocaCola', '9', 'Bananas',

  '14', 'Pasta', '4', 'Beer', '2'

],

  [

    'Flour', '44', 'Oil', '12', 'Pasta', '7',

    'Tomatoes', '70', 'Bananas', '30'

  ]);