$(document).ready(function () {
    $('input[readonly]').on('keydown', function (e) {
        if (e.which === 8) {
            e.preventDefault();
        }
    });
});
