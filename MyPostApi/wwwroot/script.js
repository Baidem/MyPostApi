let shortAdress = "https://localhost:7216/";
let allUserRequest = new Request(shortAdress + "User/GetAllUsers");
let myHeaders = new Headers();
const usersButton = document.querySelector('#users_button');
const usersTableButton = document.querySelector('#users_table_button');
const userByIdButton = document.querySelector('#user_id_button');
const userId = document.querySelector('#input_user_id');

myHeaders.append("Content-Type", "application/json; charset=utf-8");

//Liste des classes
let myInit = {
    method: "GET",
    headers: myHeaders,
    credentials: "include"
};


usersButton.addEventListener('click', () => { // Start the process
    fetch(allUserRequest, myInit)
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            let list = document.querySelector("#list");
            list.textContent = "";
            for (let i = 0; i < data.length; i++) {
                let node = document.createElement("li");
                let textnode = document.createTextNode(`${data[i].firstName} ${data[i].lastName}`);
                node.appendChild(textnode);
                list.appendChild(node);
            }
        })
        .catch(function (err) {
            console.log(err);
        });
});

userByIdButton.addEventListener('click', () => { // Start the process
    console.log(userId.value);
    let userByIdRequest = new Request(shortAdress + "User/GetUser/" + userId.value);

    let listoff = document.querySelector('#list');
    listoff.textContent = "";

    fetch(userByIdRequest, myInit)
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            let list = document.querySelector("#user");
            list.textContent = "";
            console.log(data);
            let node = document.createElement("li");
            let textnode = document.createTextNode(`${data.firstName}`);
            node.appendChild(textnode);
            list.appendChild(node);
        })
        .catch(function (err) {
            console.log(err);
        });
});

//usersTableButton.addEventListener('click', () => { // Start the process
//    fetch(allUserRequest, myInit)
//        .then(function (response) {
//            return response.json();
//        })
//        .then(function (data) {
//            let users = document.querySelector("#users");
//            users.textContent = "";
//            for (let i = 0; i < data.length; i++) {

//                let row = document.createElement("tr");

//                let firstCell = document.createElement("td");
//                let textFirstCell = document.createTextNode(`${data[i].firstName}`);
//                row.appendChild(firstCell);
//                firstCell.appendChild(textFirstCell);

//                let secondCell = document.createElement("td");
//                let textSecondCell = document.createTextNode(`${data[i].lastName}`);
//                row.appendChild(secondCell);
//                secondCell.appendChild(textSecondCell);

//                let thirdCell = document.createElement("td");
//                let textThirdCell = document.createTextNode(`${data[i].email}`);
//                row.appendChild(thirdCell);
//                thirdCell.appendChild(textThirdCell);

//                users.appendChild(row);
//            }
//        })
//        .catch(function (err) {
//            console.log(err);
//        });

//});

usersTableButton.addEventListener('click', () => { // Start the process
    fetch(allUserRequest, myInit)
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            let users = document.querySelector("#users");
            users.textContent = "";
            for (let i = 0; i < data.length; i++) {
                let row = document.createElement("tr");
                for (let j in data[i]) {
                    let cell = document.createElement("td");
                    let textCell;
                    textCell = document.createTextNode(`${data[i][j]}`);
                    row.appendChild(cell);
                    cell.appendChild(textCell);
                }
                users.appendChild(row);
            }
        })
        .catch(function (err) {
            console.log(err);
        });

});