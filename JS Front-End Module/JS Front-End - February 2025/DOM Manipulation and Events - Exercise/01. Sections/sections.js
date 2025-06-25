document.addEventListener('DOMContentLoaded', solve);

function solve() {
   let submitBtn = document.querySelector('input[type="submit"]');
   submitBtn.addEventListener('click', addContent);

   function addContent(ev) {
      ev.preventDefault();

      let inputValue = document.querySelector('input[type="text"]').value;
      let inputArr = inputValue.split(', ');

      let contentDiv = document.getElementById('content');

      for (let element of inputArr) {
         let newDiv = document.createElement('div');
         let newParagraph = document.createElement('p');
         newParagraph.textContent = element;
         newDiv.appendChild(newParagraph);

         contentDiv.appendChild(newDiv);
      }
   }
}