let tvshows = [];
let connection = null;
getdata();
setupSignalR();

let tvShowIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:36235/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("TvShowCreated", (user, message) => {
        getdata();
    });

    connection.on("TvShowDeleted", (user, message) => {
        getdata();
    });

    connection.on("TvShowUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:36235/tvshow')
        .then(x => x.json())
        .then(y => {
            tvshows = y;
            //console.log(tvshows);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    tvshows.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.tvShowId + "</td><td>"
            + t.title + "</td><td>" +
        `<button type="button" onclick="remove(${t.tvShowId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.tvShowId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:36235/tvshow/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function showupdate(id) {
    document.getElementById('titletoupdate').value = tvshows.find(t => t['tvShowId']==id)['title']
    document.getElementById('updateformdiv').style.display = 'flex';
    tvShowIdToUpdate = id;
}


function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('titletoupdate').value;
    fetch('http://localhost:36235/tvshow', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { title: name, tvShowId: tvShowIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('title').value;
    fetch('http://localhost:36235/tvshow', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { title: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
