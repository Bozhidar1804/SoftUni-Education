function cats(input) {
  class Cat {
    constructor(name, age) {
      this.name = name;
      this.age = age;
    }

    meow() {
      console.log(`${this.name}, age ${this.age} says Meow`);
    }
  }

  for (let pair of input) {
    let splitted = pair.split(" ");
    let catObject = new Cat(splitted[0], splitted[1])
    catObject.meow(catObject);
  }
}

cats(['Mellow 2', 'Tom 5']);