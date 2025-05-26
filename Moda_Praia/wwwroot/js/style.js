document.addEventListener('DOMContentLoaded', function () {
    const descricaoContainer = document.querySelector('.descricao-container');
    const botaoVerMais = document.querySelector('#verMais');

    if (descricaoContainer && botaoVerMais) {
        const alturaOriginal = '120px'; // Guardamos a altura original
        const overflowOriginal = 'hidden';
        let estadoExpandido = false; // Variável para rastrear o estado

        botaoVerMais.addEventListener('click', function () {
            if (!estadoExpandido) {
                // Expandir
                descricaoContainer.style.height = 'auto';
                descricaoContainer.style.overflowY = 'auto';
                descricaoContainer.classList.remove('fade-out'); // Remove a classe de fade
                estadoExpandido = true;
                botaoVerMais.textContent = 'ver menos'; // Mudar o texto do botão
            } else {
                // Voltar ao original
                descricaoContainer.style.height = alturaOriginal;
                descricaoContainer.style.overflowY = overflowOriginal;
                descricaoContainer.classList.add('fade-out'); // Adiciona a classe de fade
                estadoExpandido = false;
                botaoVerMais.textContent = 'ver mais'; // Mudar o texto do botão de volta
            }
        });

        // Adiciona a classe 'fade-out' inicialmente
        descricaoContainer.classList.add('fade-out');
    } else {
        console.log("Elemento '.descricao-container' ou botão '#verMais' não encontrado.");
    }
});


