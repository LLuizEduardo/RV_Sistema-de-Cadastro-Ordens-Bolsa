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



//$("#dataV").change(
//    function pegarData() {
//        let campoData = $("#dataV").val();
//        let ano = campoData.substring(0, 4);
//        let mes = parseInt(campoData.substring(5, 7));
//        let thirdFriday = new Date(ano, mes - 1, 15);

//        while (thirdFriday.getDay() !== 5) {
//            thirdFriday.setDate(thirdFriday.getDate() + 1);
//        }

//        $("#dataVencimento").val(thirdFriday.getFullYear() + sufixo(thirdFriday.getMonth() + 1) + sufixo(thirdFriday.getDate()));
//    }
//);

//$("#dataV").change(
//    function pegarData() {
//        let campoData = $("#dataV").val();
//        //let ano = campoData.substring(0, 4);
//        let mes = parseInt(campoData.substring(5, 7));
//        let thirdFriday = new Date(2000, mes - 1, 15);

//        while (thirdFriday.getDay() !== 5) {
//            thirdFriday.setDate(thirdFriday.getDate() + 1);
//        }

//        $("#dataVencimento").val(thirdFriday.getFullYear() + sufixo(thirdFriday.getMonth() + 1) + sufixo(thirdFriday.getDate()));
//    }
//);


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
        let conteudo = $("#campoOpcao").val().toUpperCase().substring(4, 5);
        //alert(conteudo);
        let item = String(dicionarioOpcoes().get(conteudo)).split(',');
        

        let thirdFriday = new Date($("#anoVencimento").val(), item[0] - 1, 15);

        while (thirdFriday.getDay() !== 5) {
            thirdFriday.setDate(thirdFriday.getDate() + 1);
        }

        $("#dataVencimento").val(thirdFriday.getFullYear() + sufixo(thirdFriday.getMonth() + 1) + sufixo(thirdFriday.getDate()));


        $("#tipo").val(item[1]); //OK
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