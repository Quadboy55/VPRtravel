function tabLogin() {
    document.getElementById("tabRegister").setAttribute("class", "hidden");
    document.getElementById("tabLogin").removeAttribute("class");
}

function tabRegister() {
    document.getElementById("tabLogin").setAttribute("class", "hidden");
    document.getElementById("tabRegister").removeAttribute("class");
}