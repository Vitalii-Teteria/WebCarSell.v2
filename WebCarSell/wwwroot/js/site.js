$(document).ready(function () {
    $('#login_form').submit(function (e) {
        e.preventDefault();
        var emailLog = $('#emailLog').val();
        var password = $('#password').val();

        $(".error").remove();

        if (emailLog.length < 3) {
            $('#emailLog').after('<span class="error">This field is required</span>');
        } else {
            var regEx = ($('#emailLog').val().match(/.+?\@.+/g) || []).length === 1;
            var validEmail = regEx.test(emailLog);
            if (!validEmail) {
                $('#emailLog').after('<span class="error">Enter a valid email</span>');
            }
        }
        if (password.length < 8) {
            $('#password').after('<span class="error">Password must be atleast 8 characterslong</span>');
        }

    });
});

$(document).ready(function () {
    $('#register_form').submit(function (e) {
        e.preventDefault();
        var emailUser = $('#emailUser').val();
        var password = $('#password').val();
        var UserName = $('#UserName').val();
        var Sname = $('#Sname').val();

        $(".error").remove();

        if (emailUser.length < 3) {
            $('#emailUser').after('<span class="error">This field is required</span>');
        } else {
            var regEx = ($('#emailUser').val().match(/.+?\@.+/g) || []).length === 1;
            var validEmail = regEx.test(emailUser);
            if (!validEmail) {
                $('#emailUser').after('<span class="error">Enter a valid email</span>');
            }
        }
        if (password.length < 8) {
            $('#password').after('<span class="error">Password must be atleast 8 characterslong</span>');
        }
        if (UserName.length < 2)
        {
            $('#UserName').after('<span class="error">User`s name must be atleast 2 characterslong</span>');
        }
        if (Sname.length < 3)
        {
            $('#Sname').after('<span class="error">User`s name must be atleast 2 characterslong</span>');
        }
    });
});

