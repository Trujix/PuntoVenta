
// :::::::::::::::::::::: VARIABLES GLOBALES ::::::::::::::::::::::
var loginJSON = {
    Usuario: null,
    Password: null,
    ClaveTienda: null,
};

// :::::::::::::::::::::: CONTROLLERS OBJETOS DOM ::::::::::::::::::::::

// DOCUMENT - BOTON QUE GENERA LA FUNCION DE LOGIN
$(document).on('click', '#btn-login', function (e) {
    if (validateLoginForm()) {
        $.ajax({
            type: "POST",
            contentType: "application/x-www-form-urlencoded",
            url: "/Login/IniciarSesion",
            dataType: 'JSON',
            data: { login: loginJSON },
            beforeSend: function () {
                isBusy(true);
            },
            success: function (data) {
                console.log(data);
                isBusy(false);
            },
            error: function (error) {
                console.log(error);
                isBusy(false);
            }
        });
    }
});

// :::::::::::::::::::::: FUNCIONES GENERALES ::::::::::::::::::::::
// FUNCION DE ARRANQUE
$(function () {
    setTimeout(function () {
        $('.input100').val('');
    }, 1000);
});

// FUNCION QUE VALIDA EL FORMULARIO DE LOGIN
function validateLoginForm() {
    var correcto = false, msg = "";
    if ($('#user-login').val() === "") {
        msg = "Coloque el Usuario";
        $('#user-login').focus();
    } else if ($('#password-login').val() === "") {
        msg = "Coloque la Contraseña";
        $('#password-login').focus();
    } else {
        correcto = true;
        loginJSON.Usuario = $('#user-login').val();
        loginJSON.Password = $('#password-login').val();
    }
    if (!correcto) {
        msgPop("Atención", msg, 2500, "warning");
    }
    return correcto;
}

// FUNCION QUE EJECUTA LOS VALIDADORES
(function ($) {
    "use strict";
    var input = $('.validate-input .input100');
    $('.validate-form').on('submit', function () {
        var check = true;

        for (var i = 0; i < input.length; i++) {
            if (validate(input[i]) == false) {
                showValidate(input[i]);
                check = false;
            }
        }
        return check;
    });
    $('.validate-form .input100').each(function () {
        $(this).focus(function () {
            hideValidate(this);
        });
    });
    function validate(input) {
        if ($(input).attr('type') == 'email' || $(input).attr('name') == 'email') {
            if ($(input).val().trim().match(/^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{1,5}|[0-9]{1,3})(\]?)$/) == null) {
                return false;
            }
        }
        else {
            if ($(input).val().trim() == '') {
                return false;
            }
        }
    }
    function showValidate(input) {
        var thisAlert = $(input).parent();

        $(thisAlert).addClass('alert-validate');
    }
    function hideValidate(input) {
        var thisAlert = $(input).parent();
        $(thisAlert).removeClass('alert-validate');
    }
})(jQuery);