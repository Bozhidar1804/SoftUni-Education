function radar(speed, area) {
  let speedLimit = 0;
  if (area == "motorway") {
    speedLimit = 130;
  } else if (area == "interstate") {
    speedLimit = 90;
  } else if (area == "city") {
    speedLimit = 50;
  } else if (area == "residential") {
    speedLimit = 20;
  }

  if (speed <= speedLimit) {
    console.log(`Driving ${speed} km/h in a ${speedLimit} zone`);
  } else {
    let exceededSpeed = speed - speedLimit;
    let status = "";
    if (exceededSpeed <= 20) {
      status = "speeding";
    } else if (exceededSpeed <= 40) {
      status = "excessive speeding";
    } else if (exceededSpeed > 40) {
      status = "reckless driving";
    }

    console.log(`The speed is ${exceededSpeed} km/h faster than the allowed speed of ${speedLimit} - ${status}`);
  }
}