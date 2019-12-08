$("#loadform").click(function () {
    $("#form-container").html('');
    $.get({
        url: "https://localhost:44397/person/get-dynamic-form",
        dataType: "html",
        error: function (jqXHR, textStatus, errorThrown) {
            alert(textStatus + ": Couldn't add form. " + errorThrown);
        },
        success: function (newFormHTML) {
            var container = document.getElementById("form-container");
            container.insertAdjacentHTML("beforeend", newFormHTML);
            var forms = container.getElementsByTagName("form");
            var newForm = forms[forms.length - 1];
            $.validator.unobtrusive.parse(newForm);
        }
    })
})