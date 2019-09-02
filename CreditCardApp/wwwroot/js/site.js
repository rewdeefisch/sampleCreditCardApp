// Event handler for locking card
$("input[name='lock']").click(function (e) {
    e.preventDefault();
    e.stopPropagation();
    var checkbox = $(this);
    var isChecked = checkbox.prop("checked");
    var form = checkbox.parents("form");
    var cardId = form.data("cardid");
    console.log("Is Checked After Click: " + isChecked);

    $.post(window.location.origin + "/lock", {
        cardId: cardId
    }).done(function (response) {
        checkbox.prop("checked", !isChecked);
        alert(response.statusText);
    }).fail(function (error) {
        isChecked = checkbox.prop("checked");
        console.log("Is Checked After Fail: " + isChecked);
    });
});

// Event handler for selecting problem
$(".dropdown-item[name='problem']").click(function (e) {
    var cardId = $(this).parents("form").data("cardid");
    console.log($(this).text());

    $(".modal-card-problem").text($(this).text().toLowerCase());

    $("#problemModal input[name='cardId']").val(cardId);
    console.log($("#problemModal input[name='cardId']").val());
    $('#problemModal').modal();
});

// Event handler for submitting modal problem form
$("#modal-submit").click(function (e) {
    var form = $(this).parents("form");
    e.preventDefault();

    console.log(form.find("textarea").val());

    $.post(window.location.origin + "/problem", {
        cardId: form.find("input[name='cardId']").val(),
        comments: form.find("textarea").val()
    }).done(function (response) {
        alert(response.statusText);
    }).fail(function (error) {
        alert(error.statusText);
    });
});