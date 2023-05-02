

function exibir(pos, botao) {
    const hy = document.getElementsByTagName('td');

    for (var i = pos; i < hy.length; i = i + pos + 1) {

        document.getElementsByTagName('td')[i].style.display = "block";
    }
    document.getElementById(botao).style.display = "block";
}