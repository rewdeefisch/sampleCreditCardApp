// What happens when you lock your card.
$("input[name='lock']").click(function (e) {
    var parent = $(this).parents("form");
    var cardId = parent.data("cardid");
    console.log(cardId);

    $.post(window.location.origin + "/lock", {
        cardId: cardId
    }).done(function (response) {
        alert(response.statusText);
    }).fail(function (error) {
        alert(error.statusText);
    });
});
