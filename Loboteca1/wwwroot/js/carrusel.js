let currentIndex = 0;
let currentIndexMagazines = 0;

function moveCarousel(direction) {
    const items = document.querySelectorAll('.books-section .carousel .book');
    currentIndex += direction;

    if (currentIndex < 0) {
        currentIndex = items.length - 1;
    } else if (currentIndex >= items.length) {
        currentIndex = 0;
    }

    const offset = -currentIndex * (items[0].offsetWidth + 20); // Ajuste del desplazamiento basado en el ancho
    items.forEach(item => {
        item.style.transform = `translateX(${offset}px)`;
    });
}

function moveCarouselMagazines(direction) {
    const items = document.querySelectorAll('.magazines-section .carousel .magazine');
    currentIndexMagazines += direction;

    if (currentIndexMagazines < 0) {
        currentIndexMagazines = items.length - 1;
    } else if (currentIndexMagazines >= items.length) {
        currentIndexMagazines = 0;
    }

    const offset = -currentIndexMagazines * (items[0].offsetWidth + 20);
    items.forEach(item => {
        item.style.transform = `translateX(${offset}px)`;
    });
}
