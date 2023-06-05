

function exibir(pos, botao) {
    const hy = document.getElementsByTagName('td');

    for (var i = pos; i < hy.length; i = i + pos + 1) {

        document.getElementsByTagName('td')[i].style.display = "block";
    }
    document.getElementById(botao).style.display = "block";
}



function currencyTreatment(id) {
    const valor = $(id).val().replace('.', ',').split(',');

    if (valor[1].length < 2) {
        valor[1] = parseInt(valor[1] + '0');
    }

    $(id).val(valor[0] + ',' + valor[1]);
};