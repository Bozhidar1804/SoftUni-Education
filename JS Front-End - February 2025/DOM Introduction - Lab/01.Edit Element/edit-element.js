function editElement(element, match, replace) {
    while (element.textContent.includes(match)) {
        element.textContent = element.textContent.replace(match, replace);
    }
}