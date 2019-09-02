// What happens when you lock your card.
$("input[name='lock']").click(function (e) {
    e.preventDefault();
    e.stopPropagation();
    var checkbox = $(this);
    var isChecked = checkbox.prop("checked");
    var parent = checkbox.parents("form");
    var cardId = parent.data("cardid");
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