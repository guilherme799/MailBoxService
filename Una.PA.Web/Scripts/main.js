var urlRest = 'http://localhost:49254/api/';

$(function () {
    $.get('Login/Login.htm', function (data) {
        $('body>.container').append(data);
        $('#btnEntrar').on('click', efetuarLogin);
    });
});

var efetuarLogin = function () {
    var usuario = {
        Login: 'administrador',
        Senha: 'password'
    };

    $.post(urlRest.concat('Values'), {'': 'Teste'}, function (data, status, xhr) {
    });
};