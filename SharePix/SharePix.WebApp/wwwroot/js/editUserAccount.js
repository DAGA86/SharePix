$('#password, #confirmPassword').on('keyup', function () {
    if ($('#password').val() == $('#confirmPassword').val()) {
        $('#message').html('&#x2713').css('color', 'green'),
        $('#mess').html('&#x2713').css('color', 'green');
    } else
        $('#message').html('&#x274C').css('color', 'red'),
        $('#mess').html('&#x274C').css('color', 'red');
});

$(document).ready(function () {
    $('#uploadButton').click(function () {
        $('#photoInput').click();
    });

    $('#photoInput').change(function () {
        var file = this.files[0];
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#previewImage').attr('src', e.target.result);
            $('#previewContainer').show();
        };

        reader.readAsDataURL(file);
    });
});
