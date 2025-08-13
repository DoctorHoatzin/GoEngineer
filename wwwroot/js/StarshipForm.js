$(document).ready(function () {

    $("#addShip").on('click', function () {
        $.get("/Starship/Upsert/0", function (html) {
            $("#modalContent").html(html);
            $("#starshipModal").modal("show");
        });
    });

    $(document).on("click", "#btnEdit", function () {
        var id = $(this).closest('tr').data("starship-id");
        $.get("/Starship/Upsert/" + id, function (html) {
            $("#modalContent").html(html);
            $("#starshipModal").modal("show");
        });
    });

    $(document).on("submit", "#starshipForm", function (e) {
        e.preventDefault();

        var form = $(this);

        $.ajax({
            url: form.attr("action"),
            type: "POST",
            data: form.serialize(),
            success: function (res) {
                $("#starshipModal").modal("hide");

                location.reload();
            },
            error: function (xhr) {
                $("#modalContent").html(xhr.responseText);
            }
        });
    });

    $(document).on("click", "#btnDelete", function () {
        if (!confirm("Are you sure you want to delete this starship?")) return;

        var id = $(this).closest('tr').data("starship-id");

        $.ajax({
            url: "/Starship/Delete/" + id,
            type: "DELETE",
            success: function () {
                location.reload();
            },
            error: function () {
                alert("Failed to delete the starship.");
            }
        });
    });

});
