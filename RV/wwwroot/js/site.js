// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$(".close-alert").delay(5000).slideUp(200, function () {
    $(this).alert('close');
});

$("#moeda").change(function (e) {
    $("#moeda").val($("#moeda").val().replace('.',','));
});