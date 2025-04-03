function colorize() {
    let table = document.querySelector('table');
    let rows = table.getElementsByTagName('tr');

    for (let i = 1; i < rows.length; i += 2) {
        rows[i].style.backgroundColor = 'teal';
    }
}