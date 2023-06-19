(function($){

	"use strict";

	var Core = {

		TRANSITIONSUPPORTED : $('html').hasClass('md_csstransitions'),
		TRANSITIONEND : "webkitTransitionEnd otransitionend oTransitionEnd msTransitionEnd transitionend",
		ISRTL : getComputedStyle(document.body).direction === 'rtl' ? true : false,
		ISTOUCH : $('html').hasClass('md_touch'),

		windowLoad: function(){

			var self = this;

			this.preloader(1000);
			this.helpers.fullWidthBlocks();
			
			setTimeout(function(){
				self.isotope.init();
			},200);
			
			this.helpers.fullScreenView();
			this.helpers.revolutionSliderEvents();
			this.events.toggleViewFullScreen();
			this.helpers.documentHeightFix();
			this.helpers.mobileSticky();
			this.showFooter();

		},

		DOMReady: function(){

			this.helpers.prepareExtendedBlock();
			this.helpers.prepareOwlControls();
			this.components.flowCarousel();
			this.events.closeButton();
			this.events.actions();
			this.events.animationBox();
			this.events.cookieControl();
			this.events.jItemsTouchHover();
			this.initializeSVGIcons();
			this.components.subscribeForm.init();
			this.components.productRating();
			this.components.qty();
			this.components.contactForm.init();
			this.components.protectedForm.init();
			this.flickrFeed();
			this.dribbbleFeed();
			this.components.progressBarsFill();
			this.components.statisticCounters();
			this.components.beforeAfter();
			this.helpers.fancyboxValidate();
			this.albums.init();

			if($('body').hasClass('horizontal_menu_type')) this.mainNavigation.initHorizontalMenu();
			else this.mainNavigation.initVerticalMenu();
			window.mainNavigation = this.mainNavigation;

			if(window.ie9placeholder){
				window.ie9placeholder();
			}


			$('.navigation').on('mouseenter', '.has_submenu', function(){
var self = $(this);

setTimeout(function(){
     self.children('.submenu').css('opacity', 0.99);
}, 705);


});

$('.navigation').on('mouseleave', '.has_submenu', function(){

var self = $(this);

setTimeout(function(){
self.find('.submenu').removeAttr('style');
}, 705);


});

		},

		preloader: function(delay){

			delay = delay || 0;

			var l = $('#page_loader');

			l.delay(delay).animate({
				opacity: 0
			}, 1000, function(){
				$(this).remove();
			});

		},

		/**
		** extends jQuery by own mini plugins
		**/
		extend : function(){

			$.fn.extend({

				/**
		        **	Accordion plugin
		        **	@param toggle - set to true, if need to be toggle
		        **	@return jQuery
		        **/
		        accordion : function(toggle){

		        	return this.each(function(){

		        		var $this = $(this),
		        			active = $this.children('dt.active').length ? $this.children('dt.active') : $this.children('dt:first').addClass('active');

		        		$this.children('dt').not(active).next().hide();
		        		
		        		$this.on('click', 'dt', function(){
		        			
		        			if(!toggle){
		        				$(this).addClass('active')
		        						.siblings('dt')
		        						.removeClass('active')
		        						.end()
		        						.next('dd')
		        						.stop()
		        						.slideDown()
		        						.siblings('dd')
		        						.stop()
		        						.slideUp();
		        			}
		        			else{
		        				$(this).toggleClass('active').next().stop().slideToggle();
		        			}

		        		});

		        	});

		        },

		        /**
				**	Emulates select form element
				**	@return jQuery
				**/
				customSelect : function(){

					// template
					var template = "<div class='active_option open_select'><div class='inner'></div></div><ul class='options_list dropdown'></ul>";

					return this.each(function(){

						var $this = $(this);

						$this.prepend(template);

						var active = $this.children('.active_option'),
							activeInner = active.children('.inner'),
							list = $this.children('.options_list'),
							select = $this.children('select').hide(),
							options = select.children('option');

						active.on('click', function(){
							active.add(list).toggleClass('opened');
						});

						activeInner.text( 
							select.children('option[selected]').val() ? 
								select.children('option[selected]').val() : 
								options.eq(0).val()
						);

						options.each(function(){

							var template = $('<li></li>',{
									text : $(this).val()
								});

							list.append(template);
							
						});

						list.on("click", "li", function(){

							var v = $(this).text();
							activeInner.text(v);
							select.val(v);

							if(!Core.TRANSITIONSUPPORTED){
								$(this).closest('.dropdown').add(active).removeClass("active");
							}else{
								$(this).closest(list).add(active).removeClass("opened");
							}

						});

					});

				},

				calendar : function(options){

					var $this = $(this),

						calendar = {

							init: function(container){

								var self = this;

								self.container = container;
								self.currentDate = new Date();
								self.CDYear = self.currentDate.getFullYear();
								self.CDMonth = self.currentDate.getMonth();
								self.dCurrentDate = new Date(self.CDYear, self.CDMonth);
								self.counter = self.CDMonth;
								self.generateContainers(self.dCurrentDate);
								self.bindEvents();

							},

							generateContainers: function(date){

								var self = this,
									wrap = $('<table class="j_calendar"></table>'),
									header = $('<thead><tr><th colspan="7" class="jc_header">'+options.months[date.getMonth()]+ ' ' + date.getFullYear() +'</th></tr></thead>'),
									tbody = '<tbody>',
									dayLabels = $('<tr></tr>'),
									footer = $('<footer class="jc_actions"><a href="#" class="jc_prev" data-dir="prev"><span>&#171;</span>'+options.prevNextLabels[self.currentDate.getMonth() - 1]+'</a><a href="#" class="jc_next j_hide" data-dir="next">'+options.prevNextLabels[self.currentDate.getMonth() + 1]+'<span>&#187;</span></a><footer>');

								for(var i = 0; i < 7; i++)
									dayLabels.append('<th>'+options.dayLabels[i]+'</th>');
								
								header.append(dayLabels);

								tbody += self.generateMonthMarkup(self.CDYear, self.CDMonth) + '</tbody>';
								
								wrap.append(header);
								wrap.append(tbody);
								self.container.html(wrap);

								wrap.after(footer);

								self.body = self.container.find('tbody');
								self.prev = footer.children('.jc_prev');
								self.next = footer.children('.jc_next');
								self.header = self.container.find('.jc_header');

							},

							generateMonthMarkup: function(year, month){

								var date = new Date(year, month),
									self = this,
									template = "<tr>";

								// fill empty cells
								for(var i = 0; i < self.getTableDay(date); i++) template += "<td></td>";

								// generate full month
								while(date.getMonth() == month){
									if(year == self.CDYear && month == self.CDMonth && date.getDate() == self.currentDate.getDate())
										template += '<td class="active">'+date.getDate()+'</td>';
									else{
										var isEvent = false;
										$.each(options.events, function(i, obj){
											if(obj.date.valueOf() == date.valueOf()){
												template += '<td><a href="'+obj.link+'" class="tooltip_container">'+date.getDate()+'<span class="tooltip top">'+obj.description+'</span></a></td>';
												isEvent = true;
												return false;
											}
										});
										if(!isEvent){
								    		template += '<td>'+date.getDate()+'</td>';
								    		isEvent = false;
										}
								    }
								    if (self.getTableDay(date) % 7 == 6) template += '</tr><tr>';
								    date.setDate(date.getDate()+1);
								}
								if(self.getTableDay(date) != 0){
									for (var i=self.getTableDay(date); i<7; i++){
								    	template += '<td></td>';
									}
								}

								return template;

							},

							getTableDay: function(date){
								var day = date.getDay();
							  	if (day == 0) day = 7;
							  	return day - 1;
							},

							bindEvents: function(){

								var self = this;
								self.prev.add(self.next).on('click', {self: self}, self.changeMonthHandler);

							},

							changeMonthHandler: function(event){
								event.preventDefault();

								var self = event.data.self,
									direction = $(this).data('dir'),
									ddMonth = self.dCurrentDate.getMonth();

								if(direction == "prev"){
									self.dCurrentDate.setMonth(--ddMonth);
									--self.counter;
									if(self.counter == 0) self.counter = 12;
								}
								else{
									self.dCurrentDate.setMonth(++ddMonth);
									++self.counter;
								}
								

								self.prev.html('<span>&#171;</span>' + options.prevNextLabels[(self.counter-1) % 12]);
								self.next.html(options.prevNextLabels[(self.counter+1) % 12] + '<span>&#187;</span>');

								if(self.dCurrentDate.getMonth() == self.CDMonth && self.dCurrentDate.getFullYear() == self.CDYear)
									self.next.addClass('j_hide');
								else
									self.next.removeClass('j_hide');


								self.header.html(options.months[self.dCurrentDate.getMonth()] + " " + self.dCurrentDate.getFullYear());
								self.body.html(self.generateMonthMarkup(self.dCurrentDate.getFullYear(), self.dCurrentDate.getMonth()));
							}

						}

					return $this.each(function(){

						calendar.init($(this));

					});

				},

				imagesLoaded: function(){

				    var $imgs = this.find('img[src!=""]');

				    if (!$imgs.length) {return $.Deferred().resolve().promise();}

				    var dfds = [];

				    $imgs.each(function(){
				        var dfd = $.Deferred();
				        dfds.push(dfd);
				        var img = new Image();
				        img.onload = function(){dfd.resolve();}
				        img.onerror = function(){dfd.resolve();}
				        img.src = this.src;
				    });

				    return $.when.apply($,dfds);

				}

			});

		},

		showFooter: function(){

			var base = this,
				pW = $('#page_wrap'),
				footer = $('#footer');

			if(!footer.length) return false;

			pW.imagesLoaded().then(function(){

				setTimeout(function(){

					footer.addClass('showed');

				}, 1000);

			});

		},

		mainNavigation: {

			initHorizontalMenu: function(){

				var self = this;
				self.menuType = "H";
				self.pageWrap = $('body');
				self.header = $('#header');
				self.hMenu = $('#horizontal_menu_wrap');
				self.vMenu = $('#vertical_menu_wrap');
				self.w = $(window);

				$('#toggle_menu').on('click.showMenu', {self: self},  self.toggleShowMenu);

				self.bindHMEvents();

			},

			initVerticalMenu: function(){

				var self = this;
				self.menuType = "V";
				self.pageWrap = $('body');
				self.header = $('#header');
				self.hMenu = $('#horizontal_menu_wrap');
				self.vMenu = $('#vertical_menu_wrap');
				self.w = $(window);

				$('#toggle_menu').on('click.showMenu', {self: self},  self.toggleShowMenu);

				self.bindVMEvents();
			},

			bindVMEvents: function(){

				var self = this;

				self.vMenu.on('click.vmenu', 'a', {self: self}, self.linkEventHandler);

				self.vMenu.on('click.menuFocusOut', function(event){

					if(event.pageX < self.vMenu.offset()[Core.ISRTL ? 'right' : 'left']) {
						$('#toggle_menu').data('icon-object').toggle(true);
						self.pageWrap.removeClass('menu_opened');
						self.vMenu.removeClass('opened');
					}

				});

			},

			bindHMEvents: function(){

				var self = this;

				if(Core.ISTOUCH){
					self.hMenu.on('click.hmenuResponsive', 'a', {self: self}, self.linkEventHandler);
				}

				$(document).on('click.menuFocusOut', function(event){

					if($(event.target).closest(self.hMenu.selector).length) return;

					if(Core.TRANSITIONSUPPORTED && self.w.width() > 767){
						self.hMenu.find('.active')
							.removeClass("active")
							.children("a")
							.removeClass("prevented");
					}
					else{
						self.hMenu.find('.active')
							.removeClass("active")
							.children("a")
							.removeClass("prevented")
							.siblings('.submenu')
							.stop()
							.slideUp();
					}

				});

				self.checkMobile(self);

				$(window).on('resize.mobile', function(){
					self.checkMobile(self);
				});

			},

			toggleShowMenu: function(event){

				var self = event.data.self;

				if(self.menuType == "V"){

					self.pageWrap.toggleClass('menu_opened');
					self.vMenu.toggleClass('opened');
					setTimeout(function(){
						if(self.vMenu.hasClass('opened')) self.vMenu.addClass('hf');
						else self.vMenu.removeClass('hf');
					}, 50);
				}
				else{

					self.header.toggleClass('menu_opened');
					self.hMenu.toggleClass('opened');
					if(self.w.width() < 768){
						self.hMenu.find('.navigation').slideToggle();
					}
				}

			},

			checkMobile: function(self){

				var self = self,
					menu = self.hMenu.find('.navigation');

				if(self.w.width() < 768 && self.hMenu.hasClass('opened') && menu.is(':hidden')){
					menu.add(menu.find('.active').children('.submenu')).slideDown();
				}
				if(self.w.width() < 768 && !self.hMenu.hasClass('opened') && menu.is(':visible')){
					menu.hide();
				}

				if(!Core.ISTOUCH){
					if(self.w.width() < 768){
						self.hMenu.on('click.horizontalMobile', 'a', {self: self}, self.linkEventHandler);
					}
					else{
						self.hMenu.off('click.horizontalMobile');
					}
				}

			},

			linkEventHandler: function(event){

				var $this = $(this),
					self = event.data.self;

				if($this.siblings('.submenu').length){
					event.preventDefault();

					$this
						.siblings('.submenu')
						.stop()
						.slideToggle()
						.end()
						.parent()
						.toggleClass('active')
						.siblings()
						.removeClass('active')
						.children('.submenu')
						.stop()
						.slideUp();
					
				}

			},

			destroyVerticalMenu: function(){

				var self = this;

				if(self.vMenu.hasClass('opened')) $('#toggle_menu').data('icon-object').toggle(true);
				$('#toggle_menu').off('click.showMenu');
				self.vMenu.off('click.vmenu');
				self.vMenu.off('click.menuFocusOut');
				self.hMenu.off('click.horizontalMobile');
				if(self.vMenu.hasClass('opened')){
					self.pageWrap.removeClass('menu_opened');
					self.vMenu.removeClass('opened');
				}

			},

			destroyHorizontalMenu: function(){

				var self = this;

				if(self.hMenu.hasClass('opened')) $('#toggle_menu').data('icon-object').toggle(true);
				$('#toggle_menu').off('click.showMenu');
				self.hMenu.off('click.hmenuResponsive');
				self.hMenu.off('click.horizontalMobile');
				$(document).off('click.menuFocusOut');
				if(self.hMenu.hasClass('opened')){
					self.header.removeClass('menu_opened');
					self.hMenu.removeClass('opened');
				}
			}

		},

		events: {

			closeButton: function(){

				$('.close').on('click', function(e){

					e.preventDefault();

					$(this).parent().stop().animate({
						'opacity': 0
					}, function(){
						$(this).slideUp(function(){
							$(this).remove();
						});
					});

				});

			},

			actions: function(){

				$('body').on('click.all', '.share', function(){

					$(this).toggleClass('active');

				});

				// like

				$('body').on('click.like', '.like_btn', function(){

					var $this = $(this),
						icons = $this.children(),
						isLiked = $this.hasClass('active'),
						val = $this.data('amount');

					if(isLiked){
						$this.removeClass('active');
						--val;
						icons.not('.liked').attr('data-amount', val);
					}
					else{
						$this.addClass('active');
						++val;
						icons.not('.not_liked').attr('data-amount', val);
					}

					$this.data('amount', val);

				});

				$('.play_pause_action_wrap').on('click', '.action_btn', function(e){
					$(this).parent().toggleClass('active');
				});

			},

			animationBox: function(){

				$('.toggle_box').on('click', function(e){

					var $this = $(this),
						box = $this.next('.animation_box');

					// if($this.hasClass('si-icon')){
					// 	$this.data('icon-object').toggle(true);
					// }

					if(!box.hasClass('roll_in')){
						box.removeClass('roll_out').addClass('roll_in');	
					}else{
						box.removeClass('roll_in').addClass('roll_out');
					}

				});

			},

			toggleViewFullScreen: function(){

				var action = $('#toggle_view_fullscreen'),
					hideCollection = $('#header, #footer, .gallery_slide_data, .page_actions > li:not(.fs_stay),.slide_title, .slide_desc'),
					moveCollection = $('.slide_title, .slide_desc, .page_actions > li'),
					thumbs = $('.tp-thumbs');

				action.on('click', function(event){

					hideCollection.toggleClass('fs_hide');

					if(revSlider !== undefined){

						if(hideCollection.hasClass('fs_hide') && moveCollection.hasClass('over_thumbs')){
							moveCollection.removeClass('over_thumbs');
							thumbs.removeClass('active');
						}

					}

				});

			},

			cookieControl: function(){

				var $cookie = $('.cookie_control');

				$cookie.on('click', '.accept', function(e){

					e.preventDefault();

					$cookie.fadeOut(700);

				});

			},

			jItemsTouchHover: function(){

				var body = $('body');

				$('.md_touch .inner_j_item').on('click', '.overlay_link', function(e){

					var $this = $(this);

					$this.closest('.inner_j_item').parent().siblings().find('.overlay_link').removeClass('prevented');

					if(!$this.hasClass('prevented')){
						e.preventDefault();
						$this.addClass('prevented');
					}

				});

			}

		},

		albums: {

			init: function(){

				$('body').on('mouseenter.album', '.album_item', {self: this}, this.startSlideshow);
				$('body').on('mouseleave.album', '.album_item', {self: this}, this.stopSlideshow);

			},

			startSlideshow: function(event){

				var $this = $(this),
					album = $this.find('.album'),
					self = event.data.self;

				self.len = album.children().length - 1;
				self.intervalId = setInterval(self.slideshow.bind(album, self), 1500);

			},

			slideshow: function(self){

				var active = this.children('.active'),
					index = active.index(),
					nextItem;

				active.stop().animate({
					opacity: 0
				}, 1000, function(){
					$(this).removeClass('active');
				});

				if(index == self.len) nextItem = active.siblings(':eq(0)');
				else nextItem = active.next();

				nextItem.stop().animate({
					opacity: 1
				}, 1000, function(){
					$(this).addClass('active');
				});

			},

			stopSlideshow: function(event){
				
				var self = event.data.self;
				clearTimeout(self.intervalId);

			}

		},

		components: {

			progressBarsFill: function(){

				var w = $(window),
					wH = w.height();


				$('.progress_bar').each(function(i){

					var $this = $(this),
						val = $this.data('finish-value'),
						bar = $this.children('span'),
						offsetY = $this.offset().top - wH / 2;

					$this.attr('data-finish-value', 0);

					w.on('scroll.progressbars', function(i){

						if($this.data('animated')) return false;

						if(w.scrollTop() + wH >= offsetY){

							Core.helpers.counter.call($this, 0, val, 'data-finish-value');

							bar.animate({

								width: val + '%'

							},500, function(){

								$this.data('animated', true);

								if(i == $this.parent().find('.progressbars').length - 1){
									w.off('scroll.progressbars');
								}

							});

						}

					});

				});

			},

			statisticCounters: function(){

				var c = $('.counter'),
					w = $(window),
				 	wH = w.height(),
				 	len = c.length;

				$('.counter').each(function(i){

					var $this = $(this),
						val = $this.data('amount'),
						offsetY = $this.offset().top - wH / 2;

					$this.attr('data-amount', 0);

					$(window).on('scroll.counters', function(){

						if(w.scrollTop() + wH >= offsetY){

							Core.helpers.counter.call($this, 0, val, 'data-amount');

							if(i == len - 1) w.off('scroll.counters'); 

						}

					});

				});

			},

			subscribeForm: {

				init: function(){

					this.f = $('.subscribe');

					this.f.on('submit', { obj: this }, this.eventHandler);

				},

				eventHandler: function(event){

					event.preventDefault();

					if($(this).hasClass('informed')) return false;

					var obj = event.data.obj;

					$.ajax({
						url: 'php/subscribe.php',
						type: 'post',
						data: $(this).serialize(),
						success: function(data){
							obj.showMessage(data); 
						}
					});

				},

				showMessage: function(data){

					var type = data.indexOf("success") != -1 ? 'success' : 'error',
						template = $("<div class='alert_box j_hide "+type+"'>"+data+"</div>"),
						f = this.f;

					if(type === "success") f.find('input').val("");

					f.addClass('informed');
					template.appendTo(f).slideDown(function(){
						$(this)
							.delay(4000)
							.slideUp(function(){
								f.removeClass('informed');
								$(this).remove();
							});
					});

				}

			},

			contactForm: {

				init: function(){

					var self = this;

					self.cF = $('.contactform');


					self.cF.on("submit", { obj: this }, self.eventHandler);

				},

				eventHandler: function(event){

					event.preventDefault();

					var self = event.data.obj,
						$this = $(this);

					if(!self.clientValidation($this) || self.cF.hasClass('informed')) return false;

					$.ajax({
						url: 'php/contact-send.php',	
						type: 'post',
						data: $this.serialize(),
						success: function(data){

							var type = data.indexOf("success") != -1 ? 'success' : 'error';
							self.showMessage(data, type);
							
						}
					});

				},

				clientValidation: function(form){

					var self = this,
						collection = form.find('[required]'),
						minCCollection = form.find('[data-min-characters]'),
						message = "";

					collection.each(function(i, el){
						if($(el).val() == ""){
							message += "All required fields must be filled! <br>";
							return false;
						}
					});

					minCCollection.each(function(i, el){
						message += self.minCharacters($(el));
					});

					if(message !== ""){
						self.showMessage(message, 'error');
					}

					return message === "";
				},

				minCharacters: function(el){

					var amount = el.data('min-characters');

					return el.val().length < amount ? '"'+el.data('field-name') + '"  field should contain minimum '+amount+' characters!' + "<br>" : "";

				},

				showMessage: function(data, type){

					var template = $("<div class='alert_box j_hide "+type+"'>"+data+"</div>"),
						f = this.cF;

					if(type === "success") f.find('input, textarea').val("");

					f.addClass('informed');
					template.appendTo(f).slideDown(function(){
						$(this)
							.delay(4000)
							.slideUp(function(){
								f.removeClass('informed');
								$(this).remove();
							});
					});

				}

			},

			/**
			** product raring
			**/
			productRating : function(){

				$('.rating').each(function(){

					$(this).append("<div class='empty_state'><i class='icon-star-empty'></i><i class='icon-star-empty'></i><i class='icon-star-empty'></i><i class='icon-star-empty'></i><i class='icon-star-empty'></i></div><div class='fill_state'><i class='icon-star'></i><i class='icon-star'></i><i class='icon-star'></i><i class='icon-star'></i><i class='icon-star'></i></div>");

					var $this = $(this),
						rating = $this.data("rating"),
						fillState = $this.children('.fill_state'),
						w = $this.outerWidth();

					fillState.css('width', rating / 5 * w);

				});

			},

			qty : function(){

				$('body').on('click.quantity','.quantity [data-qty-direction]', function(){

					var $this = $(this),
						d = $this.data('qty-direction'),
						input = $this.siblings('input'),
						c = +input.val();

					if(c == 1 && d == "minus") return;

					input.val(d == "minus" ? --c : ++c);

				}).on('keydown.qty','.quantity input', function(event){

					var kC = event.keyCode;

					if( !((kC >= 48 && kC <= 57) || (kC >= 96 && kC <= 105) || kC == 8) ) event.preventDefault();

				});

			},

			protectedForm: {

				container: $('.protected_form'),

				init: function(){

					this.container.on('submit', {self: this}, this.handler);

				},

				handler: function(event){

					var self = event.data.self;

					event.preventDefault();

					if(self.container.hasClass('informed')) return false;

					if($(this).find('input').val() === '123') window.location.href = 'galleries_flow.html';
					else self.showMessage('Your password is incorrect!', 'error')

				},

				showMessage: function(data, type){

					var template = $("<div class='alert_box j_hide "+type+"'>"+data+"</div>"),
						f = this.container;

					f.addClass('informed');
					template.appendTo(f).slideDown(function(){
						$(this)
							.delay(4000)
							.slideUp(function(){
								f.removeClass('informed');
								$(this).remove();
							});
					});

				}

			},

			beforeAfter: function(){

				$('.before_after_wrap').each(function(){
					var $this = $(this),
						after = $this.find('.after_img'),
						divider = $this.find('.ba_divider');

					after.width($this.width()/2);
					divider.css('left', ($this.width()/2)+'px');
				});

				$('.before_after_wrap').mousemove(function(e){

					var $this = $(this),
						offset = $this.offset().left,
						pageX = e.pageX-offset,
						after = $this.find('.after_img'),
						divider = $this.find('.ba_divider');

					after.width(pageX);
					divider.css('left', pageX+'px');

				});	

			},

			flowCarousel: function(){

				var whaterWheel = jQuery("#whaterwheel"),
					allSize = jQuery('.ww_block').size();

					var window_w = $(window).width(),
						window_h = $(window).height(),
						header = $('#header'),
						carouselWrap = $('.flow_carousel_wrap'),
						slideData = $('#gallery_slide_data'),
						title = slideData.children('.slide_caption'),
						desc = slideData.children('.slide_description');

				if(!carouselWrap.length) return false;


				setupWW();

				jQuery('.ww_link').click(function(){
					setSlide(parseInt(jQuery(this).attr('data-count')))
				});

				jQuery(document.documentElement).keyup(function (event) {
					if ((event.keyCode == 37) || (event.keyCode == 40)) {
						prev_ww();
					// Right Arrow or Up Arrow
					} else if ((event.keyCode == 39) || (event.keyCode == 38)) {
						next_ww();
					}	
				});

				jQuery('#ww_finger').on("swipeleft",function(){
					next_ww();
				});
				jQuery('#ww_finger').on("swiperight",function(){
					prev_ww();
				});

				whaterWheel.on('mousewheel', function(e){

					if (e.deltaY<0) {
				 	    next_ww();
				    } else {
				    	prev_ww();
				    }
				    e.preventDefault();

				});
	           
				function next_ww() {
					"use strict";
					var cur_slide = parseInt(jQuery('.curr').attr('data-count'));
					cur_slide++;
					if (cur_slide > allSize) cur_slide = 1;
					if (cur_slide < 1) cur_slide = allSize;
					setSlide(cur_slide);
				}
				function prev_ww() {
					"use strict";
					var cur_slide = parseInt(jQuery('.curr').attr('data-count'));
					cur_slide--;
					if (cur_slide > allSize) cur_slide = 1;
					if (cur_slide < 1) cur_slide = allSize;
					setSlide(cur_slide);
				}
				
				jQuery(window).load(function (){
					"use strict";
					setTimeout(setupWW,600);
				});
				jQuery(window).on('resize.flow_carousel', function (){
					"use strict";
					whaterWheel.find('*').removeAttr('style');
					setTimeout(setupWW,1000, true);
					carouselWrap.addClass('size_changing');
					setTimeout(function(){
						carouselWrap.removeClass('size_changing');
					}, 1500);
				});
				
				var atr056 = 0,
					atr078 = 0,
					atr_main = 1,
					attrH = 0.7,
					attrMT = 0.15,
					attrMB = 0.15;
				function setSlide(cur) {
					"use strict";
					if (window_w > 1025) {
						whaterWheel.find('img').unreflect();
					}
					if (window_w > 960) {
						atr056 = 0.56;
						atr078 = 0.78;
						atr_main = 1;
					} else if (window_w > 760 && window_w < 960){
						atr056 = 0.37;
						atr078 = 0.56;
						atr_main = 0.75;
					} else if (window_w < 760){
						atr056 = 0.3;
						atr078 = 0.5;
						atr_main = 0.75;
					}
					jQuery('.prev2').removeClass('prev2');
					jQuery('.prev').removeClass('prev');
					jQuery('.curr').removeClass('curr');				
					jQuery('.next').removeClass('next');
					jQuery('.next2').removeClass('next2');
					jQuery('#ww_block'+cur).addClass('curr');
					if (whaterWheel.hasClass('type5')) {
						if((cur+1) > allSize) {
							jQuery('#ww_block1').addClass('next');
							jQuery('#ww_block2').addClass('next2');
						} else if ((cur+1) == allSize){
							jQuery('#ww_block'+allSize).addClass('next');
							jQuery('#ww_block1').addClass('next2');					
						} else {
							jQuery('#ww_block'+(cur+1)).addClass('next');
							jQuery('#ww_block'+(cur+2)).addClass('next2');				
						}
						if((cur-1) < 1) {
							jQuery('#ww_block'+allSize).addClass('prev');
							jQuery('#ww_block'+(allSize-1)).addClass('prev2');
						} else if ((cur-1) == 1){					
							jQuery('#ww_block1').addClass('prev');
							jQuery('#ww_block'+allSize).addClass('prev2');
						} else {
							jQuery('#ww_block'+(cur-1)).addClass('prev');
							jQuery('#ww_block'+(cur-2)).addClass('prev2');
						}
					}

					var curr = whaterWheel.find('.curr');

					jQuery('.prev2').css('margin-left', -1*(curr.width()/2)-curr.width()*atr078/1.333-curr.width()*atr056/1.333);
					jQuery('.prev').css('margin-left', -1*(curr.width()/2)-curr.width()*atr078/1.333);
					curr.css('margin-left', -1*(curr.width()/2));
					jQuery('.next').css('margin-left' , -1*(curr.width()/2)+curr.width()*atr078/1.333);
					jQuery('.next2').css('margin-left' , -1*(curr.width()/2)+curr.width()*atr078/1.333+curr.width()*atr056/1.333);

					
					slideData.addClass('changing');
					setTimeout(function(){
						title.text(jQuery('.curr').attr('data-title'));
						desc.text(jQuery('.curr').attr('data-description'));
						slideData.removeClass('changing');
					},300);					
					if (window_w > 1025) {
						whaterWheel.find('img').reflect({height:0.24,opacity:0.25});
						whaterWheel.find('canvas').each(function(){
							jQuery(this).width(jQuery(this).prev('img').width());
						});
					}
				}
				function setupWW(changeSize) {
					"use strict";

					window_w = $(window).width();
					window_h = $(window).height();
					whaterWheel.find('img').unreflect();
					if (window_w > 1025) {
						whaterWheel.find('img').unreflect();
						attrH = 0.6;
						attrMT = 0.2;
						attrMB = 0.2;
					}
					else if (window_w > 960) {
						atr056 = 0.56;
						atr078 = 0.78;
						atr_main = 1;
						attrH = 0.7;
						attrMT = 0.15;
						attrMB = 0.15;
						
					} else if (window_w > 760 && window_w < 960){
						atr056 = 0.37;
						atr078 = 0.56;
						atr_main = 1;
						attrH = 0.6;
						attrMT = 0.2;
						attrMB = 0.2;
					} else if (window_w < 760){
						atr056 = 0.3;
						atr078 = 0.5;
						atr_main = 0.75;
					}

					var setHeight = (window_h-jQuery('#footer').outerHeight() - jQuery('.slide_caption_wrap').outerHeight() + 80 -1)*atr_main;
					var setWidth = window_w - parseInt(whaterWheel.css('padding-left')) - parseInt(whaterWheel.css('padding-right'));
					
					whaterWheel.width(setWidth).css({'margin-top' : setHeight*attrMT, 'margin-bottom' : setHeight*attrMB});
					
					whaterWheel.height((window_h-jQuery('#footer').outerHeight() - jQuery('.slide_caption_wrap').outerHeight() + 80)*attrH);
					if (jQuery('.curr').size() < 1) {
						if (whaterWheel.find('.ww_block').size() > 4) {
							whaterWheel.addClass('type5');
							jQuery('#ww_block1').addClass('prev2');
							jQuery('#ww_block2').addClass('prev');
							jQuery('#ww_block3').addClass('curr');
							jQuery('#ww_block4').addClass('next');
							jQuery('#ww_block5').addClass('next2');				
						} else if (whaterWheel.find('.ww_block').size() > 2) {
							whaterWheel.addClass('type3');
							jQuery('#ww_block1').addClass('prev');
							jQuery('#ww_block2').addClass('curr');
							jQuery('#ww_block3').addClass('next');				
						} else if (whaterWheel.find('.ww_block').size() == 2) {
							whaterWheel.addClass('type2');
							jQuery('#ww_block1').addClass('curr');
							jQuery('#ww_block2').addClass('next');
						} else if (whaterWheel.find('.ww_block').size() == 1) {
							whaterWheel.addClass('type1');
							jQuery('#ww_block1').addClass('curr');
						}
					}

					var curr = whaterWheel.find('.curr');
					jQuery('.prev2').css('margin-left', -1*(curr.width()/2)-curr.width()*0.78/1.333-curr.width()*0.56/1.333);
					jQuery('.prev').css('margin-left', -1*(curr.width()/2)-curr.width()*0.78/1.333);
					curr.css('margin-left', -1*(curr.width()/2));
					jQuery('.next').css('margin-left' , -1*(curr.width()/2)+curr.width()*0.78/1.333);
					jQuery('.next2').css('margin-left' , -1*(curr.width()/2)+curr.width()*0.78/1.333+curr.width()*0.56/1.333);
					title.text(jQuery('.curr').attr('data-title'));
					desc.text(jQuery('.curr').attr('data-description'));
					if (window_w > 1025) {
						whaterWheel.find('img').reflect({height:0.24,opacity:0.25});
						whaterWheel.find('canvas').each(function(){
							jQuery(this).width(jQuery(this).prev('img').width());
						});
					}

				}

			}

		},

		initializeSVGIcons: function(){

			$('.si-icon').each(function(i, el){

				var iconData = $(el).data();

				if(!$(el).data('initialized')){

					$(el).data('initialized', true);

					$(el).data('icon-object',new svgIcon(el, svgIconConfig, { size: { w: iconData.width, h: iconData.height}, evtoggle: iconData.event }));

				}

			});

			$('.si-icon[data-event="click"]').on('click', function(){
				$(this).data('icon-object').toggle(true);
			});

		},

		helpers: {

			counter: function(from, to, toAttribute){

				var $this = this;

				var interval = setInterval(function(){

					if(toAttribute) $this.attr(toAttribute, ++from);

					if(from == to) clearInterval(interval);

				}, 4);

			},

			fancyboxValidate: function(){

				$('.fancybox').each(function(){
					$(this).attr('rel', $(this).attr('data-rel'));
				});

			},

			prepareExtendedBlock: function(){
				var eW = $('.extended_wrap[data-image-url]');

				eW.css('background-image', 'url("' + eW.data('image-url') + '")');

				var tH = {

					init: function(){

						var self = this;

						self.h = $('#header');

						if(!$('.extended_wrap').length) return false;

						self.hH = self.h.outerHeight();
						self.pW = $('#page_wrap');
						self.offsetT = self.pW.offset().top;
						self.w = $(window);

						self.w.on('scroll.filled', {self : self}, self.scrollEvent);
						self.w.on('resize.updateProperties', {self: self}, self.updateProperties);

					},

					scrollEvent: function(event){

						var self = event.data.self;

						if(self.w.scrollTop() + self.hH > self.offsetT && !self.h.hasClass('filled')){
							self.h.addClass('filled');
						}
						else if(self.w.scrollTop() + self.hH < self.offsetT && self.h.hasClass('filled')){
							self.h.removeClass('filled');
						}

					},

					updateProperties: function(event){

						var self = event.data.self;

						self.offsetT = self.pW.offset().top;

					}

				}

				tH.init();

			},

			fullWidthBlocks: function(){

				var fW = $('.full_width');

				fW.on('generate.columns', function(){

					var $this = $(this),
						wW = $('body').width(),
						iW = 370, // average width
						items = $this.children();

					var firefox = navigator.userAgent.toLowerCase().indexOf('firefox') > -1;
					var nth = wW % iW > 45 ? Math.ceil(wW / iW) : Math.floor(wW / iW);

					items.css('width', 'auto');

					items.css('width', (firefox ? (100 / nth).toString().substring(0,4) : 100 / nth) + '%');

				});

				fW.trigger('generate.columns');

				$(window).on('resize.fullWidthcolumns', function(){
					fW.trigger('generate.columns');
				});

			},

			prepareOwlControls: function(){

				$('.owl_carousel').each(function(){

					var $this = $(this);

					if($this.data('binded')) return;

					$this.on('mousewheel', '.owl-stage', function(e){

						if (e.deltaY<0) {
					        $this.trigger('next.owl.carousel');
					    } else {
					        $this.trigger('prev.owl.carousel');
					    }
					    e.preventDefault();

					});

					$this.data('binded', true);

					$(document).on('keypress.owl', function(event){

						if(event.keyCode === 37) $this.trigger('prev.owl.carousel');
						else if(event.keyCode === 39) $this.trigger('next.owl.carousel');

					});

					// custom controls with SVG icons

					$this.siblings('.owl-prev').on('click', function(e){
						$this.trigger('prev.owl.carousel');
					});

					$this.siblings('.owl-next').on('click', function(e){
						$this.trigger('next.owl.carousel');
					});

				});

			},

			fullScreenView: function(){

				var w = $(window),
					fs = $('.full_screen_container'),
					pW = $('#page_wrap:not(.tilt_container)'),
					h = $('#header'),
					f = $('#footer'),
					pWT = $('#page_wrap.tilt_container');

				fs.add(pWT).on('setWindowHeight', function(){

					var wH = w.height();
					$(this).css('height', wH);

				});

				fs.add(pWT).trigger('setWindowHeight');

				w.on('resize.fullScreenView', function(){
					fs.add(pWT).trigger('setWindowHeight');
				});

			},

			revolutionSliderEvents: function(){

				if(!revSlider) return false;

				var thumbs = $('.tp-thumbs'),
					moveCollection = $('.slide_title, .slide_desc, .page_actions > li');

				revSlider.on('mousewheel', function(e){

					if (e.deltaY<0) {

						if(window.ISRTL) revSlider.revprev();	
						else revSlider.revnext();

				    } else {

				        if(window.ISRTL) revSlider.revnext();	
						else revSlider.revprev();
				    }
				    e.preventDefault();

				});

				 $('#rs_prev').on('click', function(){

				 	revSlider.revprev();

				 });

				 $('#rs_next').on('click', function(){
				 	
				 	revSlider.revnext();

				 });

				$('#rs_pause').on('click', function(){

					revSlider.revpause();

				});

				$('#rs_play').on('click', function(){

				 	revSlider.revresume();

				});

				 $('#rs_show_thumbs').on('click', function(){
				 	
				 	thumbs.toggleClass('active');
				 	moveCollection.toggleClass('over_thumbs');


				 });

			},

			documentHeightFix: function(){

				var doc = $(document),
					dW = $('#document_wrap'),
					w = $(window),
					pW = $('#page_wrap:not(.tilt_container)'),
					pwPB = parseInt(pW.css('padding-bottom'));

				function checkHeight(){

					var diff = doc.height() - dW.outerHeight();

					if(diff > 0) pW.css('padding-bottom', pwPB + diff );

				}

				checkHeight();

				pW.imagesLoaded().then(function(){

					setTimeout(function(){

						var isotope = $('[class*="isotope_container"]');

						checkHeight();

						if (isotope.length) {
							$(window).trigger('scroll.loadMoreItems');
						}

					}, 1000);

				});

				$(window).on('resize.documentHeight', checkHeight);

			},

			mobileSticky: function(){

				var $body = $('body'),
					$header = $('#header'),
					$w = $(window),
					$pw = $('#page_wrap'),
					$offset = $pw.hasClass('fullscreen') ? 0 : 20;

				if(!$body.hasClass('sticky_mobile')) return;

				$body.on('offset.sticky', function(){

					if($w.width() < 768){
						$header.next().css('padding-top', $header.outerHeight() + $offset);
					}
					else{
						if($pw.hasClass('fullscreen')){
							$header.next().css('padding-top', 0);
						}
					}

				});

				$body.trigger('offset.sticky');

				$w.on('resize.sticky_mobile', function(){
					$body.trigger('offset.sticky');
				});

			}

		},

		flickrFeed: function(){

			// flickr 
	
			var flickr = $('.flickr_feed');

			flickr.each(function(){

				var self = $(this),
					options = self.data('flickr-options'),config,defaults,
					rel = self.data('flickr-gallery');
				

				defaults = {
					flickrbase:'http://api.flickr.com/services/feeds/',
					feedapi:'photos_public.gne',
					limit: 6,
					qstrings:{lang:'en-us',format:'json',jsoncallback:'?'},
					cleanDescription:true,
					useTemplate:true,
					itemTemplate: '<li><a rel="'+rel+'" title="{{title}}" href="{{image}}" class="fancybox"><img alt="" src="{{image_s}}"/></a></li>',
					itemCallback:function(){}
				}

				config = $.extend(defaults, options);

				self.jflickrfeed(config,function(data){
					self.find('.fancybox').fancybox();
				});

			});

		},

		dribbbleFeed: function(){

			var dribbble = $('.dribbble_feed');

			dribbble.each(function(){

				var $this = $(this),
					user = $this.data('dribbble-user'),
					rel = $this.data('dribbble-gallery'),
					html = "";

				var callback = function (playerShots) {

		            $.each(playerShots.shots, function (i, shot) {
		                html += '<li><a class="fancybox" rel="'+ rel +'" href="' + shot.image_url + '" title="'+ shot.title +'"><img src="' + shot.image_url + '" alt=""></a></li>';
		            });

		            $this.html(html).find('.fancybox').fancybox();
		        };

				$.jribbble.getShotsByPlayerId(user, callback, {page: 1, per_page: 4});

			});

		},

		isotope : {

			init: function(){

				this.container = $('[class*="isotope_container"]');

				if(!this.container.length) return;

				this.wH = $(window).height();

				this.pageType = this.container.data("page-type");
				this.url = this.container.data('url');
				this.maxPosts = this.container.data('max-request-posts');
				this.currentAmountOfPosts = this.container.find('.isotope_item').length;

				this.setTransitionDelay();

				if(this.container.data('page-type') == undefined) return;

				this.initFilter(this);
				this.bindScrollEvent();

				$(window).on('resize.updateDocumentInfo', { self: this } , this.updateDocumentInfo);

			},

			setTransitionDelay: function(){
			
				var self = this,
					items = self.container.children('.isotope_item').children();

				items.each(function(i, el){

					$(el)[0].style.transitionDelay = i / 20 + 's';

				}).promise().done(self.initialize.bind(self));

			},

			initialize: function(){

				var self = this,
					container = self.container,
					isMasonry = container.data('masonry');

				container.isotope({
					itemSelector: '.isotope_item',
					layoutMode: isMasonry ? 'masonry' : 'fitRows',
					transitionDuration: '.7s',
					isOriginLeft: Core.ISRTL ? false : true,
					hiddenStyle: {
						opacity: 0
					},
					visibleStyle : {
						opacity: 1
					}
				});

				container.isotope('on', 'layoutComplete', function(){

					var appended = container.find('.isotope_item.appended').children();

					container.addClass('loaded');

					appended.addClass('appended_item');

					if(Core.TRANSITIONSUPPORTED){
						appended.on(Core.TRANSITIONEND, function(){
							$(this).parent().addClass('loaded');
						});
					}
					else{
						appended.parent().addClass('loaded');
					}

					if(!container.hasClass('filtered')) container.filter('.full_width').trigger('generate.columns');

				});

				container.isotope('layout');

			},

			initFilter: function(self){

				var filter = $('#filter'),
					filterBtn = $('#filter_btn'),
					fW = $('#filter_wrap');

				filter.on( 'click', '[data-filter]', function() {

					$(this).addClass('active').siblings().removeClass('active');

					var filterValue = $(this).data('filter');
					self.container.isotope({ filter: filterValue });

					self.container[filterValue == "*" ? 'removeClass' : 'addClass']('filtered');

				});

				$(document).on('click.filterFocusOut', function(event){

					if($(event.target).closest(fW).length) return;

					if(filter.hasClass('roll_in')){
						filterBtn.data('icon-object').toggle(true);
						filter.removeClass('roll_in').addClass('roll_out');
					}

				});


			},

			updateDocumentInfo: function(event){

				var self = event.data.self;

				setTimeout(function(){

					self.wH = $(window).height();
					if(!self.container.hasClass('all_posts_loaded')) self.bindScrollEvent();

				}, 700);

				if(self.pageType == "blog"){

					setTimeout(function(){
						self.container.isotope('layout');
					},300);

				}

			},

			bindScrollEvent: function(){

				var self = this,
					w = $(window),
					wH = self.wH / 2.25,
					container = self.container,
					offsetY = container.offset().top + container.outerHeight() - wH;

				container.removeClass("scrolled");

				w.off('scroll.loadMoreItems');

				w.on("scroll.loadMoreItems", function(){

					var scrollT = w.scrollTop() + wH;

					if(scrollT >= offsetY && !container.hasClass('scrolled')){
						container.addClass('scrolled');
						self.loadMore();
					}

				});

			},

			loadMore: function(isFirstLoad){

				var self = this,
					container = self.container;

				$.ajax({
					url: self.url,
					dataType: 'json',
					success: function(data){
						self.appendNewItems(data.items,isFirstLoad);
					},
					cache: false
				});

			},

			appendNewItems: function(data,isFirstLoad){

				var self = this,
					newItems = [];

				$.each(data, function(i, obj){

					var item = self.generateTemplate(self.pageType, obj);

					if(isFirstLoad) i = i - 10 + self.container.find('.isotope_item').length;

					item.children()[0].style.transitionDelay = (i + 10) / 20 + 's';

					newItems.push(item);

					self.currentAmountOfPosts++;

					if(self.currentAmountOfPosts >= self.maxPosts){
						self.container.addClass('all_posts_loaded');
						return false;
					}

				});

				self.container.append(newItems);

				// slideshow post type

				if(self.pageType == 'blog'){

					self.container.find('.owl_carousel:not(.owl-loaded)').owlCarousel({
						animateOut: 'slideOutLeft',
						animateIn: 'flipInX',
						items: 1,
						smartSpeed: 300,
						loop: true,
						nav: true,
						dots: false,
						navText: [],
						autoHeight: true,
						rtl: window.ISRTL
					});

				}

				self.container.isotope('appended', self.container.find('.isotope_item:not([style])'));

				self.container.imagesLoaded().then(function(){

					console.log('images was loaded');
					self.container.isotope('layout');


					if(self.container.hasClass('all_posts_loaded')){
						$(window).off('scroll.loadMoreItems');
						return false;
					}
					else{
						self.bindScrollEvent();
					}

					Core.helpers.prepareOwlControls();
					Core.initializeSVGIcons();

					
					addthis.toolbox('.addthis_toolbox');
					var script = 'http://s7.addthis.com/js/250/addthis_widget.js#domready=1';
					if (window.addthis) {
						window.addthis = null;
						window._adr = null;
						window._atc = null;
						window._atd = null;
						window._ate = null;
						window._atr = null;
						window._atw = null;
					}
					$.getScript(script);

				});
				
			},

			generateTemplate: function(pageType, obj){

				var item = $('<div></div>', {
					class: 'isotope_item appended ' + obj.category
				});

				item.append(this.jItems.call(obj, obj.layoutType, pageType));

				return item;
			},

			jItems: function(layoutType, pageType){

				var index,
					self = this;

				if(pageType == "portfolio" || pageType == "gallery"){

					switch(layoutType){
						case 1 :
						case 5: 
							index = 0;
						break;
						case 2:
						case 3:
						case 4: 
							index = 1;
						break;
						// gallery wall items
						case 6: // wall item type 1
							layoutType = 1;
							index = 2;
						break;
						case 7: // wall item type 2
							layoutType = 2;
							index = 2;
						break;
						case 8: // wall iten type 3
							layoutType = 3;
							index = 2;
						break;
						case 10: // wall item type 5
							layoutType = 5;
							index = 2;
						break;
						case 9:
							layoutType = 4; // wall item type 4
							index = 3;
						break;
					}

					if(pageType === "gallery" && self.images){
						var album = "";

						$.each(self.images, function(i, obj){
							var active = "";
							if(i == 0) active = "active";

							album += "<li class="+active+"><img src=" + obj + " alt='' /></li>";

						});

					}

					var wallItemLink = self.videoLink ? self.videoLink : self.lightBoxImage,
						wallItemClass = self.iconType == "video" ? 'fancybox_media' : 'fancybox';

					var portfolioLayouts = [

						"<div class='inner_j_item item_type_" + layoutType +"'>\
							<img class='item_image' src='"+ self.imageSrc +"' alt=''>\
							<a href='"+self.postLink+"' class='overlay_link'></a>\
							<h4 class='title'><a href=" + self.postLink + ">" +self.postTitle+ "</a></h4>\
							<div class='meta'>\
								<div class='category'><a href=" + self.categoryLink + ">"+self.category+"</a></div>\
								<div class='stats'>\
									<span class='sl_wrap'><i class='icon-"+self.statLink1.icon+"'></i><a href='#' class='stat_link'>"+self.statLink1.amount+"</a></span>\
									<span class='sl_wrap'><i class='icon-"+self.statLink2.icon+"'></i><a href='#' class='stat_link'>"+self.statLink2.amount+"</a></span>\
								</div>\
							</div>\
						</div>",

						"<div class='inner_j_item item_type_" + layoutType +"'>\
							<img class='item_image' src='"+ self.imageSrc +"' alt=''>\
							<a href='"+self.postLink+"' class='overlay_link'></a>\
							<div class='meta'>\
								<h4 class='title'><a href=" + self.postLink + ">" +self.postTitle+ "</a></h4>\
								<div class='category'><a href=" + self.categoryLink + ">"+self.category+"</a></div>\
								<div class='stats'>\
									<span class='sl_wrap'><i class='icon-"+self.statLink1.icon+"'></i><a href='#' class='stat_link'>"+self.statLink1.amount+"</a></span>\
									<span class='sl_wrap'><i class='icon-"+self.statLink2.icon+"'></i><a href='#' class='stat_link'>"+self.statLink2.amount+"</a></span>\
								</div>\
							</div>\
						</div>"

					],

					galleryLayouts = [

						"<div class='inner_j_item album_item item_type_" + layoutType +"'>\
							<ul class='album'>"+ album +"</ul>\
							<a href='"+self.postLink+"' class='overlay_link'></a>\
							<h4 class='title'><a href=" + self.postLink + ">" +self.postTitle+ "</a></h4>\
							<div class='meta'>\
								<div class='category'><a href=" + self.categoryLink + ">"+self.category+"</a></div>\
								<div class='stats'>\
									<span class='sl_wrap'><i class='icon-"+self.statLink1.icon+"'></i><a href='#' class='stat_link'>"+self.statLink1.amount+"</a></span>\
									<span class='sl_wrap'><i class='icon-"+self.statLink2.icon+"'></i><a href='#' class='stat_link'>"+self.statLink2.amount+"</a></span>\
								</div>\
							</div>\
						</div>",

						"<div class='inner_j_item album_item item_type_" + layoutType +"'>\
							<ul class='album'>"+ album +"</ul>\
							<a href='"+self.postLink+"' class='overlay_link'></a>\
							<div class='meta'>\
								<h4 class='title'><a href=" + self.postLink + ">" +self.postTitle+ "</a></h4>\
								<div class='category'><a href=" + self.categoryLink + ">"+self.category+"</a></div>\
								<div class='stats'>\
									<span class='sl_wrap'><i class='icon-"+self.statLink1.icon+"'></i><a href='#' class='stat_link'>"+self.statLink1.amount+"</a></span>\
									<span class='sl_wrap'><i class='icon-"+self.statLink2.icon+"'></i><a href='#' class='stat_link'>"+self.statLink2.amount+"</a></span>\
								</div>\
							</div>\
						</div>",

						// wall layouts

						'<div class="wall_j_item type_'+layoutType+'">\
							<a href="'+wallItemLink+'" class="'+wallItemClass+' wall_image '+self.iconType+'" rel="'+self.galleryName+'">\
								<img class="item_image" src="'+self.imageSrc+'" alt="">\
							</a>\
							<div class="stats">\
								<span class="sl_wrap"><i class="icon-'+self.statLink1.icon+'"></i><a href="#" class="stat_link">'+self.statLink1.amount+'</a></span>\
								<span class="sl_wrap"><i class="icon-'+self.statLink2.icon+'"></i><a href="#" class="stat_link">'+self.statLink2.amount+'</a></span>\
							</div>\
						</div>',

						'<div class="wall_j_item type_'+layoutType+'">\
							<a href="'+wallItemLink+'" class="'+wallItemClass+' wall_image" rel="'+self.galleryName+'">\
								<img class="item_image" src="'+self.imageSrc+'" alt="">\
								<span class="transparent_icon '+self.iconType+'">\
									<span class="left_overlay"></span>\
									<span class="right_overlay"></span>\
								</span>\
							</a>\
							<div class="stats">\
								<span class="sl_wrap"><i class="icon-'+self.statLink1.icon+'"></i><a href="#" class="stat_link">'+self.statLink1.amount+'</a></span>\
								<span class="sl_wrap"><i class="icon-'+self.statLink2.icon+'"></i><a href="#" class="stat_link">'+self.statLink2.amount+'</a></span>\
							</div>\
						</div>'

					];
				}
				else if(pageType == "blog"){

					if(self.postType == 'slideshow'){

						var slideshow = '';

						$.each(self.images, function(i, obj){

							slideshow += "<img src=" + obj + " alt='' />";

						});

					}

					switch(self.postType){
						case 'slideshow' :
							index = 0;
						break;
						case 'video' :
							index = 1;
						break;
						case 'audio' :
							index = 2;
						break;
						case 'featured_image' :
							index = 3;
						break;
						case 'blockquote' :
							index = 4;
						break;
						case 'hosted_audio' :
							index = 5;
						break;
						case 'simple_text' :
							index = 6;
						break;
					}

					var blogLayouts = [

						// slideshow post type

						'<article class="entry">\
							<h4 class="entry_title"><a href="'+self.postLink+'">'+self.title+'</a></h4>\
							<div class="entry_meta">In <a href="#">'+self.category+'</a> '+self.created+' by <a href="#">'+self.author+'</a> with <a href="#">'+self.comments+' comments</a></div>\
							<div class="owl_wrap">\
								<div class="slideshow owl_carousel">'+slideshow+'</div>\
								<span class="si-icon action_btn dark large owl-prev" data-width="28" data-height="28" data-event="mouseover" data-icon-name="previous"></span>\
								<span class="si-icon action_btn dark large owl-next" data-width="28" data-height="28" data-event="mouseover" data-icon-name="next"></span>\
							</div>\
							<div class="entry_extra">\
								<p>'+self.extra+'</p>\
							</div>\
							<footer class="footer_extra clearfix">\
								<div class="row table_layout">\
									<div class="col-sm-8">\
										<a href="blog_post_with_extended_image.html" class="btn small black alignleft">Continue Reading</a>\
									</div>\
									<div class="col-sm-4">\
										<div class="actions_wrap">\
											<ul class="actions_list">\
												<li>\
													<div class="share_wrap">\
														<span class="si-icon share action_btn" data-width="21" data-height="21" data-event="click" data-icon-name="social"></span>\
														<div class="addthis_sharing_toolbox"></div>\
													</div>\
												</li>\
												<li>\
													<span class="like_btn" data-amount="97">\
														<span class="si-icon action_btn not_liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likeDark" data-amount="97"></span>\
														<span class="si-icon action_btn liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likedDark" data-amount="97"></span>\
													</span>\
												</li>\
											</ul>\
										</div>\
									</div>\
								</div>\
							</footer>\
						</article>',

						// vimeo vide post type

						'<article class="entry">\
							<h4 class="entry_title"><a href="'+self.postLink+'">'+self.title+'</a></h4>\
							<div class="entry_meta">In <a href="#">'+self.category+'</a> '+self.created+' by <a href="#">'+self.author+'</a> with <a href="#">'+self.comments+' comments</a></div>\
							<div class="iframe_wrap">\
								<iframe src="'+self.videoSrc+'"></iframe>\
							</div>\
							<div class="entry_extra">\
								<p>'+self.extra+'</p>\
							</div>\
							<footer class="footer_extra clearfix">\
								<div class="row table_layout">\
									<div class="col-sm-8">\
										<a href="blog_post_with_extended_image.html" class="btn small black alignleft">Continue Reading</a>\
									</div>\
									<div class="col-sm-4">\
										<div class="actions_wrap">\
											<ul class="actions_list">\
												<li>\
													<div class="share_wrap">\
														<span class="si-icon share action_btn" data-width="21" data-height="21" data-event="click" data-icon-name="social"></span>\
														<div class="addthis_sharing_toolbox"></div>\
													</div>\
												</li>\
												<li>\
													<span class="like_btn" data-amount="97">\
														<span class="si-icon action_btn not_liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likeDark" data-amount="97"></span>\
														<span class="si-icon action_btn liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likedDark" data-amount="97"></span>\
													</span>\
												</li>\
											</ul>\
										</div>\
									</div>\
								</div>\
							</footer>\
						</article>',

						// soundcloud post type

						'<article class="entry">\
							<h4 class="entry_title"><a href="'+self.postLink+'">'+self.title+'</a></h4>\
							<div class="entry_meta">In <a href="#">'+self.category+'</a> '+self.created+' by <a href="#">'+self.author+'</a> with <a href="#">'+self.comments+' comments</a></div>\
							<iframe height="120" src="'+self.soundcloudSrc+'"></iframe>\
							<div class="entry_extra">\
								<p>'+self.extra+'</p>\
							</div>\
							<footer class="footer_extra clearfix">\
								<div class="row table_layout">\
									<div class="col-sm-8">\
										<a href="blog_post_with_extended_image.html" class="btn small black alignleft">Continue Reading</a>\
									</div>\
									<div class="col-sm-4">\
										<div class="actions_wrap">\
											<ul class="actions_list">\
												<li>\
													<div class="share_wrap">\
														<span class="si-icon share action_btn" data-width="21" data-height="21" data-event="click" data-icon-name="social"></span>\
														<div class="addthis_sharing_toolbox"></div>\
													</div>\
												</li>\
												<li>\
													<span class="like_btn" data-amount="97">\
														<span class="si-icon action_btn not_liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likeDark" data-amount="97"></span>\
														<span class="si-icon action_btn liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likedDark" data-amount="97"></span>\
													</span>\
												</li>\
											</ul>\
										</div>\
									</div>\
								</div>\
							</footer>\
						</article>',

						// post with featured image

						'<article class="entry">\
							<h4 class="entry_title"><a href="'+self.postLink+'">'+self.title+'</a></h4>\
							<div class="entry_meta">In <a href="#">'+self.category+'</a> '+self.created+' by <a href="#">'+self.author+'</a> with <a href="#">'+self.comments+' comments</a></div>\
							<img src="'+self.featuredImage+'" alt="">\
							<div class="entry_extra">\
								<p>'+self.extra+'</p>\
							</div>\
							<footer class="footer_extra clearfix">\
								<div class="row table_layout">\
									<div class="col-sm-8">\
										<a href="blog_post_with_extended_image.html" class="btn small black alignleft">Continue Reading</a>\
									</div>\
									<div class="col-sm-4">\
										<div class="actions_wrap">\
											<ul class="actions_list">\
												<li>\
													<div class="share_wrap">\
														<span class="si-icon share action_btn" data-width="21" data-height="21" data-event="click" data-icon-name="social"></span>\
														<div class="addthis_sharing_toolbox"></div>\
													</div>\
												</li>\
												<li>\
													<span class="like_btn" data-amount="97">\
														<span class="si-icon action_btn not_liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likeDark" data-amount="97"></span>\
														<span class="si-icon action_btn liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likedDark" data-amount="97"></span>\
													</span>\
												</li>\
											</ul>\
										</div>\
									</div>\
								</div>\
							</footer>\
						</article>',

						// post with blockquote

						'<article class="entry">\
							<h4 class="entry_title"><a href="'+self.postLink+'">'+self.title+'</a></h4>\
							<div class="entry_meta">In <a href="#">'+self.category+'</a> '+self.created+' by <a href="#">'+self.author+'</a> with <a href="#">'+self.comments+' comments</a></div>\
							<blockquote>\
								<p>'+self.quote+'</p>\
								<div class="author">'+self.quoteAuthor+'</div>\
							</blockquote>\
							<div class="entry_extra">\
								<p>'+self.extra+'</p>\
							</div>\
							<footer class="footer_extra clearfix">\
								<div class="row table_layout">\
									<div class="col-sm-8">\
										<a href="blog_post_with_extended_image.html" class="btn small black alignleft">Continue Reading</a>\
									</div>\
									<div class="col-sm-4">\
										<div class="actions_wrap">\
											<ul class="actions_list">\
												<li>\
													<div class="share_wrap">\
														<span class="si-icon share action_btn" data-width="21" data-height="21" data-event="click" data-icon-name="social"></span>\
														<div class="addthis_sharing_toolbox"></div>\
													</div>\
												</li>\
												<li>\
													<span class="like_btn" data-amount="97">\
														<span class="si-icon action_btn not_liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likeDark" data-amount="97"></span>\
														<span class="si-icon action_btn liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likedDark" data-amount="97"></span>\
													</span>\
												</li>\
											</ul>\
										</div>\
									</div>\
								</div>\
							</footer>\
						</article>',

						// hosted audio post type

						'<article class="entry">\
							<h4 class="entry_title"><a href="'+self.postLink+'">'+self.title+'</a></h4>\
							<div class="entry_meta">In <a href="#">'+self.category+'</a> '+self.created+' by <a href="#">'+self.author+'</a> with <a href="#">'+self.comments+' comments</a></div>\
							<audio controls src="'+self.audioSrc+'"></audio>\
							<div class="entry_extra">\
								<p>'+self.extra+'</p>\
							</div>\
							<footer class="footer_extra clearfix">\
								<div class="row table_layout">\
									<div class="col-sm-8">\
										<a href="blog_post_with_extended_image.html" class="btn small black alignleft">Continue Reading</a>\
									</div>\
									<div class="col-sm-4">\
										<div class="actions_wrap">\
											<ul class="actions_list">\
												<li>\
													<div class="share_wrap">\
														<span class="si-icon share action_btn" data-width="21" data-height="21" data-event="click" data-icon-name="social"></span>\
														<div class="addthis_sharing_toolbox"></div>\
													</div>\
												</li>\
												<li>\
													<span class="like_btn" data-amount="97">\
														<span class="si-icon action_btn not_liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likeDark" data-amount="97"></span>\
														<span class="si-icon action_btn liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likedDark" data-amount="97"></span>\
													</span>\
												</li>\
											</ul>\
										</div>\
									</div>\
								</div>\
							</footer>\
						</article>',

						// simple text post type

						'<article class="entry">\
							<h4 class="entry_title"><a href="'+self.postLink+'">'+self.title+'</a></h4>\
							<div class="entry_meta">In <a href="#">'+self.category+'</a> '+self.created+' by <a href="#">'+self.author+'</a> with <a href="#">'+self.comments+' comments</a></div>\
							<div class="entry_extra">\
								<p>'+self.extra+'</p>\
							</div>\
							<footer class="footer_extra clearfix">\
								<div class="row table_layout">\
									<div class="col-sm-8">\
										<a href="blog_post_with_extended_image.html" class="btn small black alignleft">Continue Reading</a>\
									</div>\
									<div class="col-sm-4">\
										<div class="actions_wrap">\
											<ul class="actions_list">\
												<li>\
													<div class="share_wrap">\
														<span class="si-icon share action_btn" data-width="21" data-height="21" data-event="click" data-icon-name="social"></span>\
														<div class="addthis_sharing_toolbox"></div>\
													</div>\
												</li>\
												<li>\
													<span class="like_btn" data-amount="97">\
														<span class="si-icon action_btn not_liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likeDark" data-amount="97"></span>\
														<span class="si-icon action_btn liked" data-width="27" data-height="23" data-event="mouseover" data-icon-name="likedDark" data-amount="97"></span>\
													</span>\
												</li>\
											</ul>\
										</div>\
									</div>\
								</div>\
							</footer>\
						</article>'

					];

				}

				switch(pageType){
					case 'portfolio' : 
						return portfolioLayouts[index];
					case 'gallery' : 
						return galleryLayouts[index];
					case 'blog' :
						return blogLayouts[index];
				}

			}

		}

	}

	Core.extend();
	
	// Initialize after DOM ready
	$(document).ready(function(){

		Core.DOMReady();

	});

	//  Initialize when all scripts and images have been loaded
	$(window).load(function(){

		Core.windowLoad();

	});

})(jQuery);