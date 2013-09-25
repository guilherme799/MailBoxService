var urlRest = 'http://localhost:62663/api/';

$(function () {
    $.get('Login/Login.htm', function (data) {
        $('.container').append(data);
        $('#btnEntrar').on('click', efetuarLogin);
    });
});

var efetuarLogin = function () {
    $.post((urlRest + 'Values'), { 'value': '123' }, function (data, status, xhr) {
        debugger;
    });
};