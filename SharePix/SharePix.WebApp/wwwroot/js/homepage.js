$(document).ready(function () {
    $('#photos, #albums').click(function () {
        let toShow = [];
        if ($('#photos').is(':checked')) {
            toShow.push(".photo");
        }
        if ($('#albums').is(':checked')) {
            toShow.push(".album");
        }
        if (toShow.length > 0)
            $('.portfolio_isotope_container').isotope({ filter: toShow.join() });
        else
            $('.portfolio_isotope_container').isotope({ filter: '.none' });
    });
});


setTimeout(function () {
    $("#successAlert").alert("close");
}, 6000);


lightbox.option({
    'resizeDuration': 200,
    'wrapAround': true,
    'alwaysShowNavOnTouchDevices': true,
    'showImageNumberLabel': true,
    'disableScrolling': true,
})


