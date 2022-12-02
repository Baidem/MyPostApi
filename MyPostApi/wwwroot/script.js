let shortAdress = "https://localhost:7216/";
let myRequest = new Request(shortAdress + "User/GetAllUsers");
let myHeaders = new Headers();
const usersButton = document.querySelector('#users_button');

myHeaders.append("Content-Type", "application/json; charset=utf-8");

//Liste des classes
let myInit = {
    method: "GET",
    headers: myHeaders,
    credentials: "include"
};


usersButton.addEventListener('click', () => { // Start the process

    fetch(myRequest, myInit)
        .then(function (response) {
            return response.json();
        })
        .then(function (data) {
            let list = document.querySelector("#list");
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

////Classe de Français
//let frenchClassroom =
//{
//    "name": "Français",
//    "floor": 5,
//    "corridor": "Salle Homer Simpson"
//};

////Ajouter la classe de français
//let frenchId = 10;
//myInit = {
//    method: "POST",
//    body: JSON.stringify(frenchClassroom),
//    headers: myHeaders,
//    credentials: "include"
//};

//fetch(myRequest, myInit)
//    .then(function (response) {
//        console.log(response);
//        return response.json();
//    })
//    .then(function (data) {
//        console.log(data);
//        let list = document.querySelector("#post");
//        let node = document.createElement("li");
//        let textnode = document.createTextNode(`${data.name} ${data.floor} ${data.corridor}`);
//        node.appendChild(textnode);
//        list.appendChild(node);
//        frenchId = +data.classroomId;
//        console.log(frenchId);
//    })
//    .catch(function (err) {
//        console.log(err);
//    });
////Modifier la classe de français
////LE PUT!!

//frenchClassroom =
//{
//    "name": "Français",
//    "floor": 4,
//    "corridor": "Salle Bart Simpson"
//}
//console.log(frenchId);

//myRequest = new Request(shortAdress + "Class/" + frenchId);
//console.log(myRequest);
//myHeaders.append("Content-Type", "application/json; charset=utf-8");

//myInit = {
//    method: "PUT",
//    body: JSON.stringify(frenchClassroom),
//    headers: myHeaders,
//    credentials: "include"
//};

//fetch(myRequest, myInit)
//    //fetch("https://localhost:5001/Class/28", myInit)
//    .then(function (response) {
//        console.log(response);
//        return response.json();
//    })
//    .then(function (data) {
//        console.log(data);
//        let list = document.querySelector("#put");
//        let node = document.createElement("li");
//        let textnode = document.createTextNode(`${data.name} ${data.floor} ${data.corridor}`);
//        node.appendChild(textnode);
//        list.appendChild(node);
//    })

//    .catch(function (err) {
//        console.log(err);
//    });

////LE DELETE!!
//idToDelete = 15;
//myRequest = new Request(shortAdress + "Class/" + idToDelete);

//myInit = {
//    method: "DELETE",
//    //body: JSON.stringify(myObject),
//    headers: myHeaders,
//    credentials: "include"
//};

//fetch(myRequest, myInit)
//    .then(function (response) {
//        console.log(response);
//        return response.json();
//    })
//    .then(function (data) {
//        console.log(data);
//        let list = document.querySelector("#delete");
//        let node = document.createElement("li");
//        let textnode = document.createTextNode(`${data.classroomId} ${data.name}`);
//        node.appendChild(textnode);
//        list.appendChild(node);
//    })

//    .catch(function (err) {
//        console.log(err);
//    });