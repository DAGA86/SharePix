$('#password, #confirmPassword').on('keyup', function () {
    if ($('#password').val() == $('#confirmPassword').val()) {
        $('#message').html('&#x2713').css('color', 'green'),
        $('#mess').html('&#x2713').css('color', 'green');
    } else
        $('#message').html('&#x274C').css('color', 'red'),
        $('#mess').html('&#x274C').css('color', 'red');
});
