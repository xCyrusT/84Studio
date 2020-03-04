$( document ).ready(function() {
	
   $('[data-fancybox="video"]').fancybox();

    $('.owl-carousel').owlCarousel({
        loop: true,
        margin: 10,
        responsiveClass: true,
        autoplay:true,
	    autoplayTimeout:1000,
	    autoplayHoverPause:true,
        responsive: {
          0: {
            items: 1,
            nav: true
          },
          600: {
            items: 3,
            nav: false
          },
          1000: {
            items: 5,
            nav: true,
            loop: false,
            margin: 20
          }
        }
      })

    new WOW().init();
});
