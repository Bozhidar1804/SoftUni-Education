function schedule(input) {
  let program = {};

  for (let pair of input) {
    let [weekday, name] = pair.split(" ");

    if (program[weekday]) {
      console.log(`Conflict on ${weekday}!`);
    } else {
      program[weekday] = name;
      console.log(`Scheduled for ${weekday}`);
    }
  }

  for (let weekday in program) {
    console.log(`${weekday} -> ${program[weekday]}`);
  }
}

schedule(['Friday Bob',

  'Saturday Ted',

  'Monday Bill',

  'Monday John',

  'Wednesday George']);