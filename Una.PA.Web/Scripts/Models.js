var Usuario = function (Id, Nome, Login, Senha) {
    this.Id = Id ? Id : 0;
    this.Nome = Nome ? Nome : '';
    this.Login = Login ? Login : '';
    this.Senha = Senha ? Senha : '';
};

var Combo = function (id_combo, label, itens) {
    this.id_combo = id_combo ? id_combo : 0;
    this.label = label ? label : '';
    this.itens = itens ? itens : [new Item(0, 'Todos')];
};

var Item = function (valor, texto) {
    this.valor = valor ? valor : 0;
    this.texto = texto ? texto : '';
};