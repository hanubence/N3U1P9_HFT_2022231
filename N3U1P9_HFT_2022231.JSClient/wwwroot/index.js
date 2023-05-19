const baseUrl = "http://localhost:45007";
let shelters = [];
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl(`http://localhost:45007/hub`)
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ShelterCreated", (user, message) => {
        getdata();
    });

    connection.on("ShelterDeleted", (user, message) => {
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
    await fetch(`${baseUrl}/Shelter`)
        .then(x => x.json())
        .then(y => {
            shelters = y;
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    shelters.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.shelterId + "</td><td>"
            + t.name + "</td><td>" +
            `<button type="button" onclick="remove(${t.shelterId})">Delete</button>`
            + "</td></tr>";
    });
}

function remove(id) {
    fetch(`${baseUrl}/Shelter/` + id, {
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

function create() {
    let name = document.getElementById('sheltername').value;
    fetch(`${baseUrl}/hub`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { Name: name })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}