function nxn(n) {
  let result = "";

  for (let i = 1; i <= n; i++) {
    for (let j = 1; j <= n; j++) {
      result += n + " ";
    }
    result = result.trimEnd();
    result += '\n';
  }

  console.log(result.trimEnd());
}

nxn(3);