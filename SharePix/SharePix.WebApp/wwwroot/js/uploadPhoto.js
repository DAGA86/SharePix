$(document).ready(function () {
    // Manipulador de evento para alterações no input de arquivos
    $('#photos').on('change', function (e) {
        var files = e.target.files; // Obter lista de arquivos selecionados

        // Limpar a div de visualização de miniaturas
        $('#preview').empty();

        // Iterar por cada arquivo selecionado
        for (var i = 0; i < files.length; i++) {
            var file = files[i];
            var reader = new FileReader();

            // Função de retorno de chamada para o leitor de arquivos
            reader.onload = (function (file) {
                return function (e) {
                    // Criar uma imagem para exibir a miniatura
                    var image = $('<img>').addClass('thumb').attr('src', e.target.result);
                    // Adicionar a imagem à div de visualização de miniaturas
                    $('#preview').append(image);
                };
            })(file);

            // Ler o arquivo como uma URL de dados
            reader.readAsDataURL(file);
        }
    });
});

document.getElementById("uploadForm").addEventListener("submit", function (event) {
    const maxFileSize = 100 * 1024 * 1024; // 100 MB in bytes 

    const fileInput = document.getElementById("photos");
    const files = fileInput.files;
    let totalFileSize = 0;

    for (let i = 0; i < files.length; i++) {
        const file = files[i];
        totalFileSize += file.size;
    }

    if (totalFileSize > maxFileSize) {
        event.preventDefault(); // Prevent form submission
        alert("Max 100 MB.");
        return;
    }
});