$(function () {
    // showing property type according to selected on initial
    ShowingPropertyTypeAccordingToSelected();

    // showing deal type according to selected on initial
    ShowingDealTypeAccordingToSelected();

    //hide unnecessary type sections on initial
    $('input.property-subtype').each(function (index, element) {
        if (!$(element).is(':checked')) {
            $(`.type-section[data-id="${element.id}"]`).hide();
        }
    })

    // clearing of fields & showing only checked type properties
    $(document).on('change', 'input.property-subtype', function () {
        if (this.checked) {
            ClearingOfFields();
            ShowingCheckedTypeProperties();
        }
    })

    // showing property type according to selected
    $(document).on('change', '#property-type', function () {
        var selected = $(this).find("option:selected").text();

        if (selected == 'Building') {
            $('.announcement-building-type:first-child .property-subtype').prop('checked', true);

            ClearingOfFields();
            ShowingCheckedTypeProperties();

            $('#building-types').show();
            $('#object-types').hide();
        }
        else if (selected == 'Object') {
            $('.announcement-object-type:first-child .property-subtype').prop('checked', true);

            ClearingOfFields();
            ShowingCheckedTypeProperties();

            $('#object-types').show();
            $('#building-types').hide();
        }
    })


    // showing deal types according to selected
    $(document).on('change', '#deal-type', function () {

        var selected = $(this).find("option:selected").text();

        if (selected == 'Sale') {
            $('.announcement-sale-type:first-child .deal-subtype').prop('checked', true);

            $('#sale-types').show();
            $('#rent-types').hide();

            $('.sale-cost').show();
            $('.rent-cost').hide();
            $('.rent-cost input').val('');
        }
        else if (selected == 'Rent') {
            $('.announcement-rent-type:first-child .deal-subtype').prop('checked', true);

            $('#rent-types').show();
            $('#sale-types').hide();

            $('.rent-cost').show();
            $('.sale-cost').hide();
            $('.sale-cost input').val('');
        }
    })

    // adding of new contact number
    $(document).on('click', '.add-contact-number', function () {
        var count = $(this).data('count');

        var contactNumber = `<div class="col-12 contact-number">
                                <div class="mb-3">
                                    <div class="d-flex align-items-center">
                                        <input class="form-control" id='AnnouncementContact_AnnouncementContactNumbers_${count + 1}__PhoneNumber' name="AnnouncementContact.AnnouncementContactNumbers[${count + 1}].PhoneNumber">
                                        <i data-count="${count + 1}" class="add-contact-number fas fa-plus mx-3"></i>
                                    </div>
                                </div>
                            </div>`

        $('#contact-numbers').append(contactNumber);
        $(this).remove();
    })

    // adding user email to email field
    $(document).on('change', '#user-select', function () {
        var email = $(this).find("option:selected").text();
        $('#Email').val(email);
    })

    // functions
    // clearing of fields
    function ClearingOfFields() {
        $('.type-section').hide();
        $('.type-section input,.type-section select').val('');
    }

    // showing only checked type properties
    function ShowingCheckedTypeProperties() {
        $('input.property-subtype').each(function () {
            if (this.checked) {
                $('.type-section').hide();
                $(`.type-section[data-id="${this.id}"]`).show();
            }
        })
    }

    // showing property type according to selected on initial
    function ShowingPropertyTypeAccordingToSelected() {
        var selected = $('#property-type').find("option:selected").text();

        if (selected == 'Building') {

            $('#building-types').show();
            $('#object-types').hide();
        }
        else if (selected == 'Object') {

            $('#object-types').show();
            $('#building-types').hide();
        }
    }

    // showing property type according to selected on initial
    function ShowingDealTypeAccordingToSelected() {
        var selected = $('#deal-type').find("option:selected").text();

        if (selected == 'Sale') {

            $('#sale-types').show();
            $('#rent-types').hide();

            $('.sale-cost').show();
            $('.rent-cost').hide();

        }
        else if (selected == 'Rent') {

            $('#rent-types').show();
            $('#sale-types').hide();

            $('.rent-cost').show();
            $('.sale-cost').hide();

        }
    }

    //#region PhotoDropzone

    var row = 0;
    $('#photo-dropzone').dropzone({
        paramName: GetParamNameForPhotoDropzone,
        uploadMultiple: true,
        maxFiles: 10,
        maxFilesize: 5, //MB
        addRemoveLinks: true,
        acceptedFiles: ".png,.jpg,.gif,.bmp,.jpeg, .svg, .heic",
        init: function () {
            var dropzone = this;
            AddExistingPhotosToDrozpone(dropzone);

            this.on("successmultiple", function (files, response) {

                console.log(response);

                AddFilesNamesToPreviewElements(files, response);
                GenerateHiddenInputForPhotosByResponse(response);
            });

            this.on("removedfile", function (file) {
                SendAjaxRequestForDeletePhoto(file);
            });
        }
    });

    function GetParamNameForPhotoDropzone() {
        return "model.Photos";
    }

    function GenerateHiddenInputForPhotosByResponse(response) {
        $(response).each(function (index, element) {
            var input = `<input type='hidden' class='photo-name' name='PhotosNames[${row}]' value='${element}'/>`
            $('#PhotoNames').append(input);
            row++;
        })
    }

    function SendAjaxRequestForDeletePhoto(file) {
        var name = $(file.previewElement).attr('name');

        var data = {
            name: name
        }

        $.ajax({
            type: "POST",
            data: data,
            url: `/admin/announcement/deletephoto`,
            success: function () {
                $(`.photo-name[value='${name}']`).val('');
            },
            error: function () {
                alert("Image can't removed. Please try again!")
            }
        });
    }

    function AddExistingPhotosToDrozpone(dropzone) {
        if ($('#Id')) {
            var announcementId = $('#Id').val();

            var row = 0;
            $.post(`/admin/announcement/${announcementId}/getallphotosbyannouncementid`).done(function (data) {
                $.each(data, function (index, item) {
                    //// Create the file:
                    var file = {
                        name: item.displayName,
                        size: item.size,
                        path: item.path
                    };

                    // Call the default addedfile event handler
                    dropzone.emit("addedfile", file);

                    // And optionally show the thumbnail of the file:
                    dropzone.emit("thumbnail", file, file.path);

                    // to mark existing photos as completed
                    $('#photo-section .dz-preview').addClass('dz-complete');

                    // add name attr to dz-preview for identity
                    $($('#photo-section .dz-preview')[row]).attr('name', item.name)
                    row++;

                    var existingFileCount = data.length; // The number of files already uploaded
                    dropzone.options.maxFiles = dropzone.options.maxFiles - existingFileCount;
                });
            });
        }
    }

    //#region VideoDropzone

    var row = 0;
    $('#video-dropzone').dropzone({
        paramName: GetParamNameForVideoDropzone,
        uploadMultiple: true,
        maxFiles: 3,
        maxFilesize: 20, //MB
        addRemoveLinks: true,
        acceptedFiles: "video/mp4,video/x-m4v,video/*",
        init: function () {
            var dropzone = this;
            AddExistingVideosToDrozpone(dropzone);

            this.on("successmultiple", function (files, response) {
                AddFilesNamesToPreviewElements(files, response);
                GenerateHiddenInputForVideosByResponse(response);
            });

            this.on("removedfile", function (file) {
                SendAjaxRequestForDeleteVideo(file);
            });

        }
    });

    function GetParamNameForVideoDropzone() {
        return "model.Videos";
    }

    function GenerateHiddenInputForVideosByResponse(response) {
        $(response).each(function (index, element) {
            var input = `<input type='hidden' class='video-name' name='VideoNames[${row}]' value='${element}'/>`
            $('#VideoNames').append(input);
            row++;
        })
    }

    function SendAjaxRequestForDeleteVideo(file) {
        var name = $(file.previewElement).attr('name');

        var data = {
            name: name
        }

        $.ajax({
            type: "POST",
            data: data,
            url: `/admin/announcement/deletevideo`,
            success: function () {
                $(`.video-name[value='${name}']`).val('');
            },
            error: function () {
                alert("Video can't removed. Please try again!")
            }
        });
    }

    function AddExistingVideosToDrozpone(dropzone) {
        if ($('#Id')) {
            var announcementId = $('#Id').val();

            var row = 0;
            $.post(`/admin/announcement/${announcementId}/getallvideosbyannouncementid`).done(function (data) {
                $.each(data, function (index, item) {
                    //// Create the file:
                    var file = {
                        name: item.name,
                        size: item.size,
                        path: item.path
                    };

                    // Call the default addedfile event handler
                    dropzone.emit("addedfile", file);

                    // And optionally show the thumbnail of the file:
                    dropzone.emit("thumbnail", file, file.path);

                    // to mark existing photos as completed
                    $('#video-section .dz-preview').addClass('dz-complete');

                    // add name attr to dz-preview for identity
                    $($('#video-section .dz-preview')[row]).attr('name', file.name)
                    row++;

                    var existingFileCount = data.length; // The number of files already uploaded
                    dropzone.options.maxFiles = dropzone.options.maxFiles - existingFileCount;
                });
            });
        }
    }

    //#region Dropzone

    function AddFilesNamesToPreviewElements(files, response) {
        for (var i = 0; i < files.length; i++) {
            $(files[i].previewElement).attr('name', response[i])
        }
    }
})

// prevent to automatically configurate dropzone 
Dropzone.autoDiscover = false;
