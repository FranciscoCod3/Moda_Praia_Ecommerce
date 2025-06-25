/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Views/**/*.cshtml', // <--- ESTE É CRUCIAL PARA SUAS VIEWS
        './Pages/**/*.cshtml', // Se você estiver usando Razor Pages
        './wwwroot/**/*.html', // Se você tiver arquivos HTML estáticos
        // Se você tiver componentes Blazor ou outros tipos de arquivos:
        // './**/*.razor',
        // Outros caminhos de arquivos onde você usa classes Tailwind
    ],
    theme: {
        extend: {},
    },
    plugins: [],
}

