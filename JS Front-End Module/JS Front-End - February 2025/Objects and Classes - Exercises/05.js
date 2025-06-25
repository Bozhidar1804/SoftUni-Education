function inventory(input) {
  let allHeroes = [];

  for (let hero of input) {
    let infoOfHero = hero.split(" / ");
    let currentHero = {};
    currentHero.name = infoOfHero[0];
    currentHero.heroLevel = infoOfHero[1];

    let currentHeroItems = infoOfHero[2].split(", ");
    currentHero.items = currentHeroItems;
    allHeroes.push(currentHero);
  }

  for (let hero of allHeroes.sort((a, b) => a.heroLevel - b.heroLevel)) {
    console.log(`Hero: ${hero.name}`);
    console.log(`level => ${hero.heroLevel}`);
    console.log(`items => ${hero.items.join(", ")}`);
  }
}

inventory([

  'Isacc / 25 / Apple, GravityGun',

  'Derek / 12 / BarrelVest, DestructionSword',

  'Hes / 1 / Desolator, Sentinel, Antara'

]);