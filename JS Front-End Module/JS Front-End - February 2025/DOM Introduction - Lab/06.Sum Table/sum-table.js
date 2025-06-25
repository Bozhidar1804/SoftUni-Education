function sumTable() {
    let table = document.querySelector('table');
    let rows = table.getElementsByTagName('tr');
    let sum = 0;

    for (let i = 0; i < rows.length - 1; i++) {
        let cells = rows[i].getElementsByTagName('td');
        if (cells.length > 1) {  // Ensure there are two columns
            let cost = parseFloat(cells[1].textContent); // Get the value in the second column and convert to a number
            if (!isNaN(cost)) {
                sum += cost;
            }
        }
    }

    let resultArea = document.getElementById('sum');
    resultArea.textContent = sum.toFixed(2);
}