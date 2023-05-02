// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$('.close-alert').click(function () {
    $('.alert').hide('hide');
});

$(".close-alert").delay(5000).slideUp(200, function () {
    $(this).alert('close');
});

$("#moeda").change(function (e) {
    $("#moeda").val($("#moeda").val().replace('.', ','));
});


function sufixo(valor) {
    if (valor < 10) {
        return "-0" + valor;
    }
    else {
        return "-" + valor;
    }
}

$("#campoOpcao").change(
    function pegarLetra() {

        //CAMPO DO CODIGO DA OPÇÃO
        const valor = $("#campoOpcao").val();

        if (valor != '' && valor != null && valor.length > 4) {


            let conteudo = $("#campoOpcao").val();
            $("#campoOpcao").val(conteudo.toUpperCase());
            conteudo = conteudo.toUpperCase();


            //TRATAMENTO
            let item = String(dicionarioOpcoes().get(conteudo.substring(4, 5))).split(',');


            //CAMPO DA DATA DE VENCIMENTO
            let thirdFriday = new Date($("#anoVencimento").val(), item[0] - 1, 15);
            while (thirdFriday.getDay() !== 5) {
                thirdFriday.setDate(thirdFriday.getDate() + 1);
            }

            $("#dataVencimento").val(thirdFriday.getFullYear() + sufixo(thirdFriday.getMonth() + 1) + sufixo(thirdFriday.getDate()));


            //CAMPO DO TIPO
            $("#tipo").val(item[1]);
        } else {
            alert("Necessário Preencher o campo corretamente!");
        }
    }
);



$("#anoVencimento").change(
    function pegarLetra() {

        const valor = $("#campoOpcao").val();

        if (valor != '' && valor != null && valor.length > 4) {

            //TRATAMENTO
            let item = String(dicionarioOpcoes().get($("#campoOpcao").val().substring(4, 5))).split(',');


            //CAMPO DA DATA DE VENCIMENTO
            let thirdFriday = new Date($("#anoVencimento").val(), item[0] - 1, 15);
            while (thirdFriday.getDay() !== 5) {
                thirdFriday.setDate(thirdFriday.getDate() + 1);
            }

            $("#dataVencimento").val(thirdFriday.getFullYear() + sufixo(thirdFriday.getMonth() + 1) + sufixo(thirdFriday.getDate()));


            //CAMPO DO TIPO
            $("#tipo").val(item[1]);
        } else {
            alert("Necessário Preencher o campo!");
        }
    }
);

function dicionarioOpcoes() {
    let i = 1;
    let mes;
    let tipo;

    const dic = new Map();
    for (let letter = 'A'.charCodeAt(0); letter <= 'X'.charCodeAt(0); letter++) {
        mes = (i > 12) ? i - 12 : i;
        tipo = (i > 12) ? "Put" : "Call";
        dic.set(String.fromCharCode(letter), mes + "," + tipo);
        i++;
    }

    return dic;
}