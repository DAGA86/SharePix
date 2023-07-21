$(document).ready(function () {
    $('#multiselectInput').select2({
        //    ajax: {
        //        url: '/TextTags/GetTags',
        //        dataType: 'json',
        //        delay: 250,
        //        data: function (params) {
        //            return {
        //                searchTerm: params.term
        //            };
        //        },
        //        processResults: function (data) {
        //            return {
        //                results: data
        //            };
        //        },
        //        cache: true
        //    },
        //    placeholder: 'Select tags',
        //    minimumInputLength: 1,
        //    tags: true // Allow the user to add new tags
        //});

        //// Handle the "Create Tag" button click
        //$('#createTagBtn').click(function () {
        //    var newTag = $('#newTagInput').val().trim();
        //    if (newTag === '') {
        //        alert('Please enter a tag description.');
        //        return;
        //    }

        //    // Send the new tag description to the server using AJAX
        //    $.ajax({
        //        type: 'POST',
        //        url: '/TextTags/CreateTag',
        //        data: { tagDescription: newTag },
        //        success: function (tagId) {
        //            // Add the newly created tag to the Select2 dropdown
        //            var newOption = new Option(newTag, tagId, true, true);
        //            $('#multiselectInput').append(newOption).trigger('change');

        //            // Clear the new tag input field
        //            $('#newTagInput').val('');
        //        },
        //        error: function (error) {
        //            alert('Error creating the tag: ' + error.responseText);
        //        }
        //    });
        //});



        placeholder: 'Select tags',
        minimumInputLength: 1,
        tags: true, // Allow creating new tags
        tokenSeparators: [','],
        createTag: function (params) {
            // Don't create a new tag if the input is empty or already exists
            if ($.trim(params.term) === '' || $('#multiselectInput').find("option[value='" + params.term + "']").length) {
                return null;
            }
            return {
                id: params.term,
                text: params.term
            };
        },
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



    // Event handler for "Enter" key press in the multiselect input
    $(document).on('keyup', '.select2-search__field', function (e) {
        console.log(e.keyCode);
        if (e.keyCode === 13) {
            // Prevent the default action of pressing "Enter" in the Select2 input
            e.preventDefault();
            // Get the new tag value
            var newTag = $(this).val();
            // Create the new tag via AJAX call
            $.ajax({
                url: '/TextTags/CreateTag',
                type: 'POST',
                data: { tagText: newTag },
                success: function (data) {
                    // Add the new tag to the Select2 options
                    var option = new Option(data.text, data.id, true, true);
                    $('#multiselectInput').append(option).trigger('change');
                },
                error: function (xhr, status, error) {
                    console.error(error);
                }
            });
        }
    });
});

