
const deleteButton = document.getElementById('deleteButton');

deleteButton.addEventListener('click', function () {
    if (confirm('Are you sure you want to delete this movie?')) {
        deleteForm.submit();
    }
});
