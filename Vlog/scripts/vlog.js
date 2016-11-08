$('#signin').click(function () {
    $('#waiting').css('display', 'block');
    $('#signin').attr("disabled", true);
    $.post('/User/LoginSubmit',
         { name: $('#name').val(), password: $('#password').val() },
        function (data) {
            if (data.flag) {
                window.location.href = '/Article/User';
            } else {
                $('#waiting').css('display', 'none');
                $('#signin').attr("disabled", false);
                $('#warnning').text(data.reason);
                $('#warnning').css('display', 'block');
            }
        });
});

$('#signUp')
    .click(function () {
        $('#signUpWaiting').css('display', 'block');
        $('#signUp').attr("disabled", true);
        $.post('/User/SignUpSubmit',
            {
                name: $('#signUpName').val(),
                password: $('#signUpPassword').val(),
                sex: $('input[type="radio"][name="sex"]:checked').val()
            },
            function (data) {
                if (data.flag) {
                    window.location.href = '/Home/Index';
                } else {
                    $('#signUpWaiting').css('display', 'none');
                    $('#signUp').attr("disabled", false);
                    $('#signUpWarnning').text(data.reason);
                    $('#signUpWarnning').css('display', 'block');
                }
            });
    });