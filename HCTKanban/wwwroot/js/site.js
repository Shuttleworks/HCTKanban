//site.js
//let tasks = JSON.parse(localStorage.getItem('tasks')) || [];
let tasks = [];
getData();



document.addEventListener("DOMContentLoaded", function () {
    renderTasks(tasks);
});

const logoutButton = document.getElementById("logout");

logoutButton.addEventListener('click', function (event) {
    window.location.href = '/login/logout';
});

const refreshButton = document.getElementById("refresh");

refreshButton.addEventListener('click', function (event) {
    getData();
});

//Function to render tasks on the board
function renderTasks(taskstorender) {
    const columns = ['todo', 'in-progress', 'done', 'done-instore'];

    columns.forEach(columnId => {
        const column = document.getElementById(columnId);
        column.querySelector('.task-container').innerHTML = '';
        dataId = column.dataset.status;

        taskstorender.forEach(task => {
            if (task.status === dataId) {
                const taskElement = createTaskElement(task.content, task.id);
                column.querySelector('.task-container').appendChild(taskElement);
            }

        });

    });

}

function createTaskElement(content, id) {
    const taskId = id;
    const task = document.createElement("div");

    task.id = taskId;
    task.className = "task";
    task.draggable = true;
    task.innerHTML =
        `${content} <span class="delete-btn" onclick="deleteTask('${taskId}')">[x]</span>`;
    task.addEventListener("dragstart", drag);
    return task;
}

//Function to delete a task
function deleteTask(taskId) {
    
    if (confirm('Are you sure you want to remove this box?')) {
        tasks = tasks.filter(task => task.id !== taskId);
        //updateLocalStorage(tasks);
        ajaxDeleteBox(taskId);
        //renderTasks(tasks);
    }
    
}

function allowDrop(event) {
    event.preventDefault();
}

function drag(event) {
    event.dataTransfer.setData("text/plain", event.target.id);
}

function drop(event, columnId) {
    event.preventDefault();
    const dest = document.querySelector("#"+columnId);

    const data = event.dataTransfer.getData("text/plain");
    const draggedElement = document.getElementById(data);
    console.log(draggedElement);

    if (draggedElement) {
        const taskStatus = columnId;

        updateTaskStatus(data, taskStatus);
        ajaxSendBoxStatus(data, dest.dataset.status);
       
        event.target.querySelector('.task-container').appendChild(draggedElement);
    }
}

function addTask(columnId) {
    const taskInput = document.getElementById('taskInput');
   
    const taskContent = taskInput.value.trim();

    if (taskContent !== "") {
        taskId = "task-" + Date.now();
        const newTask = {
            id: taskId,
            content: taskInput.options[taskInput.selectedIndex].text,
            status: columnId
        };
        tasks.push(newTask);
        ajaxNewBoxRequest(taskContent, taskId);
      
        taskInput.value = "";
    }
}

//Function to update task status when moved to another column
function updateTaskStatus(taskId, newStatus) {
   
    tasks = tasks.map(task => {

        if (task.id === taskId) {

            return { ...task, status: newStatus };
        }
        return task;
    });

}

//Function to update local storage with current tasks
function updateLocalStorage(localtasks) {
    localStorage.setItem('tasks', JSON.stringify(localtasks));
    //console.log(JSON.stringify(localtasks));
}

function ajaxNewBoxRequest(boxtype, taskId) {
   
    let postObj = { typeId : boxtype, jsId : taskId };

    let post = JSON.stringify(postObj)
    const url = "/state/addbox"
    let xhr = new XMLHttpRequest()
    xhr.open('POST', url, true)
    xhr.setRequestHeader('Content-type', 'application/json; charset=UTF-8')
    xhr.send(post);
    xhr.onload = function () {
        console.log("status" + xhr.status);
        if (xhr.status === 200) {
            //console.log("Post successfully created!")
            getData();
        } else {
            console.log(xhr.status);
        }
    }
}

function ajaxSendBoxStatus(taskId, statusId) {
   
    let postObj = {jsId: taskId, statusId: statusId };

    let post = JSON.stringify(postObj)
    const url = "/state/updateStatus"
    let xhr = new XMLHttpRequest()
    xhr.open('POST', url, true)
    xhr.setRequestHeader('Content-type', 'application/json; charset=UTF-8')
    xhr.send(post);
    xhr.onload = function () {
        if (xhr.status === 200) {
           // console.log("Post successful")
            getData();
        } else {
            console.log(xhr.status);
        }
    }
}

function ajaxDeleteBox(taskId) {
    
    let postObj = taskId;

    let post = JSON.stringify(postObj)
    const url = "/state/deleteBox"
    let xhr = new XMLHttpRequest()
    xhr.open('POST', url, true)
    xhr.setRequestHeader('Content-type', 'application/json; charset=UTF-8')
    xhr.send(post);
    xhr.onload = function () {
        if (xhr.status === 200) {
            console.log("Delete successful")
            getData();
        } else {
            console.log(xhr.status);
        }
    }
}



function getData() {
    // create XHR object
    let xhr = new XMLHttpRequest();
    // the function with the 3 parameters
    const url = "/state/getboxdata";
    xhr.open('GET', url, true);
    // the function called when an xhr transaction is completed
    xhr.onload = function () {
        if (xhr.status == 200) {
            //console.log('Got data');
            //console.log(xhr.responseText);
            tasks = JSON.parse(xhr.responseText);
            renderTasks(tasks);
            updateLocalStorage(tasks);

        } else {
            console.log(xhr.status);
        }
    }
    // the function that sends the request
    xhr.send();
}
