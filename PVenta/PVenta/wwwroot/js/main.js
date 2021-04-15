// :::::::::::::::::::::: VARIABLES GLOBALES ::::::::::::::::::::::


// :::::::::::::::::::::: CONTROLLERS OBJETOS DOM ::::::::::::::::::::::

$(document).on('click', '.cerrarSesion', function () {
    $.ajax({
        type: "POST",
        contentType: "application/x-www-form-urlencoded",
        url: "/Login/CerrarSesion",
        dataType: 'JSON',

        beforeSend: function () {
            isBusy(true);
        },
        success: function (data) {
            console.log(data);
            if (data) {

                location.reload();
            }
            else {
                isBusy(false);
                notification("Notificacion", "Ocurrio un problema al cerrar session", 3);
            }
        },
        error: function (error) {
            console.log(error);
            isBusy(false);
        }
    });
});

// :::::::::::::::::::::: FUNCIONES GENERALES ::::::::::::::::::::::


