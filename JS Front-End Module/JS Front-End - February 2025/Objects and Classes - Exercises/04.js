function movies(input) {
  let allMovies = [];

  for (let command of input) {

    if (command.startsWith("addMovie ")) {
      command = command.replace("addMovie ", "");
      let currentMovie = { name: command };
      allMovies.push(currentMovie);
    } else if (command.includes("directedBy")) {
      let [movieName, director] = command.split(" directedBy ");
      if (allMovies.some(movie => movie.name == movieName)) {
        let movieToFind = allMovies.find(movie => movie.name == movieName);
        movieToFind.director = director;
      }
    } else if (command.includes("onDate")) {
      let [movieName, date] = command.split(" onDate ");
      if (allMovies.some(movie => movie.name == movieName)) {
        let movieToFind = allMovies.find(movie => movie.name == movieName);
        movieToFind.date = date;
      }
    }
  }

  for (let movie of allMovies) {
    if (movie.hasOwnProperty("name") && movie.hasOwnProperty("director") && movie.hasOwnProperty("date")) {
      console.log(JSON.stringify(movie));
    }
  }
}

movies([

  'addMovie Fast and Furious',

  'addMovie Godfather',

  'Inception directedBy Christopher Nolan',

  'Godfather directedBy Francis Ford',

  'Coppola',

  'Godfather onDate 29.07.2018',

  'Fast and Furious onDate 30.07.2018',

  'Batman onDate 01.08.2018',

  'Fast and Furious directedBy Rob Cohen'

]);