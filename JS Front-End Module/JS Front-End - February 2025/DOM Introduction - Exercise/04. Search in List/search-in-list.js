function solve() {
   let towns = Array.from(document.querySelectorAll("#towns li"));
   let searchText = document.getElementById('searchText').value.toLowerCase();

   let totalMatches = 0;

   for (let town of towns) {
      town.style.fontWeight = '';
      town.style.textDecoration = '';
   }

   for (let town of towns) {
      if (town.textContent.toLowerCase().includes(searchText) && searchText !== '') {
         totalMatches++;
         town.style.fontWeight = 'bold';
         town.style.textDecoration = 'underline';
      }
   }

   document.getElementById('result').textContent = `${totalMatches} matches found`
}