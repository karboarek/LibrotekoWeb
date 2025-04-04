// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
console.log("Przygotowanie zapytania POST...");
const data = { email: 'example@example.com', message: 'Cześć!' };

fetch('https://example.com/api/sendemail', {
    method: 'POST',
    headers: {
        'Content-Type': 'application/json',
    },
    body: JSON.stringify(data),
})
    .then(response => console.log("Odpowiedź serwera:", response))
    .catch(error => console.error("Błąd wysyłki:", error));
