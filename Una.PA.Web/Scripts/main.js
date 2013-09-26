var urlRest = 'http://localhost:49254/api/';
var tipoAlert = {
    DANGER: 'danger',
    WARNING: 'warning',
    INFO: 'info',
    SUCCES: 'succes'
};


$(function () {
    $.get('Login/Login.htm', function (data) {
        $('body>.container').append(data);
        $('#btnEntrar').on('click', efetuarLogin);
    });
});

var efetuarLogin = function () {
    var usuario = {
        Login: $('#txtUsuario').val(),
        Senha: $('#txtSenha').val()
    };

    $('#alert').html('');
    $.ajax({
        type: 'POST',
        url: urlRest.concat('Usuario/LogarUsuario'),
        data: usuario,
        statusCode: {
            302: function (xhr, textStatus, status) {
                $('#alert').html('');
            },
            404: function (xhr, textStatus, status) {
                $('#tmpl-alert').tmpl({
                    tipo: tipoAlert.DANGER,
                    mensagem: xhr.responseJSON.Message
                }).appendTo('#alert');
            }
        }
    });
};