function validateform() {
    var nombre = document.getElementById("nombre").value
    var apellido = document.getElementById("apellido").value

    if (nombre == null || nombre == "") {
        alert("Debe indicarse un nombre");
        return false;
    } else if (apellido == null || apellido == "") {
        alert("Debe indicarse un apellido");
        return false;
    }
}

function vaciarcampos() {

    var elements = document.getElementsByTagName("input");
    for (var i = 0; i < elements.length; i++) {
        if (elements[i].type == "text" || elements[i].type == "number") {
            elements[i].value = "";
        }
    }
    var radio = document.querySelector('input[type=radio][name=sexo]:checked');
    radio.checked = false;
}