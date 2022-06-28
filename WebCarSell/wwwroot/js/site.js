    $('#login_form').submit(function (e) {
        e.preventDefault();
        var emailLog = $('#Email').val();
        var password = $('#Password').val();

        $(".error").remove();

        if (emailLog.length < 3) {
            $('#Email').after('<span class="error">This field is required</span>');
        } else {
            var regEx = ($('#Email').val().match(/.+?\@.+/g) || []).length === 1;
            var validEmail = regEx.test(emailLog);
            if (!validEmail) {
                $('#Email').after('<span class="error">Enter a valid email</span>');
            }
        }
        if (password.length < 8) {
            $('#Password').after('<span class="error">Password must be atleast 8 characterslong</span>');
        }

    });

    $('#register_form').submit(function (e) {
        e.preventDefault();
        var emailUser = $('#Email').val();
        var password = $('#Password').val();
        var UserName = $('#Name').val();
        var Sname = $('#SName').val();

        $(".error").remove();

        if (emailUser.length < 3) {
            $('#Email').after('<span class="error">This field is required</span>');
        } else {
            var regEx = ($('#Email').val().match(/.+?\@.+/g) || []).length === 1;
            var validEmail = regEx.test(emailUser);
            if (!validEmail) {
                $('#Email').after('<span class="error">Enter a valid email</span>');
            }
        }
        if (password.length < 8) {
            $('#Password').after('<span class="error">Password must be atleast 8 characterslong</span>');
        }
        if (UserName.length < 2) {
            $('#Name').after('<span class="error">User`s name must be atleast 2 characterslong</span>');
        }
        if (Sname.length < 3) {
            $('#SName').after('<span class="error">User`s name must be atleast 2 characterslong</span>');
        }
    });


