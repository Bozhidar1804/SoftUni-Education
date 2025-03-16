function songs(input) {
  let allSongs = [];
  class Song {
    constructor(typeList, name, time) {
      this.typeList = typeList;
      this.name = name;
      this.time = time;
    }
  }

  let n = Number(input[0]);
  let typeList = input[input.length - 1];;

  for (let i = 1; i <= n; i++) {
    let currentSongInfo = input[i].split('_');
    let currentSong = new Song(currentSongInfo[0], currentSongInfo[1], currentSongInfo[2]);

    allSongs.push(currentSong);
  }

  if (typeList == "all") {
    for (let song of allSongs) {
      console.log(`${song.name}`);
    }
  } else if (typeList != "all") {
    for (let song of allSongs) {
      if (song.typeList == typeList) {
        console.log(`${song.name}`);
      }
    }
  }
}

songs([3,
  'favourite_DownTown_3:14', 'favourite_Kiss_4:16', 'favourite_Smooth Criminal_4:01', 'favourite'
]);