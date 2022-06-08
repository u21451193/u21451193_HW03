var elem = document.getElementById("radioButton");
for (var i = 0; i <= elem.length(); i++) {
    elem.addEventListener("click", function () {
        if (this.classList.contains("ticked")) {
            removeTick(this);
        } else {
            addTick(this);
        }
    });
}

function removeTick(element) {
    element.classList.remove("ticked");
}

function addTick(element) {
    element.classList.add("ticked");
}