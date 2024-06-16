const items = document.querySelectorAll('.item');

items.forEach((item) => {
    item.addEventListener('click', () => {
        let movieId = item.getAttribute('data-movie-id');
        window.location.href = '/Movies/Details/' + movieId;
    });
});