$(document).ready(function () {
    $.validator.addMethod('passwordValidate', function (value) {
        return /^(?=.*[0-9])(?=.*[!@#$%^&*])(?=.*[A-Z])[a-zA-Z0-9!@#$%^&*]{8,16}$/.test(value);
    }, 'PLEASE ENTER A VALID PASSWORD!');

    $("#ChangePassword").validate({
        rules: {
            OldPassword: {
                required: true,
                passwordValidate: true
            },
            Password: {
                required: true,
                passwordValidate: true
            },
            ConfirmPassword: {
                required: true,
                passwordValidate: true
            }
        },
        messages: {
            OldPassword: {
                required: "OLD PASSWORD IS REQUIRED!",
                passwordValidate: "PLEASE ENTER VALIDATE OLD PASSWORD!"
            },
            Password: {
                required: "PASSWORD IS REQUIRED!",
                passwordValidate: "PLEASE ENTER VALIDATE PASSWORD!"
            },
            ConfirmPassword: {
                required: "CONFIRM PASSWORD IS REQUIRED!",
                passwordValidate: "PLEASE ENTER VALIDATE CONFIRM PASSWORD!"
            }
        }   
    })

    $("#btnSubmit").on("click", function (e) {
        e.preventDefault();
        if ($("#ChangePassword").valid()) {
            if (CheckPasswordAndConfirmPassword() == true && CheckPasswordAndOldPassword() == true) {
                $("#ChangePassword").submit();
            }
            else {
                return false;
            }
        }
    });

    $("#Password").on("change blur keyup", function () {
        var password = $(this).val();
        var oldpassword = $("#OldPassword").val();
        if (oldpassword == password) {
            $("#Password").css("border-color", "red");
            $("#Password").css("color", "red");
        }
        if (oldpassword != password) {
            $("#Password").css("border-color", "green");
            $("#Password").css("color", "");
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

    function CheckPasswordAndConfirmPassword() {
        var confirmpassword = $("#ConfirmPassword").val();
        var password = $("#Password").val();
        if (confirmpassword == password) {
            return true;
        }
        if (confirmpassword != password) {
            Swal.fire({
                title: 'New Password is not same as Confirm Password',
                icon: 'error',
                confirmButtonText: 'Ok'
            });
            return false;
        }
    }

    function CheckPasswordAndOldPassword() {
        var OldPassword = $("#OldPassword").val();
        var password = $("#Password").val();
        if (OldPassword == password) {
            Swal.fire({
                title: 'New Password is same as old Password',
                icon: 'error',
                confirmButtonText: 'Ok'
            });
            return false;
        }
        if (OldPassword != password) {
            return true;
        }
    }
});