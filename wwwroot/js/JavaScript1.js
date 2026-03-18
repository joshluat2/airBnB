let slideIndex = 0;
showSlides();

//This is the javascript function for iterating throuhg a list of divs containted within the mySlides class, once it lands on that iteration it will allow the cntents to be displayed as a block, while the rest of the divs will be hidden. It also iterates through the dots class to change the active dot to match the current slide. The setTimeout function allows for the slides to change every 6 seconds.
function showSlides() {
    let i;
    let slides = document.getElementsByClassName("mySlides");
    let dots = document.getElementsByClassName("dot");
    for (i = 0; i < slides.length; i++) {
        slides[i].style.display = "none";
    }
    slideIndex++;
    if (slideIndex > slides.length) { slideIndex = 1 }
    for (i = 0; i < dots.length; i++) {
        dots[i].className = dots[i].className.replace(" active", "");
    }
    slides[slideIndex - 1].style.display = "block";
    dots[slideIndex - 1].className += " active";
    setTimeout(showSlides, 6000); // Change image every 2 seconds
}