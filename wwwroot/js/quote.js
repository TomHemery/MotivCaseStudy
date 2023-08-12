$(document).ready(function () {
    fNameValid = false;
    lNameValid = false;
    emailValid = false
    toppingValid = false;

    $("#firstName").keyup(function () {
        fNameValid = validateNameField("firstName", "firstNameError");
        checkShowFinance();
    });
    $("#lastName").keyup(function () {
        lNameValid = validateNameField("lastName", "lastNameError");
        checkShowFinance();
    });
    $("#emailAddress").keyup(function () {
        emailValid = validateEmail();
        checkShowFinance();
    });
    $("#topping").keyup(function () {
        toppingValid = validateTopping();
        checkShowFinance();
    });

    function validateNameField(id, errorId) {
        let nameValue = $(`#${id}`).val().trim();
        if (nameValue == "") {
            $(`#${errorId}`).show(100);
            $(`#${id}`).addClass("inputError")
            return false;
        }
        $(`#${errorId}`).hide(100);
        $(`#${id}`).removeClass("inputError")
        return true;
    }

    function validateEmail() {
        const simpleEmailRegex = /^.+@.+\..+$/g;
        let emailAddress = String($("#emailAddress").val()).toLowerCase().trim();
        console.log(emailAddress);
        let emailValid = emailAddress.match(simpleEmailRegex);
        console.log(emailValid);
        if (!emailValid) {
            $(`#emailAddressError`).show(100);
            $(`#emailAddress`).addClass("inputError")
            return false;
        }
        $(`#emailAddressError`).hide(100);
        $(`#emailAddress`).removeClass("inputError")
        return true;
    }

    function validateTopping() {
        let toppingValue = $("#topping").val();
        if (
            ["", "pineapple", "Pineapple"].includes(toppingValue) ||
            toppingValue.length < 3
        ) {
            $(`#toppingError`).show(100);
            $(`#topping`).addClass("inputError")
            return false;
        } 
        $(`#toppingError`).hide(100);
        $(`#topping`).removeClass("inputError")
        return true;
    }

    function checkShowFinance() {
        if (fNameValid && lNameValid && emailValid && toppingValid && $("#financialInformation").is(":hidden")) {
            $("#financialInformation").show(500);
        }
    }
});