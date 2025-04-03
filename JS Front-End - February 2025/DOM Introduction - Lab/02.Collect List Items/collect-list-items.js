function extractText() {
    let extractedText = document.getElementById('items');
    let items = extractedText.children;

    let result = [];
    for (let li of items) {
        result.push(li.textContent);
    }

    let output = document.getElementById('result');
    output.value += result.join('\n');
}