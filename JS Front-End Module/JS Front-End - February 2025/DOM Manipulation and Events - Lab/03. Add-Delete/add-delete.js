function addItem() {

    function deleteElement(e) {
        e.currentTarget.parentElement.remove();
    }

    let text = document.getElementById("newItemText").value;

    if (text == '') { return; };

    let li = document.createElement("li");
    li.appendChild(document.createTextNode(text));

    let deleteButton = document.createElement('a');
    deleteButton.setAttribute('href', '#');
    deleteButton.textContent = '[Delete]';

    deleteButton.addEventListener('click', deleteElement);

    li.appendChild(deleteButton);

    document.getElementById("items").appendChild(li);
    document.getElementById("newItemText").value = "";
}
