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
        console.log("Is Checked After Reverrt: " + isChecked);
    });
});

// Event handler for selecting problem
$(".dropdown-item[name='problem']").click(function (e) {
    var currentOption = $(this);
    console.log(currentOption.text());

    $(".modal-card-problem").text(currentOption.text().toLowerCase());

    $('#problemModal').modal();
});

