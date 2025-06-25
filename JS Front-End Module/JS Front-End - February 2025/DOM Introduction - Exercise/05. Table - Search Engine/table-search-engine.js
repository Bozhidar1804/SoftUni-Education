function solve() {
   let rows = Array.from(document.querySelectorAll(".container tbody tr"));
   let searchText = document.getElementById("searchField").value.toLowerCase();

   for (let row of rows) {
      row.classList.remove("select");
   }

   if (searchText.trim() === "") {
      return;
   }

   for (let row of rows) {
      let cells = row.querySelectorAll("td");

      for (let cell of cells) {
         if (cell.textContent.toLowerCase().includes(searchText)) {
            row.classList.add("select");
            break;
         }
      }
   }

   document.getElementById("searchField").value = "";
}