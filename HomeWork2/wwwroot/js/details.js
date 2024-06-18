const deleteButton = document.querySelector('.delete-button');

deleteButton.addEventListener('click', () => {
    const movieId = deleteButton.dataset.movieId;
    window.location.href = `/Movies/Delete/${movieId}`;
});
