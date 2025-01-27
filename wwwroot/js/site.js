﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('ul#users-list').on('click', 'li', function () {
        var username = $("input[type=hidden].username", $(this)).val();
        var input = $('#chat-message');

        var text = input.val();
        if (text.startsWith("/")) {
            text = text.split(")")[1];
        }

        text = "/private(" + username + ") " + text.trim();
        input.val(text);
        input.change();
        input.focus();
    });

    $('#emojis-container').on('click', 'a', function () {
        var value = $("input", $(this)).val();
        var input = $('#chat-message');
        input.val(input.val() + value); // cộng giá trị
        input.focus();
        input.change(); // cộng xong cập nhật luôn thẻ input đó
    });

    $("#emojibtn").click(function () {
        $("#emojis-container").toggleClass("d-none");
    });

    $("#chat-message, #btn-send-message").click(function () {
        $("#emojis-container").addClass("d-none")
    });

    $('.modal').on('hidden.bs.modal', function () {
        $(".modal-body input:not(#newRoomName)").val("");
    });

    $(".alert .close").on('click', function () {
        $(this).parent().hide();
    });
});