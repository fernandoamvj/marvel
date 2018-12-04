$(document).ready(function () {
    $('#btn-pesquisa').on('click', function () {
        var texto = $('#texto-pesquisa').val();
        if (texto) {
            window.location.href = urlPesquisar + '?textoPesquisa=' + texto.trim();
        }
    });
    $('#texto-pesquisa').on('keypress', function (e) {
        if (e.which === '13') {
            var texto = $('#texto-pesquisa').val();
            if (texto) {
                window.location.href = urlPesquisar + '?textoPesquisa=' + texto.trim();
            }
        };
    })
});