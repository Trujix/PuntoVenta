
// :::::::::::::::::::::: VARIABLES GLOBALES ::::::::::::::::::::::

// :::::::::::::::::::::: FUNCIONES GENERALES ::::::::::::::::::::::

// FUNCION QUE MUESTRA EL MENSAJE DE 'CARGANDO'
function isBusy(activar, texto = null) {
    $('#loadingDiv').remove();
    if (activar) {
        var dataText = (texto !== null) ? texto : "Espere...";
        $('body').append('<div id="loadingDiv" class="loader loader-curtain is-active" data-text="' + dataText + '" blink></div>');
    }
}

// FUNCION QUE MUESTRA MENSAJES MULTIUSUARIO [ VACIO: INFO, 1: EXITO, 2: ADVERTENCIA, 3: ERROR ]
function notification(titulo, mensaje, tipo = 0) {
    var tipoMsg = "info";
    if (tipo === 1) {
        tipoMsg = "success";
    } else if (tipo === 2) {
        tipoMsg = "warning";
    } else if (tipo === 3) {
        tipoMsg = "error";
    }
    swal(titulo, mensaje, tipoMsg);
}

// FUNCION QUE MUESTRA MENSAJES SENCILLOS POP UP
// FUNCION GLOBAL QUE MANDA LLAMAR EL MENSAJE
function msgPop(titulo, cuerpo, tiempo, tipo) {
    PNotify.removeAll();
    new PNotify({
        title: titulo,
        text: cuerpo,
        delay: tiempo,
        type: tipo
    });
}

// FUNCION DE MENSAJE DE PREGUNTA
function msgAsk(titulo, contenido, callback) {
    var colores = ['orange', 'blue', 'purple', 'red', 'green'];
    var color = colores[Math.floor((Math.random() * 4) + 1)];
    $.confirm({
        title: titulo,
        content: contenido,
        type: color,
        theme: 'dark',
        buttons: {
            Aceptar: {
                text: 'Aceptar',
                action: function () {
                    callback(true);
                }
            },
            Cancelar: {
                text: 'Cancelar',
                action: function () {
                    callback(false);
                }
            }
        }
    });
}