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
var _control;
function FncExeAjaxSelect(url, tipo, async, control) {
    $.ajax({
        url: url,
        type: tipo,
        async: async,
        success: function (respuesta) {
            $('#' + control).html("");
            $('#' + control).append('<option value="-1">Seleccionar</option>');
            $.each(respuesta.datos, function (index, value) {
                $('#' + control).append('<option value="' + value.id + '">' + value.descripcion + '</option>');
            });
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
function LlenaSelect(url,control) {
    FncExeAjaxSelect(url, "POST", false, control);
}
function RevisaInputValida() {
    var respuesta = false;
    $(".valida").each(function () {
        if (this.type == "text") {
            if ($(this).val() == "") {
                $(this).addClass("invalid");
                $(this).parent().find("span").addClass("textRed");
                $(this).parent().append("<span class=\"helper-text\" data-error=\"Dato requerido\" data-success=\"right\">Dato requerido</span>");
                respuesta = true;
            }
            else {
                $(this).removeClass("invalid");
                $(this).parent().find(".helper-text").remove();
                $(this).parent().find("span").removeClass("textRed");
                if (!respuesta) {
                    respuesta = false;
                }
            }
        }
    });
}