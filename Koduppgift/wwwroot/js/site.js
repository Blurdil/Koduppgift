


const apiUrl = "/api/"
const setApiButton = document.getElementById("js-set-api");

setApiButton.addEventListener("click", setApi, false)


function setApi() {
    let apikeyElement = document.getElementById("js-apikey");
    let apikey = $(apikeyElement).val();
    if (apikey.length === 0) {
        alert("no apikey")
    }
    setApiCookie(apikey);
    loadTopRatedMovies();
}


function setApiCookie(api) {
    const d = new Date();
    d.setTime(d.getTime() + (1 * 1 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    document.cookie = "ApiCookie=" + api + ";" + expires + ";path=/";
}
function loadTopRatedMovies(api) {
    $.get(apiUrl + "mostviewedmovies", function (data) {
        let el = document.getElementById('TopRatedMovies');
        var json = JSON.parse(data);

        var movieSource = document.getElementById('movieTmpl').innerHTML;
        var template = Handlebars.compile(movieSource);
        el.innerHTML = template(json);
    });
}

function loadMovieInformation(id) {
    let movieCard = $(event.target).closest(".card")[0].innerHTML;
    let elMovie = document.getElementById("movie");
    elMovie.innerHTML = "";
    elMovie.innerHTML = movieCard;
    var el = document.getElementById("RelatedInformation");
    el.classList.remove("hidden");
    $.get(apiUrl + "SimilarMovies", { id: id }, function (data) {
        let el = document.getElementById('SimilarMovies');
        el.innerHTML = "";
        var json = JSON.parse(data);
        var movieSource = document.getElementById('movieTmpl').innerHTML;
        var template = Handlebars.compile(movieSource);
        el.innerHTML = template(json);
    });
    $.get(apiUrl + "Comments", { id: id }, function (data) {
        let el = document.getElementById("Comments");
        el.innerHTML = "";
        var json = JSON.parse(data);
        var commentsSource = document.getElementById("commentsTmpl").innerHTML;
        var template = Handlebars.compile(commentsSource);
        el.innerHTML = template(json);
    })
    document.getElementById("CollapseTopRatedButton").classList.remove("hidden");
    document.getElementById("collapseTopRated").classList.remove("show");
}