// Избранное.
// Смена цвета звёздочек.
let isFavorite = document.querySelectorAll('.fa-star');

for (let i = 0; i < isFavorite.length; i++) {

    isFavorite[i].onclick = function () {
        isFavorite[i].classList.toggle('favoriteClick');
    }
}

// Добавление ресурса в избранное.
$('.fa-star').click(function () {

    //read data attribute
    const webLinkId = $(this).data('weblink-id');

    // create model
    const model = {
        webLinkId: webLinkId
    };

    // post model to backend
    $.ajax({
        url: '/weblinks/favoriteToggle',
        data: model,
        type: "POST",
    });
});

// Модальные окна.
$(function () {
    $.ajaxSetup({ cache: false });
    $(".modalOpen").click(function (e) {

        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
});


// Смена цветовой темы.
const themeSwitch = document.querySelector('.switch-theme');

const body = document.querySelector('body');
const html = document.querySelector('html');

const tilesList = document.querySelectorAll('.wrapperForList');
const tilesSnippets = document.querySelectorAll('.linkTable');

const header = document.querySelector('.header');
const userName = document.querySelector('.userInfoSection__userName');
const headerUserInfo = document.querySelector('.header__userInfoSection');

const leftMenu = document.querySelector('.leftsideMenu__menu_wrapper');

const activeFavorite = document.querySelectorAll('.favoriteClick');

const mainSectionLinks = document.querySelectorAll('.mainSection a');

const searchForm = document.querySelector('.searchForm__textZone');
const searchButton = document.querySelectorAll('.searchForm__searchButton');

const createButton = document.querySelectorAll('.createButton');

// Смена классов цветовой темы.
function themeToggle() {
    themeSwitch.classList.toggle('switch-theme-dark');

    body.classList.toggle('dark-theme');
    html.classList.toggle('dark-theme');

    header.classList.toggle('dark-theme');
    headerUserInfo.classList.toggle('dark-theme-forTiles');

    for (let i = 0; i < tilesList.length; i++) {
        tilesList[i].classList.toggle('dark-theme-forTiles');
    }

    for (let i = 0; i < activeFavorite.length; i++) {
        activeFavorite[i].classList.toggle('dark-theme-forFavorite');
    }

    leftMenu.classList.toggle('dark-theme-forTiles');

    if (searchForm) {
        searchForm.classList.toggle('dark-theme-forTiles');
    } else {
        console.log("have no any searchForm on this page.")
    }

    for (let i = 0; i < mainSectionLinks.length; i++) {
        mainSectionLinks[i].classList.toggle('switch-theme-dark');
    }

    for (let i = 0; i < tilesSnippets.length; i++) {
        tilesSnippets[i].classList.toggle('switch-theme-dark');
    }

    for (let i = 0; i < createButton.length; i++) {
        createButton[i].classList.toggle('dark-theme-forTiles');
    }

    for (let i = 0; i < searchButton.length; i++) {
        searchButton[i].classList.toggle('dark-theme-forTiles');
        searchButton[i].classList.toggle('switch-theme-dark');
    }
}

// Переключение темы, сохранение состояния в LocalStorage.
let lightMode = localStorage.getItem('lightMode');

const enableLightMode = () => {
    themeToggle();
    localStorage.setItem("lightMode", "enabled");
}

const disableLightMode = () => {
    themeToggle();
    localStorage.setItem("lightMode", "null");
}

if (lightMode === "enabled") {
    enableLightMode();
}

themeSwitch.addEventListener("click", () => {
    lightMode = localStorage.getItem('lightMode');
    if (lightMode !== "enabled") {
        enableLightMode();
    } else {
        disableLightMode();
    }
});
