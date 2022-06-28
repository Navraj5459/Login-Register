$(document).ready(function () {
    $.validator.addMethod('passwordValidate', function (value) {
        return /^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,16}$/.test(value);
    }, 'PLEASE ENTER A VALID PASSWORD!');

    $.validator.addMethod('EmailValidate', function (value) {
        return /^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$/.test(value);
    }, 'PLEASE ENTER A VALID EMAIL ADDRESS!');

    $.validator.addMethod('MobileNumberValidate', function (value) {
        return /^((\+)?(977[-]))?(\d{10}){1}?$/.test(value);
    }, 'PLEASE ENTER A VALID MOBILE NUMBER!');

    $.validator.addMethod('UserNameValidate', function (value) {
        return /^[A-Za-z][A-Za-z0-9_]{7,29}$/.test(value);
    }, 'PLEASE ENTER A VALID USERNAME!');

    $("#SignUp").validate({
        rules: {
            UserName: {
                required: true,
                UserNameValidate: true
            },
            Password: {
                required: true,
                passwordValidate: true
            },
            ConfirmPassword: {
                required: true,
                passwordValidate: true
            },
            FullName: {
                required: true
            },
            Email: {
                required: true,
                EmailValidate: true
            },
            MobileNumber: {
                required: true,
                MobileNumberValidate: true
            }
        },
        messages: {
            UserName: {
                required: "USERNAME IS REQUIRED!",
                UserNameValidate: "PLEASE ENTER VALIDATE USERNAME!"
            },
            Password: {
                required: "PASSWORD IS REQUIRED!",
                passwordValidate: "PLEASE ENTER VALIDATE PASSWORD!"
            },
            ConfirmPassword: {
                required: "CONFIRM PASSWORD IS REQUIRED!",
                passwordValidate: "PLEASE ENTER VALIDATE CONFIRM PASSWORD!"
            },
            FullName: {
                required: "FULL NAME IS REQUIRED!"
            },
            Email: {
                required: "EMAIL IS REQUIRED!",
                EmailValidate: "PLEASE ENTER VALIDATE EMAIL ADDRESS!"
            },
            MobileNumber: {
                required: "MOBILE NUMBER IS REQUIRED!",
                MobileNumberValidate: "PLEASE ENTER VALIDATE MOBILE NUMBER!"
            }
        }
    })
    $("#btnSubmit").on("click", function () {
        if ($("#SignUp").valid()) {
            if (CheckPasswordAndConfirmPassword()) {
                $("#SignUp").submit();
            }
        }
    });
    $("#ConfirmPassword").on("change blur keyup", function () {
        var confirmpassword = $(this).val();
        var password = $("#Password").val();
        if (confirmpassword != password) {
            $("#ConfirmPassword").css("border-color", "red");
            $("#ConfirmPassword").css("color", "red");
        }
        if (confirmpassword == password) {
            $("#ConfirmPassword").css("border-color", "green");
            $("#ConfirmPassword").css("color", "");
        }
    });
    $("#btnBack").on("click", function () {
        window.location.href = "/Login/Login";
    });

    function CheckPasswordAndConfirmPassword() {
        var confirmpassword = $("#ConfirmPassword").val();
        var password = $("#Password").val();
        if (confirmpassword == password) {
            return true;
        }
        if (confirmpassword != password) {
            return false;
        }
    }
});