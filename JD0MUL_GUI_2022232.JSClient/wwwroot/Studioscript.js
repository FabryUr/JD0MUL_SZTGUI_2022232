let studios = [];
let connection = null;
getdata();
setupSignalR();

let studioIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:36235/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("StudioCreated", (user, message) => {
        getdata();
    });

    connection.on("StudioDeleted", (user, message) => {
        getdata();
    });

    connection.on("StudioUpdated", (user, message) => {
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
    await fetch('http://localhost:36235/studio')
        .then(x => x.json())
        .then(y => {
            studios = y;
            //console.log(studios);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    studios.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.studioId + "</td><td>"
            + t.studioName + "</td><td>" +
        `<button type="button" onclick="remove(${t.studioId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.studioId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:36235/studio/' + id, {
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
    document.getElementById('studionametoupdate').value = studios.find(t => t['studioId'] == id)['studioName']
    document.getElementById('updateformdiv').style.display = 'flex';
    studioIdToUpdate = id;
}


function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('studionametoupdate').value;
    fetch('http://localhost:36235/studio', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { studioName: name, studioId: studioIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('studioName').value;
    fetch('http://localhost:36235/studio', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { studioName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
