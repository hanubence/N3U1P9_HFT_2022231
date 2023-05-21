const baseUrl = "http://localhost:50000";
let shelters = [];


let shelter;
let form = document.getElementById('editform');

let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl(`${baseUrl}/hub`)
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ShelterCreated", (user, message) => {
        getdata();
    });

    connection.on("ShelterDeleted", (user, message) => {
        getdata();
    });

    connection.on("ShelterUpdated", (user, message) => {
        getdata();
    });

    connection.on("Connected", () => {
        console.log("SignalR connected");
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

    await fetch(`${baseUrl}/Stats/GetAverageBudget`)
        .then(x => x.json())
        .then(x => {
            document.querySelector('#stats > #avg').innerHTML =
                `$${Math.round(x)}`;
        });
}

function display() {
    document.getElementById('shelterdata').innerHTML = "";
    shelters.forEach(t => {
        addShelter(t)
    });
}

function addShelter(shelter) {
    console.log(shelter)
    document.getElementById('shelterdata').innerHTML +=
        "<tr><td>" + shelter.shelterId + "</td>" +
        "<td>" + shelter.name + "</td>" +
        "<td>" + shelter.address + "</td>" +
        "<td>$" + shelter.annualBudget + "</td>" +
        `<td><button type="button" onclick="remove(${shelter.shelterId})">Delete</button>` +
        `<button type="button" onclick="showUpdateMenu(${shelter.shelterId})">Update</button>`
        + "</td></tr>";
}

function showUpdateMenu(id) {
    form.style.setProperty('display', 'flex');

    shelter = shelters.find(s => s.shelterId == id);

    document.querySelector('#editform > #shelterID').textContent = `Editing ID: ${shelter.shelterId}`;
    document.querySelector('#editform > #name').value = shelter.name;
    document.querySelector('#editform > #address').value = shelter.address;
    document.querySelector('#editform > #budget').value = shelter.annualBudget;
}

function update() {
    fetch(`${baseUrl}/Shelter`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
        body: JSON.stringify(
            {
                "shelterId": shelter.shelterId,
                "name": document.querySelector('#editform > #name').value,
                "address": document.querySelector('#editform > #address').value,
                "annualBudget": document.querySelector('#editform > #budget').value
            }
        )
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch(error => {
            console.error('Error:', error);
        });

    form.style.setProperty('display', 'none');
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
    fetch(`${baseUrl}/Shelter`, {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            {
                "name": document.querySelector('#createform > #name').value,
                "address": document.querySelector('#createform > #address').value,
                "annualBudget": document.querySelector('#createform > #budget').value
            })
        })
        .then(response => response)
        .then(data => {

            document.querySelector('#createform > #name').value = "";
            document.querySelector('#createform > #address').value = "";
            document.querySelector('#createform > #budget').value = "";

            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
}