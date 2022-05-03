const apiUrl = "/api/"
const loadButton = document.getElementById('js-load-movie');
const setApiButton = document.getElementById("js-set-api");
const areApiSet = document.getElementById("js-api-set");

setApiButton.addEventListener("click", setApi, false)
loadButton.addEventListener("click", loadMovies, false);

function setApi() {
    let apikeyElement = document.getElementById("js-apikey");
    let apikey = $(apikeyElement).val();
    if (apikey.length === 0) {
        alert("no apikey")
    }
    setApiCookie(apikey);
    areApiSet.value = true;
}

function loadMovies() {
    if (areApiSet.value === "true") {
        alert("loadingMovies");
        loadMostViewMovies();
    }
}




function setApiCookie(api) {
    const d = new Date();
    d.setTime(d.getTime() + (1 * 1 * 60 * 60 * 1000));
    let expires = "expires=" + d.toUTCString();
    console.log(expires);
    document.cookie = "ApiCookie=" + api + ";" + expires + ";path=/";
}
function loadMostViewMovies(api) {
    $.get(apiUrl + "mostviewedmovies", function (data) {
        console.log(data);
    });
}