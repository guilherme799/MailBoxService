var urlRest = 'http://localhost:49254/api/';
var usuario = new Usuario();

$(function () {
    $.get('Login/Login.htm', function (data) {
        $('body>.container').html(data);
        $('#btnEntrar').on('click', efetuarLogin);
    });
});

var efetuarLogin = function () {
    usuario.Login = $('#txtUsuario').val();
    usuario.Senha = $('#txtSenha').val();

    $('#alert').html('');
    $.ajax({
        type: 'GET',
        url: urlRest.concat('Usuario?Login=' + usuario.Login + '&Senha=' + usuario.Senha),
        statusCode: {
            302: function (xhr, textStatus, status) {
                usuario = new Usuario(xhr.responseJSON.Id, xhr.responseJSON.Nome, xhr.responseJSON.Login, xhr.responseJSON.Senha);

                $('#alert').html('');
                $('#nome_usuario').html(usuario.Nome)
                $.get('Principal/Principal.htm', carregaTelaPrincipal);
            },
            404: function (xhr, textStatus, status) {
                $('#tmpl-alert').tmpl(new Alert(tipoAlert.DANGER, xhr.responseJSON.Message)).appendTo('#alert');
            }
        }
    });
};

var carregaTelaPrincipal = function (data) {
    $('body>.container').html(data);
    var url = urlRest.concat('UsuarioImap?id_usuario=').concat(usuario.Id);

    $.get(url, function (data, status, xhr) {
        carregaComboServidor(data);
    });

    $('#btnEntrada').click(function () {
        $('#nav-entrada').slideToggle('slow');
    });

    $('#nav-entrada li').click(navEntradaMenu_Click);
};

var carregaComboServidor = function (usuario_imaps) {
    var combo = new Combo('cbxServidor', 'Servidor');

    for (var i = 0; i < usuario_imaps.length; i++) {
        var imap = usuario_imaps[i].Imap;
        var item = new Item(imap.Id, imap.Nome);
        combo.itens.push(item);
    }

    $('#tmpl-combobox').tmpl(combo).appendTo('#combo-container');
};

var navEntradaMenu_Click = function () {
    var opcao = this.id.split('_')[1];
    var url = urlRest.concat('Email/').concat(usuario.Id);

    switch (opcao) {
        case opcaoEntrada.LIDAS:
            break;
        case opcaoEntrada.NAO_LIDAS:
            break;
        case opcaoEntrada.IMPORTANTES:
            break;
        default:
            GetEmail(url);
            break;
    }
};

var GetEmail = function (url) {
    $.ajax({
        type: 'GET',
        url: url,
        statusCode: {
            302: function (xhr, textStatus, status) {
                $('#tmp-email').tmpl(xhr.responseJSON).appendTo('#panel-emails')
            },
            404: function (xhr, textStatus, status) {
                debugger;
            }
        }
    });
};