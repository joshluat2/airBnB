const button = document.getElementById("mybutton")
const thanks = document.getElementById("thankyou")

button.addEventListener("click", () => {
    thanks.classList.toggle("hidden")
})