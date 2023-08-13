// Validation in 3 places doesn't feel good but I wanted immediate validation, there must be a better way to de-dupe this.
$(document).ready(function () {
    fNameValid = false;
    lNameValid = false;
    emailValid = false
    toppingValid = false;

    incomeValid = true;
    sillyHatSpendValid = true;

    $("#firstName").on('input', function () {
        fNameValid = validateNameField("firstName", "firstNameError");
        checkShowFinance();
    });
    $("#lastName").on('input', function () {
        lNameValid = validateNameField("lastName", "lastNameError");
        checkShowFinance();
    });
    $("#emailAddress").on('input', function () {
        emailValid = validateEmail();
        checkShowFinance();
    });
    $("#topping").on('input', function () {
        toppingValid = validateTopping();
        checkShowFinance();
    });
    $("#income").on('input', function () {
        incomeValid = validateCurrency("income", "incomeError", 1, 1000000);
        checkEnableSubmit();
    });
    $("#sillyHatSpend").on('input', function () {
        sillyHatSpendValid = validateCurrency("sillyHatSpend", "sillyHatSpendError", 1, 10000);
        checkEnableSubmit();
    });
    $("#quoteForm").submit(function () {
        fNameValid = validateNameField("firstName", "firstNameError");
        lNameValid = validateNameField("lastName", "lastNameError");
        emailValid = validateEmail();
        toppingValid = validateTopping();
        incomeValid = validateCurrency("income", "incomeError", 0, 1000000);
        sillyHatSpendValid = validateCurrency("sillyHatSpend", "sillyHatSpendError", 1, 10000);
        return checkEnableSubmit();
    })

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
        let emailValid = emailAddress.match(simpleEmailRegex);
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

    function validateCurrency(id, errorId, min, max) {
        let stringVal = String($(`#${id}`).val());
        let value = Number(stringVal)
        if (stringVal == "" || value < min || value > max) {
            $(`#${errorId}`).show(100);
            $(`#${id}`).addClass("inputError")
            return false;
        }
        $(`#${errorId}`).hide(100);
        $(`#${id}`).removeClass("inputError")
        return true;
    }

    function checkShowFinance() {
        if (fNameValid && lNameValid && emailValid && toppingValid && $("#financialInformation").is(":hidden")) {
            $("#financialInformation").show(500);
        }
        checkEnableSubmit();
    }

    function checkEnableSubmit() {
        if (fNameValid && lNameValid && emailValid && toppingValid && incomeValid && sillyHatSpendValid) {
            $("#submitButton").prop("disabled", false);
            return true;
        }
        $("#submitButton").prop("disabled", true);
        return false;
    }
});