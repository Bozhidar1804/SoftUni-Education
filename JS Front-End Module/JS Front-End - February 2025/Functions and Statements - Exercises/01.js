function printSmallestNumber(n1, n2, n3) {
  let inputArr = [n1, n2, n3];
  let smallest = Math.min(...inputArr);
  console.log(smallest);
}