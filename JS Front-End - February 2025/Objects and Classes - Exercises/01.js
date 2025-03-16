function employees(input) {
  let employees = [];
  for (let name of input) {
    let currentEmployee = {};
    currentEmployee.name = name;
    currentEmployee.number = name.length;

    employees.push(currentEmployee);
  }

  for (let employee of employees) {
    console.log(`Name: ${employee.name} -- Personal Number: ${employee.number}`);
  }
}

employees([

  'Silas Butler',

  'Adnaan Buckley',

  'Juan Peterson',

  'Brendan Villarreal'

]);