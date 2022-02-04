
$(function () {
    var placeholderElement = $('#modal-placeholder');
  
    $('button[data-toggle="ajax-modal"]').click(function (event) {
        var url = $(this).data('url');
        $.get(url).done(function (data) {
            placeholderElement.html(data);
            placeholderElement.find('.modal').modal('show');
        });
    });

    placeholderElement.on('click', '[data-save="modal"]', function (event) {
        event.preventDefault();
      
        var form = $(this).parents('.modal').find('form');
        var actionUrl = form.attr('action');
        var dataToSend = form.serialize();

        $.post(actionUrl, dataToSend).done(function (data) {
            // data is the rendered _ContactModalPartial
            var newBody = $('.modal-body', data);
            // replace modal contents with new form
            placeholderElement.find('.modal-body').replaceWith(newBody);
            var isValid = newBody.find('[name="IsValid"]').val() == 'True';
            if (isValid) {
                placeholderElement.find('.modal').modal('hide');
            }
            location.reload(true);
        });
    });
});
$(function () {
    // Summernote
    $('#summernote').summernote()
    debugger
    document.addEventListener("DOMContentLoaded", function () {
        var calendarEl = document.getElementById("calendar");
        var calendar = new FullCalendar.Calendar(calendarEl, {
            initialVeiw: 'dayGridMonth',
            locale: 'pt',

            headerToolbar: {
                left: 'prev, next today',
                center: 'title',
                right: 'dayGridMonth,timeGridWeek,timeGridDay'
            },
            editable: true,
            selectable: true,
            events: function (fetchInfo, successCallback, failureCallback) {
                debugger
                jQuery.ajax({
                    url: "Index?handler=Calendario",
                    type: "GET",
                    //contentType: "application/json; charset=utf-8",
                    success: function (res) {
                        var events = [];

                        res.forEach(function (data) {
                            events.push({
                                title: data.evento,
                                description: data.descricaevento,
                                start: moment(data.dataMarcada).format('YYYY-MM-DD'),
                                end: moment(data.datatermino).format('YYYY-MM-DD'),
                                backgroundColor: "#9501fc",
                                borderColor: "#fc0101"
                            });
                        });
                        successCallback(events);
                    },
                });
            },

            eventClick: function (info, jsEvent, view) {


                $('#modalTitle').html(info.event.title);
                $('#modalBody').html(info.event.extendedProps.description);
                $('#eventUrl').attr('href', info.event.url);
                $('#calendarModal').modal();

            },
            eventRender: function (event, element) {
                debugger
                element.qtip(
                    {

                        content: event.descricaevento
                    });
            },

            editable: false
        });
        calendar.render();
    });


    //// CodeMirror
    //CodeMirror.fromTextArea(document.getElementById("codeMirrorDemo"), {
    //    mode: "htmlmixed",
    //    theme: "monokai"
    //});
});

function confirmDelete(uniqueId, isDeleteClicked) {
    var deleteSpan = 'deleteSpan_' + uniqueId;
    var confirmDeleteSpan = 'confirmDeleteSpan_' + uniqueId;

    if (isDeleteClicked) {
        $('#' + deleteSpan).hide();
        $('#' + confirmDeleteSpan).show();
    } else {
        $('#' + deleteSpan).show();
        $('#' + confirmDeleteSpan).hide();
    }
}
$(document).ready(function () {
    $(".statesSelect").select2();
});



$(function () {
    $("#example1").DataTable({
        "responsive": true, "lengthChange": true, "autoWidth": false,
        "language": {
            "decimal": "",
            "emptyTable": "No data available in table",
            "info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "infoEmpty": "Showing 0 to 0 of 0 entries",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Show _MENU_ entries",
            "loadingRecords": "Loading...",
            "processing": "Processing...",
            "search": "Search:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "First",
                "last": "Last",
                "next": "Next",
                "previous": "Previous"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        }
    })

    $("#txtBuscar").autocomplete({

        source: function (request, response) {
            debugger
            $.ajax({
                url: 'Index?handler=AutoComplete',
                beforeSend: function (xhr) {
                    xhr.setRequestHeader("XSRF-TOKEN",
                        $('input:hidden[name="__RequestVerificationToken"]').val());
                },
                data: { "prefix": request.term },
                type: "POST",
                success: function (data) {
                    response($.map(data, function (item) {
                        return item;
                    }))
                },
                error: function (response) {
                    alert(response.responseText);
                },
                failure: function (response) {
                    alert(response.responseText);
                }
            });
        },
        select: function (e, i) {
            $("#procesiID").val(i.item.val);

        },
        minLength: 1
    });

  

});

    $('#example2').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
    });

    $('table.display').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        "language": {
            "decimal": "",
            "emptyTable": "Nenhuma actividade encontrada",
            "info": "Showing _START_ to _END_ of _TOTAL_ entries",
            "infoEmpty": "Mostrando 0 a 0 dos 0 existentes",
            "infoFiltered": "(filtered from _MAX_ total entries)",
            "infoPostFix": "",
            "thousands": ",",
            "lengthMenu": "Show _MENU_ entries",
            "loadingRecords": "Loading...",
            "processing": "Processing...",
            "search": "Procurar:",
            "zeroRecords": "No matching records found",
            "paginate": {
                "first": "Inicio",
                "last": "Fim",
                "next": "Proximo",
                "previous": "Anterior"
            },
            "aria": {
                "sortAscending": ": activate to sort column ascending",
                "sortDescending": ": activate to sort column descending"
            }
        }
    });


    $('#example3').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
        'language': 'pt',
    });


  $(function () {
  

   }
    );


  //  $(document).ready(function () {

    //        events: function (start, end, timezone, callback) {
    //            $.ajax({
    //                url: '/calendario?handler=EncontreTodosEventos',
    //                type: "GET",
    //                dataType: "JSON",

    //                success: function (result) {
    //                    var events = [];

    //                    $.each(result, function (i, data) {
    //                        events.push(
    //                            {
    //                                title: data.Title,
    //                                description: data.Desc,
    //                                start: moment(data.Start_Date).format('YYYY-MM-DD'),
    //                                end: moment(data.End_Date).format('YYYY-MM-DD'),
    //                                backgroundColor: "#9501fc",
    //                                borderColor: "#fc0101"
    //                            });
    //                    });

    //                    callback(events);
    //                }
    //            });
    //        },
           
    //        eventRender: function (event, element) {
    //            element.qtip(
    //                {
    //                    content: event.description
    //                });
    //        },

    //        editable: false
    //    });
  //  });
