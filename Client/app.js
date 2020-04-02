/*
(function($){
    function processForm( e ){
        var dict = {
        	Title : this["title"].value,
            Director: this["director"].value,
            Genre: this["genre"].value
        };

        $.ajax({
            url: 'https://localhost:44325/api/movie',
            dataType: 'json',
            type: 'get',
            contentType: 'application/json',
            data: JSON.stringify(dict),
            success: function( data, textStatus, jQxhr ){
                $('#response').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
            }
        });

        e.preventDefault();
    }

    $('#my-form').submit( processForm );
})(jQuery);

function addNewMovie(){
    $.ajax({
        url: 'https://localhost:44325/api/movie',
        dataType: 'json',
        type: 'post',
        contentType: 'application/json',
        data: JSON.stringify(dict),
        success: function( data, textStatus, jQxhr ){
            $('#response pre').html( data );
        },
        error: function( jqXhr, textStatus, errorThrown ){
            console.log( errorThrown );
        }
    });
};

function searchForMovie(){
    $("#my-form").
};

*/


//Dylan

$(function (){
    var $title = $('#title');
    var $director = $('#director');
    var $genre = $('#genre');

    $.ajax({
        type: 'GET',
        url: 'https://localhost:44325/api/movie',
        dataType: 'json',
        contentType: 'application/json',
        success: function(movies){
            $.each(movies, function(i, movies){
                $movies.append('<li>name: ' + movies.title +', genre: ' + movies.genre + '</li>');
            });
        },
        error: function(){
            alert('Error Loading Movies')
        }
    });

    $('#addNewMovie').on('click', function (){
        var movie = {
            title: $title.value(),
            director: $director.value(),
            genre: $genre.value(),
        };
        $.ajax({
            type: 'POST',
            url:'https://localhost:44325/api/movie',
            data: movie,
            success: function( data, textStatus, jQxhr ){
                $('#response pre').html( data );
            },
            error: function( jqXhr, textStatus, errorThrown ){
                console.log( errorThrown );
                alert('Error Adding Movie')
            }
        });
    });

});