const button = document.getElementById("mybutton")
const thanks = document.getElementById("thankyou")

button.addEventListener("click", () => {
    thanks.classList.toggle("hidden")
})

//very simple javascript function that toggles the hidden class on the thank you message when the button is clicked. This allows the thank you message to be displayed or hidden based on the user's interaction with the button.https://forum.freecodecamp.org/t/contact-form-js-thank-you-message/549398/10