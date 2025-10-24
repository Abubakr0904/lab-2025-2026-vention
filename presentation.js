// Shared presentation navigation script
// Call initPresentation(totalSlides) to initialize

function initPresentation(totalSlides) {
    let currentSlide = 1;

    window.showSlide = function(n) {
        const slides = document.querySelectorAll('.slide');
        currentSlide = n;  // Update currentSlide with the passed value
        if (currentSlide > totalSlides) currentSlide = totalSlides;
        if (currentSlide < 1) currentSlide = 1;
        
        if (currentSlide > slides.length) {
            console.error(`Trying to show slide ${currentSlide} but only ${slides.length} slides found in DOM`);
            currentSlide = slides.length;
        }
        
        slides.forEach(slide => slide.classList.remove('active'));
        slides[currentSlide - 1].classList.add('active');
        
        document.getElementById('currentSlide').textContent = currentSlide;
        document.getElementById('prevBtn').disabled = currentSlide === 1;
        document.getElementById('nextBtn').disabled = currentSlide === totalSlides;
        
        // Update jump input max attribute
        const slideInput = document.getElementById('slideInput');
        if (slideInput) {
            slideInput.max = totalSlides;
        }
    }

    window.changeSlide = function(n) {
        currentSlide += n;
        showSlide(currentSlide);
    }

    window.goToSlide = function() {
        const input = document.getElementById('slideInput');
        const slideNum = parseInt(input.value);
        
        if (slideNum >= 1 && slideNum <= totalSlides) {
            currentSlide = slideNum;
            showSlide(currentSlide);
            input.value = '';
        } else {
            alert(`Please enter a slide number between 1 and ${totalSlides}`);
        }
    }

    document.addEventListener('keydown', (e) => {
        // Don't navigate if user is typing in the input field
        if (document.activeElement.id === 'slideInput') return;
        
        if (e.key === 'ArrowLeft') changeSlide(-1);
        if (e.key === 'ArrowRight') changeSlide(1);
    });

    showSlide(currentSlide);
}

