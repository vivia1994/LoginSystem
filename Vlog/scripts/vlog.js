$('#signin').click(function () {
    $('#waiting').css('display', 'block');
    $('#signin').attr("disabled", true);
    $.post('/User/LoginSubmit',
         { name: $('#name').val(), password: $('#password').val() },
        function (data) {
            if(data.flag) {
                window.location.href = '/Article/User';
            } else {
                $('#waiting').css('display', 'none');
                $('#signin').attr("disabled", false);
                $('#warnning').text(data.reason);
                $('#warnning').css('display', 'block');
            }
        });
});