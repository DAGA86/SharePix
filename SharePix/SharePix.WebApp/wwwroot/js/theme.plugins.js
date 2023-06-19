;(function($){

	"use strict";

	$(document).ready(function(){

		window.ISRTL = getComputedStyle(document.body).direction === 'rtl' ? true : false;

		/* ------------------------------------------------
				Accordion
		------------------------------------------------ */

			$('.accordion').accordion();

		/* ------------------------------------------------
				End of Accordion
		------------------------------------------------ */

		/* ------------------------------------------------
				Toggles
		------------------------------------------------ */

			$('.toggles').accordion(true);

		/* ------------------------------------------------
				End of Toggles
		------------------------------------------------ */

		/* ------------------------------------------------
				Tabs
		------------------------------------------------ */

			if($('.tabs').length || $('.tour_section').length){

				$('.tabs, .tour_section').easytabs({
					updateHash: false,
					tabActiveClass: 'active',
					animationSpeed : 400
				});

			}

		/* ------------------------------------------------
				End of Tabs
		------------------------------------------------ */

		/* ------------------------------------------------
				Video Slideshow
		------------------------------------------------ */

		var videoSlideshow = $('.video_slideshow');

		if(videoSlideshow.length){

			videoSlideshow.owlCarousel({
				animateOut: 'slideOutLeft',
				animateIn: 'flipInX',
				video: true,
				items: 1,
				videoWidth: true,
				videoHeight: 500,
				smartSpeed: 300,
				lazyLoad: true,
				loop: true,
				nav: true,
				dots: false,
				navText: [],
				rtl: window.ISRTL
			});

		}

		/* ------------------------------------------------
				End of Video Slideshow
		------------------------------------------------ */

		/* ------------------------------------------------
				Calendar
		------------------------------------------------ */

			$('#calendar').calendar({
				months : ['January','February','March','April','May','June','Jully','August','September','October','November','December'],
				prevNextLabels : ['JAN', 'FEB', 'MAR', 'APR', 'MAY', 'JUN', 'JUL', 'AUG', 'SEP', 'OCT', 'NOV', 'DEC'],
				dayLabels : ['M', 'T', 'W', 'T', 'F', 'S', 'S'],
				events: [
					{
						'date': new Date(2015, 4, 6),
						'description': 'Lorem ipsum dolor sit amet!',
						'link': '#'
					},
					{
						'date': new Date(2015, 4, 21),
						'description': 'Aliquam erat volutpat. Duis ac turpis!',
						'link': '#'
					}
				]
			});

		/* ------------------------------------------------
				End of Calendar
		------------------------------------------------ */

		/* ------------------------------------------------
				Ribbon Slideshow
		------------------------------------------------ */

			var rS = $('.ribbon_slideshow'),
				w = $(window);

			function initRibbonSlideshow(){

				if(w.width() < 768){
					if(rS.find('.owl-stage-outer').length){
						rS.trigger('destroy.owl.carousel');
						rS.find('img').unwrap();
					}
				}
				else{
					rS.owlCarousel({
						autoWidth: true,
						margin: 10,
						items: 2,
						smartSpeed: 300,
						lazyLoad: true,
						loop: true,
						nav: true,
						dots: false,
						navText: [],
						rtl: window.ISRTL
					});
				}

			}

			if(rS.length){

				initRibbonSlideshow();
				w.on('resize.destroyRibbonSlideshow', initRibbonSlideshow);

			}

		/* ------------------------------------------------
				End of Ribbon Slideshow
		------------------------------------------------ */

		

		/* ------------------------------------------------
				Product preview thumbnails
		------------------------------------------------ */

			var thumbs = $('#thumbnails');

			if(thumbs.length){

				thumbs.owlCarousel({
					responsive :{
						1200:{
							items: thumbs.data('items')
						}
					},
					margin: 10,
					smartSpeed: 400,
					nav: true,
					dots: false,
					navText: [],
					rtl: window.ISRTL
				});

			}

		/* ------------------------------------------------
				End of Product preview thumbnails
		------------------------------------------------ */

		/* ------------------------------------------------
				Flow Gallery
		------------------------------------------------ */

			var flowCarousel = $('#flow_carousel');

			if(flowCarousel.length){

				flowCarousel.owlCarousel({
					responsive:{
						0: {
							margin: 0
						},
						768 :{
							margin: 75
						},
						1025: {
							margin: 90
						},
						1367:{
							margin: 108
						}
					},
					items: 2,
					center: true,
					smartSpeed: 500,
					lazyLoad: true,
					loop: true,
					nav: true,
					dots: false,
					navText: [],
					autoplay: true,
					autoplayTimeout: 3000,
					rtl: window.ISRTL,
					onInitialized: function(){

						var carousel = $('#flow_carousel'),
							slideData = $('#gallery_slide_data'),
							title = slideData.children('.slide_caption'),
							desc = slideData.children('.slide_description'),
							slideCaption = carousel.find('.center').children('.flow_item').data('title'),
							slideDesc = carousel.find('.center').children('.flow_item').data('description');

						title.text(slideCaption);
						desc.text(slideDesc);

					},
					onTranslated: function(){

						var carousel = $('#flow_carousel'),
							slideData = $('#gallery_slide_data'),
							title = slideData.children('.slide_caption'),
							desc = slideData.children('.slide_description'),
							slideCaption = carousel.find('.center').children('.flow_item').data('title'),
							slideDesc = carousel.find('.center').children('.flow_item').data('description');

						slideData.addClass('changing');
						setTimeout(function(){
							title.text(slideCaption);
							desc.text(slideDesc);
							slideData.removeClass('changing');
						},300);
						
						
					}
				});

			}

		/* ------------------------------------------------
				End of Flow Gallery
		------------------------------------------------ */

		/* ------------------------------------------------
				Fancybox
		------------------------------------------------ */

			var fancyBox = $('.fancybox'),
				fancyBoxMedia = $('.fancybox_media'),
				flickrFeed = $('.flickr_feed'),
				dribbbleFeed = $('.dribbble_feed'),
				instagramFeed = $('.instagram_feed'),
				productPreview = $('.product_preview');

			if(fancyBox.length || fancyBoxMedia.length || flickrFeed.length || dribbbleFeed.length || instagramFeed.length || productPreview.length){
				var fbHelpers = {
					thumbs: {
						width: 80,
						height: 80
					},
					buttons: {}
				},

				fbDefault = {
					openEffect: 'elastic',
					closeEffect: 'elastic',
					openSpeed: 300,
					closeSpeed: 300,
					padding: 10,
					helpers: $.extend($.fancybox.defaults.helpers, fbHelpers),
					wrapCSS: 'j_fancybox'
				};

				$.fancybox.defaults = $.extend($.fancybox.defaults, fbDefault);

			}

			if(fancyBox.length) fancyBox.fancybox();

			if(fancyBoxMedia.length){
				fancyBoxMedia.fancybox({
					helpers: {
						media: {}
					}
				});
			}

		/* ------------------------------------------------
				End of Fancybox
		------------------------------------------------ */

		/* ------------------------------------------------
				Custom Select
		------------------------------------------------ */

			$('.custom_select').customSelect();

		/* ------------------------------------------------
				End of Custom Select
		------------------------------------------------ */

		/* ------------------------------------------------
				Instafeed
		------------------------------------------------ */

			if($('#instafeed').length){
				var feed = new Instafeed({
					get: 'tagged',
					tagName: 'nature',
					limit: 6,
					resolution: 'standard_resolution',
					clientId: '686d7a7385cf43ebb9518774734459da',
					template: '<li><a class="fancybox" rel="instagram" href="{{image}}" title="{{location}}"><img src="{{image}}" /></a></li>',
					after: function(){
						$('#' + this.options.target).find('.fancybox').fancybox();
					}
				});

				feed.run();
			}

		/* ------------------------------------------------
				End of Instafeed
		------------------------------------------------ */

		/* ------------------------------------------------
				Countdown
		------------------------------------------------ */

		var cd = $('#countdown');

			if(cd.length){

				cd.countdown({
					until: new Date(2016, 0, 1, 0, 0, 0),
					format: 'dHMS',
					labels: ['years', 'months', 'weeks', 'days', 'hours', 'minutes', 'seconds'],
					labels1: ['year', 'month', 'week', 'day', 'hour', 'minute', 'second'],
					isRTL: window.ISRTL,
					layout: '<div class="cd_row">\
								<div class="cd_section">\
									<div class="cd_period">{dnn}</div><div class="cd_label">{dl}</div>\
								</div>\
								<div class="cd_section cd_sep">{sep}</div>\
								<div class="cd_section">\
									<div class="cd_period">{hnn}</div><div class="cd_label">{hl}</div>\
								</div>\
								<div class="cd_section cd_sep">{sep}</div>\
								<div class="cd_section">\
									<div class="cd_period">{mnn}</div><div class="cd_label">{ml}</div>\
								</div>\
								<div class="cd_section cd_sep">{sep}</div>\
								<div class="cd_section">\
									<div class="cd_period">{snn}</div><div class="cd_label">{sl}</div>\
								</div>'
				});

			}

		/* ------------------------------------------------
				End of Countdown
		------------------------------------------------ */

		/* ------------------------------------------------
				Range Slider
		------------------------------------------------ */

			var rangeSlider = $('#slider');

			if(rangeSlider.length){

				rangeSlider.slider({

					range : true,
					min : 0,
					max : 150,
					values : [0, 145],
					step : 1,

					slide : function(event, ui){

						var min = ui.values[0],
							max = ui.values[1],
							range = $(this).siblings('.range');


						range.children('.min_value').val('$' + min).next('.max_value').val('$' + max);

					},

					create : function(event, ui){

						var $this = $(this),
							min = $this.slider("values", 0),
							max = $this.slider("values", 1),
							range = $this.siblings('.range');

						range.children('.min_value').val('$' + min).next('.max_value').val('$' + max);
						
					}

				});

			}

		/* ------------------------------------------------
				End of Range Slider
		------------------------------------------------ */

		/* ------------------------------------------------
				Elevate Zoom
		------------------------------------------------ */

			var zoomImage = $('#img_zoom');

			if(zoomImage.length){
				zoomImage.elevateZoom({
					zoomType: "inner",
					gallery:'thumbnails',
					galleryActiveClass: 'active',
					cursor: "crosshair",
					responsive:true,
					easing:true,
					zoomWindowFadeIn: 500,
					zoomWindowFadeOut: 500,
					lensFadeIn: 500,
					lensFadeOut: 500
				});

				$(".qv_lightbox_btn").on("click", function(e) { 
					var ez = $(this).siblings('img').data('elevateZoom');
					$.fancybox(ez.getGalleryList());
					e.preventDefault();
				});

			}

		/* ------------------------------------------------
				End of Elevate Zoom
		------------------------------------------------ */

		/* ------------------------------------------------
				Revolution Slider
		------------------------------------------------ */

			var container = $('.bannercontainer');

			window.revSlider = undefined;

			if(container.length){

				window.revSlider = $('.banner').revolution({
				 	delay: 6000,
				 	fullScreen: "on",
				 	fullScreenAlignForce: "on",
				 	onHoverStop: "off",
				 	hideTimerBar: "on",
				 	spinner: false,
				 	navigationType: 'thumb',
				 	hideThumbs: 0,
				 	thumbAmount: Math.ceil($(window).width() / 130 ),
				 	thumbWidth: 130,
				 	thumbHeight: 130,
				 	navigationVOffset: 0,
				 	navigationStyle: false,
				 	dottedOverlay: container.hasClass('revolution_slider') ? 'twoxtwo' : 'none'
				 });

			}

		/* ------------------------------------------------
				End of Revolution Slider
		------------------------------------------------ */

	});

	$(window).load(function(){

		/* ------------------------------------------------
				Google Map
		------------------------------------------------ */

			if($('#gmap').length){

	            // Basic options for a simple Google Map
	            // For more options see: https://developers.google.com/maps/documentation/javascript/reference#MapOptions
	            var mapOptions = {
	                // How zoomed in you want the map to start at (always required)
	                zoom: 11,

	                // The latitude and longitude to center the map (always required)
	                center: new google.maps.LatLng(40.6700, -73.9400), // New York

	                // How you would like to style the map.
	                styles: [{"featureType":"all","elementType":"all","stylers":[{"saturation":-100},{"gamma":0.5}]}],

	                panControl: false,

	                zoomControl: false,

	                scaleControl: false,

	                mapTypeControl: false,

	                streetViewControl: false,

	                overviewMapControl: false
	            };

	            // Get the HTML DOM element that will contain your map
	            var mapElement = document.getElementById('gmap');

	            // Create the Google Map using our element and options defined above
	            var map = new google.maps.Map(mapElement, mapOptions);

	            // Let's also add a marker while we're at it
	            var marker = new google.maps.Marker({
	                position: new google.maps.LatLng(40.6700, -73.9400),
	                map: map,
	                title: 'Joker!',
	                icon: 'images/marker.png'
	            });

	            $(window).on('resize.map', function(){

	            	var center = map.getCenter();

					google.maps.event.trigger(map, "resize");
					map.setCenter(center);

	            });

			}

		/* ------------------------------------------------
				End of Google Map
		------------------------------------------------ */

		/* ------------------------------------------------
				Slideshow
		------------------------------------------------ */

			var slideshow = $('.slideshow');

			if(slideshow.length){

				slideshow.owlCarousel({
					animateOut: 'slideOutLeft',
					animateIn: 'flipInX',
					items: 1,
					smartSpeed: 300,
					loop: true,
					nav: true,
					dots: false,
					navText: [],
					rtl: window.ISRTL,
					autoHeight: false
				});

			}

		/* ------------------------------------------------
				End of Slideshow
		------------------------------------------------ */

		/* ------------------------------------------------
				Gallery Ribbon
		------------------------------------------------ */

			var gR = $('.gallery_ribbon'),
				w = $(window);

				function initGalleryRibbon(){

					var wH = $(window).height(),
						pW = $('#page_wrap'),
						hH = $('#header').outerHeight(),
						captions = $('.slide_caption_wrap'),
						fH = $('#footer').outerHeight(),
						carousel = $('#gallery_ribbon'),
						sCH = captions.outerHeight() + parseInt(captions.css('margin-top')) + (parseInt(pW.css('padding-top')) - hH) + parseInt(pW.css('padding-bottom'));

					carousel.find('img').css('height', wH - hH - fH - sCH);

					if(gR.find('.owl-stage-outer').length){
						gR.trigger('destroy.owl.carousel');
						gR.find('.ribbon_item').unwrap();
					}

					if(w.width() > 767){

						gR.owlCarousel({
							autoWidth: true,
							margin: 10,
							items: 3,
							smartSpeed: 300,
							lazyLoad: true,
							loop: true,
							nav: false,
							dots: false,
							navText: [],
							rtl: window.ISRTL,
							onInitialized: function(){

								var carousel = $('#gallery_ribbon'),
									slideData = $('#gallery_slide_data'),
									title = slideData.children('.slide_caption'),
									desc = slideData.children('.slide_description'),
									slideCaption = carousel.find('.active:first').children('.ribbon_item').data('title'),
									slideDesc = carousel.find('.active:first').children('.ribbon_item').data('description');

								title.text(slideCaption);
								desc.text(slideDesc);

								gR.find('.owl-stage').css({
									'height': wH - hH - fH - sCH,
									'overflow': 'hidden'
								});

							},
							onTranslated: function(){

								var carousel = $('#gallery_ribbon'),
									slideData = $('#gallery_slide_data'),
									title = slideData.children('.slide_caption'),
									desc = slideData.children('.slide_description'),
									slideCaption = carousel.find('.active:first').children('.ribbon_item').data('title'),
									slideDesc = carousel.find('.active:first').children('.ribbon_item').data('description');

								slideData.addClass('changing');
								setTimeout(function(){
									title.text(slideCaption);
									desc.text(slideDesc);
									slideData.removeClass('changing');
								},300);
								
								
							}
						});
					}	
				}

			if(gR.length){

				initGalleryRibbon();

				w.on('resize.destroyRibbon', function(){

					setTimeout(initGalleryRibbon, 150);

				});

			}

		/* ------------------------------------------------
				End of Gallery Ribbon
		------------------------------------------------ */

	});

})(jQuery);