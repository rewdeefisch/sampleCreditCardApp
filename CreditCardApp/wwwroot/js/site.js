// Event handler for locking card
$("input[name='lock']").click(function (e) {
    var checkbox = $(this);
    var isChecked = checkbox.prop("checked");
    var form = checkbox.parents("form");
    var cardId = form.data("cardid");
    var currentStatus = form.data("status");
    console.log("Is Checked After Click: " + isChecked);

    $.post(window.location.origin + "/api/lock", {
        cardId: cardId,
        cardStatus: currentStatus
    }).done(function (response) {
        if(response.message == "okay"){
            checkbox.parents(".card").attr("data-status", response.status);
            form.data("status", response.status);
            checkbox.parents(".card").find("span.card-status").text(response.status);
            swal("Success", "Your card has been " + (response.status == "Locked" ? response.status : "Unlocked") , "success");
        }
        else{
            swal("Error", "Something went wrong", "error");
        }
    }).fail(function (error) {
        checkbox.prop("checked", !isChecked);
        swal("Error", "Something went wrong " + error, "error");
    });
});

// Event handler for selecting problem
$(".dropdown-item[name='problem']").click(function (e) {
    var cardId = $(this).parents("form").data("cardid");
    console.log($(this).text());

    $(".modal-card-problem").text($(this).text().toLowerCase());
    $("#problemModal input[name='cardStatus']").val($(this).text().toLowerCase());

    $("#problemModal input[name='cardId']").val(cardId);
    console.log($("#problemModal input[name='cardId']").val());
    $('#problemModal').modal();
});

// Event handler for submitting modal problem form
$("#modal-submit").click(function (e) {
    var form = $(this).parents("form");
    var cardId = form.find("input[name='cardId']").val();
    var card = $(".card[data-cardid='" + cardId + "']");
    e.preventDefault();

    console.log(form.find("textarea").val());

    $.post(window.location.origin + "/api/problem", {
        cardId: cardId,
        cardStatus: form.find("input[name='cardStatus']").val(),
        comments: form.find("textarea").val()
    }).done(function (response) {
        if(response.message == "okay"){
            card.attr("data-status", response.status);
            form.data("status", response.status);
            card.find("span.card-status").text(response.status);
            card.find("input[type='checkbox']").prop("checked", true);
            swal("Success", "Your card has been reported as " + response.status.toLowerCase() + ".\nWe are investigating this issue and will back to you in 2 business days. ", "success").then((value) => {
                $('#problemModal').modal("hide");
              });;
        }
        else{
            swal("Error", "Something went wrong", "error");
        }
    }).fail(function (error) {
        checkbox.prop("checked", !isChecked);
        swal("Error", "Something went wrong " + error, "error");
    });
});