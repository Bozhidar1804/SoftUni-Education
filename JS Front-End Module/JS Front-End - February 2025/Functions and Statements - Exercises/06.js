function passwordValidator(password) {
  let length = false;
  let consists = true;
  let leastDigits = false;

  let passwordLength = password.length;
  if (passwordLength >= 6 && passwordLength <= 10) {
    length = true;
  }

  for (let char of password) {
    if (!(/^[a-zA-Z0-9]$/.test(char))) {
      consists = false;
    }
  }

  let digitsCount = 0;
  for (let char of password) {
    if (/^[0-9]$/.test(char)) {
      digitsCount++;
    }
  }
  if (digitsCount >= 2) {
    leastDigits = true;
  }

  if (length && consists && leastDigits) {
    console.log("Password is valid");
  } else {
    if (length == false) {
      console.log("Password must be between 6 and 10 characters");
    }
    if (consists == false) {
      console.log("Password must consist only of letters and digits");
    }
    if (leastDigits == false) {
      console.log("Password must have at least 2 digits");
    }
  }
}

passwordValidator('logIn');