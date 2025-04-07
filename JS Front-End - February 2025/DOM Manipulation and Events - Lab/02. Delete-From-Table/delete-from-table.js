function deleteByEmail() {
    let text = document.getElementsByName("email")[0].value;
    let rows = document.querySelectorAll("tbody tr");

    let isDeleted = false;
    for (let row of rows) {
        if (row.querySelectorAll("td")[1].textContent == text) {
            document.getElementById("result").textContent = "Deleted.";
            row.parentNode.removeChild(row);
            isDeleted = true;
        }
    }

    if (!isDeleted) {
        document.getElementById("result").textContent = "Not found.";
    }
}
