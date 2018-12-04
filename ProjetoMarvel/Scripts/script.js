$(document).ready(function () {
    $('#btn-pesquisa').on('click', function () {
        var texto = $('#texto-pesquisa').val();
        var data = {
            textoPesquisa: texto
        }
        if (texto) {
            window.location.href = urlPesquisar + '?textoPesquisa=' + texto.trim();
        }
    })
});