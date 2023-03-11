function toggleMobileMenu(menu) {
    menu.classList.toggle('open');

}
const carousel = document.querySelector('.carousel');
const prevBtn = document.querySelector('.prev');
const nextBtn = document.querySelector('.next');
let slidePosition = 0;
const slidesToShow = 4;

const updateSlidePosition = () => {
    carousel.style.transform = `translateX(-${slidePosition}%)`;
}

const moveToNextSlide = () => {
    slidePosition += 140 / slidesToShow;
    if (slidePosition > 140 - (140 / slidesToShow)) {
        slidePosition = 0;
    }
    updateSlidePosition();
}

const moveToPrevSlide = () => {
    slidePosition -= 140 / slidesToShow;
    if (slidePosition < 0) {
        slidePosition = 140 - (140 / slidesToShow);
    }
    updateSlidePosition();
}

prevBtn.addEventListener('click', moveToPrevSlide);
nextBtn.addEventListener('click', moveToNextSlide);

updateSlidePosition();



/* Password Visibility password page */

function showPassword(inputId) {
    var passwordInput = document.getElementById(inputId);
    if (passwordInput.type === "password") {
        passwordInput.type = "text";
    } else {
        passwordInput.type = "password";
    }
}




/* Password Visibility password page */

/* Password Visibility signup page */

function togglePasswordVisibility() {
    var passwordField = document.getElementById("password");
    if (passwordField.type === "password") {
        passwordField.type = "text";
    } else {
        passwordField.type = "password";
    }
}

/* Password Visibility signup page */


/* Password Visibility sign in page */
function showPassword() {
    var passwordInput = document.getElementById("password");
    if (passwordInput.type === "password") {
        passwordInput.type = "text";
    } else {
        passwordInput.type = "password";
    }
}

/* Password Visibility sign in page */
