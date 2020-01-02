var _titulo = "Vivienda Feliz";
function FncExeAjax(url, model, tipo, async, fncCorrecto) {
    $.ajax({
        url: url,
        type: tipo,
        data: model,
        async: async,
        success: function (respuesta) {
            fncCorrecto(respuesta);
        },
        error: function () {
            MsnSwal("error", "Error en el servidor, favor de contactar a su proveedor", _titulo);
        }
    });
}
function FncExeAjaxSinModelo(url, tipo, async, fncCorrecto) {
    $.ajax({
        url: url,
        type: tipo,
        async: async,
        success: function (respuesta) {
            fncCorrecto(respuesta);
        },
        error: function () {
            MsnSwal("error", "Error en el servidor, favor de contactar a su proveedor", _titulo);
        }
    });
}
function MsnShow(respuesta) {
    
    var mensaje = "";
    var tipo = "";
    if (respuesta.ejecucion) {
        tipo = "success";
    }
    else {
        tipo = "error";
    }
    $.each(respuesta.mensaje, function (index, elemento) {
        mensaje += elemento + "<br />";
    });
    MsnSwal(tipo, mensaje, _titulo);

}
function MsnSwal(tipo, mensaje, titulo) {
    Swal.fire({
        type: tipo,
        title: titulo,
        text: mensaje
    });
}
function Tabla() {
    $('.table').DataTable();
}