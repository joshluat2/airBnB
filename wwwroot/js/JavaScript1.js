let image = document.getElementById('image')
let images = ['images/hue1.jpg', 'images/hue2']
setInterval(function(){
	let random = Math.floor(Math.random() * 2)
	image.src = images[random]	
	}, 800)
	//HTML, A. (2017). How To Automatically Change An HTML Image Using JavaScript. Stack Overflow. https://stackoverflow.com/questions/42003566/how-to-automatically-change-an-html-image-using-javascript