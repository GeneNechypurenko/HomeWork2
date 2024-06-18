const deleteButton = document.querySelector('.delete-button');

deleteButton.addEventListener('click', () => {
    const movieId = deleteButton.dataset.movieId;
    window.location.href = `/Movies/Delete/${movieId}`;
});


const editButton = document.querySelector('.edit-button');

editButton.addEventListener('click', () => {
    const movieId = editButton.dataset.movieId;
    window.location.href = `/Movies/Edit/${movieId}`;
});