function setVailidation(data, idInputs) {
    idInputs.forEach(item => {
        let temp = data.ValidationMessage[item];
        let element = document.getElementById(item);

        if (temp != undefined) {

            setValidationInElement(element, "is-invalid", data.ValidationMessage[item]);
        }
        else {
            setValidationInElement(element, "is-valid", "");
        }
    });
}

function setValidationInElement(element, cssClass, text) {
    element.classList.remove("is-valid");
    element.classList.remove("is-invalid");
    element.classList.add(cssClass);
    element.closest(".form-group").querySelector(".invalid-feedback").innerHTML = text;
}
function getIdInput(id) {
    var functionMap = Array.prototype.map;
    let elements = document.querySelectorAll("#" + id + " .form-group input");
    var selectValues = functionMap.call(elements, function (item) {

        return item.id;

    });
    return selectValues;
}
function checkConfirmPassword(args, elementPassword) {
    let currentInput = args;
    let password = document.getElementById(elementPassword).value;
    if (currentInput.value != password) {
        setValidationInElement(currentInput, "is-invalid", "password does not match");
        return;
    }
    setValidationInElement(currentInput, "is-valid", "");
}
function clearValid(element) {
    element.classList.remove("is-valid");
    element.classList.remove("is-invalid");
    element.closest(".form-group").querySelector(".invalid-feedback").innerHTML = "";
}