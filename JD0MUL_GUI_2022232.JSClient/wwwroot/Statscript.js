let actorinfos = [];
let studioinfos = [];
let bests = [];
let worsts = [];
let actorrateinfos = [];
let connection = null;
getdata();

let actorIdToUpdate = -1;


function getratingdata() {
    const id = document.getElementById('actorid');
     fetch('http://localhost:36235/Stat/ActorShowsAverage/' + id.value)
        .then(x => x.json())
        .then(y => {
            actorrateinfos = y;
            console.log(actorrateinfos);
            display2();
        });
}

async function getdata() {
    await fetch('http://localhost:36235/Stat/LargestStudio')
        .then(x => x.json())
        .then(y => {
            studioinfos = y;
            console.log(studioinfos);
            display();
        });

    await fetch('http://localhost:36235/Stat/BestTvShowRoles')
        .then(x => x.json())
        .then(y => {
            bests = y;
            console.log(bests);
            display();
        });

    await fetch('http://localhost:36235/Stat/WorstShowActors')
        .then(x => x.json())
        .then(y => {
            worsts = y;
            console.log(worsts);
            display(); 
        });

    await fetch('http://localhost:36235/Stat/ActorBestTvShowRating')
        .then(x => x.json())
        .then(y => {
            actorinfos = y;
            console.log(actorinfos);
            display();
        });
}

function display() {
    document.getElementById('studioinforesultarea').innerHTML = "";
    studioinfos.forEach(t => {
        document.getElementById('studioinforesultarea').innerHTML +=
            "<tr><td>" + t.studioId + "</td><td>"
            + t.studioName + "</td><td>" +
            t.tvShowTitles + "</td></tr>";
    });

    document.getElementById('bestresultarea').innerHTML = "";
    bests.forEach(t => {
        const roleNames = t.roles.map(x => x.roleName).join(", ");
        document.getElementById('bestresultarea').innerHTML +=
            "<tr><td>" + t.title + "</td><td>"
        + roleNames + "</td></tr>";
    });

    document.getElementById('worstresultarea').innerHTML = "";
    worsts.forEach(t => {
        const actorNames = t.actors.map(x => x.actorName).join(", ");
        document.getElementById('worstresultarea').innerHTML +=
            "<tr><td>" + t.title + "</td><td>"
            + actorNames + "</td></tr>";
    });


    document.getElementById('actorinforesultarea').innerHTML = "";
    actorinfos.forEach(t => {
        const titles = t.titles.map(x => x).join(", ");        
        document.getElementById('actorinforesultarea').innerHTML +=
            "<tr><td>" + t.actorName + "</td><td>"
            + titles + "</td><td>" + t.rating + "</td></tr>";
    });
}
function display2() {
    document.getElementById('searchformdiv').style.display = 'flex';
    document.getElementById('actorrateinforesultarea').innerHTML = "";
        document.getElementById('actorrateinforesultarea').innerHTML +=
            "<tr><td>" + actorrateinfos.actorName + "</td><td>"
        + actorrateinfos.avgRating + "</td></tr>";    
}

