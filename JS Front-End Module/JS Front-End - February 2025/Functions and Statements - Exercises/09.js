function loadingBar(number) {
  let percentagePrints = number / 10;

  if (percentagePrints != 10) {
    let result = `${number}% [`;
    for (let i = 1; i <= percentagePrints; i++) {
      result += "%";
    }

    let remainingDots = 10 - percentagePrints;
    for (let i = 1; i <= remainingDots; i++) {
      result += ".";
    }

    result += "]\nStill loading...";
    console.log(result);
  } else if (percentagePrints == 10) {
    console.log(`100% Complete!\n[%%%%%%%%%%]`);;
  }
}

loadingBar(30);