function validatePasswords() {
    var password = document.getElementById("password").value;
    var confirmPassword = document.getElementById("confirmPassword").value;
    var passwordError = document.getElementById("passwordError");

    if (password !== confirmPassword) {
        passwordError.innerText = "Passwords do not match";
        return false; // Prevent form submission
    } else {
        passwordError.innerText = "";
        return true; // Allow form submission
    }
}