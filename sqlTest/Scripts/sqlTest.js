$(document).ready(function () {

    function getMovies() {
        $.ajax({
            url: 'api/Movie',
            type: 'GET',
            success: function (data) {
                $('#content').empty();
                data.forEach(function (movie) {
                    $('#content').append($('<tr></tr>')
                        .append('<td>' + movie.Title + '</td>').attr('id', movie.Id)
                        .append('<td>' + movie.Director + '</td>')
                        .append('<td>' + movie.Description + '</td>')
                        .append($('<td></td>')
                            .append($('<input type="button" value="Edit"/>').addClass('btn btn-warning'))
                            .append($('<input type="button" value="Delete" />').addClass('btn btn-danger'))));
                });
            }
        })
    }
    function AddMovie(newMovie) {
        $.ajax({
            url: 'api/Movie',
            type: 'POST',
            data: newMovie,
            success: function () {
                getMovies();
            },
            error: function (result) {
                console.log(result.responseText);
            }
        });
    }

    function DeleteMovie(id) {
        console.log(id);
        $.ajax({
            url: 'api/Movie/' + id,
            type: 'Delete',
            //data: movie.Id,
            success: function () {
                getMovies();
            },
            error: function (result) {
                console.log(result.responseText);
            }
        })
    }

    getMovies();

    $('table').on('click', '.btn-warning', function (e) {
        e.preventDefault();
        console.log(e.target.id);
    });

    $('table').on('click', '.btn-danger', function (e) {
        e.preventDefault();
        var id = $(this).closest('tr').attr('id');
        //console.log(e.target.id);
        //var movie = $(this).closest('tr:has(td)').map(function (i, v) {
        //    var td = $('td', this);
        //    return {
        //        Id: $(this).attr('id'),
        //        Title: td.eq(0).text(),
        //        Director: td.eq(1).text(),
        //        Description: td.eq(2).text()
        //    }
        //}).get();
        //console.log(movie[0]);
        //DeleteMovie(movie[0]);
        DeleteMovie(id);
    });

    $('#submit').click(function () {
        var movie = {
            Title: $('#title').val(),
            Director: $('#director').val(),
            Description: $('#description').val(),
        }
        console.log(movie);
        AddMovie(movie);
    });
});