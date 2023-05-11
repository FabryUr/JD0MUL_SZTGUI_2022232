let actors = [];
let connection = null;
getdata();
setupSignalR();

let actorIdToUpdate = -1;

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:36235/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ActorCreated", (user, message) => {
        getdata();
    });

    connection.on("ActorDeleted", (user, message) => {
        getdata();
    });

    connection.on("ActorUpdated", (user, message) => {
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
    await fetch('http://localhost:36235/actor')
        .then(x => x.json())
        .then(y => {
            actors = y;
            //console.log(actors);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    actors.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.actorId + "</td><td>"
            + t.actorName + "</td><td>" +
        `<button type="button" onclick="remove(${t.actorId})">Delete</button>` +
        `<button type="button" onclick="showupdate(${t.actorId})">Update</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch('http://localhost:36235/actor/' + id, {
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
    document.getElementById('actornametoupdate').value = actors.find(t=>t['actorId']==id)['actorName']
    document.getElementById('updateformdiv').style.display = 'flex';
    actorIdToUpdate = id;
}


function update() {
    document.getElementById('updateformdiv').style.display = 'none';
    let name = document.getElementById('actornametoupdate').value;
    fetch('http://localhost:36235/actor', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { actorName: name, actorId: actorIdToUpdate })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('actorname').value;
    fetch('http://localhost:36235/actor', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { actorName: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}
