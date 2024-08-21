function updateOriginalValues() {
    originalValues.title = document.getElementById('Title').value;
    originalValues.rating = document.getElementById('Rating').value;
    originalValues.genre = document.getElementById('Genre').value;
    originalValues.year = document.getElementById('Year').value;
    originalValues.director = document.getElementById('Director').value;
    originalValues.description = document.getElementById('Description').value;
    originalValues.posterUrl = document.getElementById('output-file').src;
}

function updatePreview() {
    updateOriginalValues();
    document.querySelector('.preview-title h1').textContent = document.getElementById('Title').value;
    document.querySelector('.preview-rating').textContent = `IMDb: ${document.getElementById('Rating').value || document.getElementById('Rating').value}`;
    document.querySelector('.preview-genre').textContent = document.getElementById('Genre').value;
    document.querySelector('.preview-year').textContent = document.getElementById('Year').value;
    document.querySelector('.preview-director').textContent = document.getElementById('Director').value;
    document.querySelector('.add-description').textContent = document.getElementById('Description').value;
}

function previewImage(event) {
    const reader = new FileReader();
    reader.onload = function () {
        const output = document.getElementById('output-file');
        output.src = reader.result;
        updateOriginalValues();
    };
    reader.readAsDataURL(event.target.files[0]);
}

function resetForm() {
    document.getElementById('Title').value = originalValues.title;
    document.getElementById('Rating').value = originalValues.rating;
    document.getElementById('Genre').value = originalValues.genre;
    document.getElementById('Year').value = originalValues.year;
    document.getElementById('Director').value = originalValues.director;
    document.getElementById('Description').value = originalValues.description;
    document.getElementById('output-file').src = originalValues.posterUrl;
    updatePreview();
}

document.getElementById('clear-button').addEventListener('click', resetForm);

document.getElementById('Title').addEventListener('input', updatePreview);
document.getElementById('Rating').addEventListener('input', updatePreview);
document.getElementById('Genre').addEventListener('input', updatePreview);
document.getElementById('Year').addEventListener('input', updatePreview);
document.getElementById('Director').addEventListener('input', updatePreview);
document.getElementById('Description').addEventListener('input', updatePreview);
document.getElementById('input-file').addEventListener('change', previewImage);
