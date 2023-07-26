$(document).ready(function () {
    $('#multiselectInput').select2({      
        placeholder: 'Select tags',
        minimumInputLength: 1,
        tags: true, // Allow creating new tags
        tokenSeparators: [','],    
        ajax: {
            url: '/TextTags/GetTags', // Controller action to get the matching tags
            dataType: 'json',
            delay: 250,
            processResults: function (data) {
                return {
                    results: data
                };
            },
            cache: true
        }
    });

    var $eventSelect = $('#multiselectInput'); //select your select2 input
    $eventSelect.on('select2:select', function (e) {
        //e.preventDefault();
        // Get the new tag value
        var newTag = e.params.data.text;
        $.ajax({
            url: '/TextTags/CreateTag/?newTextTag=' + newTag,
            type: 'GET',
            success: function (data) {
                // Add the new tag to the Select2 options
                if (!$("#multiselectInput option[value='" + data.id + "']").length > 0) {
                    var option = new Option(data.text, data.id, true, true);
                    $('#multiselectInput').append(option).trigger('change');
                }
            },
            error: function (xhr, status, error) {
                console.error(error);
            }
        });

        $("#multiselectInput option[value='" + newTag + "']").remove().trigger('change');
    })

    $(document).on('keyup', '.select2-search__field', function (e) {
        console.log(e.keyCode);
        if (e.keyCode === 13) {
            // Prevent the default action of pressing "Enter" in the Select2 input
            e.preventDefault();
        }
    });

});

