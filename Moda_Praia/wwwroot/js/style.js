const vermais = document.getElementById('botaoVermais');
const painel = document.getElementById('painel-recolher');

vermais.addEventListener('click', () => {
    const estaContraido = painel.classList.toggle('h-32');
    if (estaContraido) {
        painel.classList.remove('h-auto');
        vermais.textContent = 'Ver mais';
        console.log("Painel contraído.");
    } else {

        painel.classList.add('h-auto');
        vermais.textContent = 'Ver menos';
        console.log("Painel expandido.");
    }

});
