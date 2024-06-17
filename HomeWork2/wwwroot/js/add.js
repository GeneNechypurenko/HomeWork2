function updatePreview() {
    document.querySelector('.add-title').textContent = document.getElementById('Title').value || 'Your Movie Title';
    document.querySelector('.preview-rating').textContent = `IMDb: ${document.getElementById('Rating').value || '9.9'}`;
    document.querySelector('.preview-genre').textContent = document.getElementById('Genre').value || 'movie';
    document.querySelector('.preview-year').textContent = document.getElementById('Year').value || '2024';
    document.querySelector('.preview-director').textContent = document.getElementById('Director').value || 'Movie Director';
    document.querySelector('.add-description').textContent = document.getElementById('Description').value || 'Your movie description is here...';
}

function previewImage(event) {
    const reader = new FileReader();
    reader.onload = function () {
        const output = document.getElementById('output-file');
        output.src = reader.result;
    };
    reader.readAsDataURL(event.target.files[0]);
}

document.addEventListener("DOMContentLoaded", () => {
    document.getElementById("clear-button").addEventListener("click", (event) => {
        event.preventDefault();
        clearForm();
    });

    function clearForm() {
        document.getElementById("Title").value = "";
        document.getElementById("Rating").value = "";
        document.getElementById("Genre").value = "";
        document.getElementById("Year").value = "";
        document.getElementById("Director").value = "";
        document.getElementById("Description").value = "";
        document.getElementById("input-file").value = "";
        document.getElementById("output-file").src = "/background/default-poster.jpg";
        updatePreview();
    }
});