// Función para mostrar/ocultar el submenú
function toggleSubMenu() {
    var submenu = document.getElementById("submenuCarrera");

    // Alterna la clase 'show' para mostrar/ocultar el submenú
    if (submenu.classList.contains("show")) {
        submenu.classList.remove("show");  // Si tiene la clase, la quita (oculta el menú)
    } else {
        submenu.classList.add("show");  // Si no tiene la clase, la añade (muestra el menú)
    }
}
