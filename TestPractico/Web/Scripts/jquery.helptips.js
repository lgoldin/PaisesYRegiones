//Helptips.js 1.1
//Plugin to show toggleable on-screen help tips by Christian Smirnoff (Baufest)
//Requires jQuery 1.7+ and qTip2 2.2.0+ Plugin
;(function ($) {
	$.fn.helptips = function (method) {
        if (helptips[method]) {
            settings = this.data('helptips') ? this.data('helptips') : settings;
            return helptips[method].apply(this, Array.prototype.slice.call(arguments, 1));
        } else if (typeof method === 'object' || !method) {
            return helptips.init.apply(this, arguments);
        } else {
            $.error('Method ' + method + ' does not exist on helptips.js');
        }
    };
	
	$.fn.helptips.defaults = {
		selector: '.help-tip',
		toggleSelector: '.help',
		toggleHoverClass: 'hover',
		toggleActiveClass: 'active',
		toggleEvent: 'click',
		container: $(this),
		fadeIn: 250,
		fadeOut: 250,
		showEffect: function() {
			$(this).fadeIn(settings.fadeIn);
		},
		hideEffect: function() {
			$(this).fadeOut(settings.fadeOut);
		},
		positionEffect: false,
		positionAt: 'bottom right',
		positionMy: 'top left',
		styleClasses: '',
		events: {},
		loadingText: 'Loading...'
	};
	
    var settings;
    var helptips = {
        init: function (options) {
			settings = $.extend({}, $.fn.helptips.defaults, options);
			$(this).data('helptips', settings);
			
            return this.each(function () {
                $(settings.toggleSelector).mouseenter(function () {
                    $(settings.toggleSelector).addClass(settings.toggleHoverClass);
                }).mouseleave(function () {
                    $(settings.toggleSelector).removeClass(settings.toggleHoverClass);
                }).on(settings.toggleEvent, function () {
                    $(settings.toggleSelector).toggleClass(settings.toggleActiveClass);
                });

                helptips.applyHelpTips();
            });
        },
        applyHelpTips: function () {
            $(settings.selector).each(function () {
                $(this).qtip({
                    overwrite: false,
                    content: {
						text: function(event, api) {
							if ($(this).data('ajax')) {
								$.ajax($(this).data('ajax'))
									.done(function(html) {
										api.set('content.text', html);
									})
									.fail(function(xhr, status, error) {
										api.set('content.text', status + ' : ' + error);
									});
								return $(this).attr('title') ? $(this).attr('title') : settings.loadingText;
							} else if ($(this).attr('data-selector')) {
								return $($(this).attr('data-selector'));
							} else if ($(this).attr('data-text')) {
								return $(this).attr('data-text');
							} else if ($(this).attr('title')) {
								return $(this).attr('title');
							}
						}
                    },
                    show: {
                        target: $(settings.toggleSelector),
                        event: settings.toggleEvent,
                        effect: settings.showEffect,
                        delay: 0
                    },
                    hide: {
                        target: $(settings.toggleSelector),
                        event: settings.toggleEvent,
                        effect: settings.hideEffect,
                        delay: 0
                    },
                    position: {
                        viewport: $(settings.container),
                        my: helptips.positionMy($(this)),
                        at: helptips.positionAt($(this)),
						effect: settings.positionEffect
                    },
                    style: {
                        classes: settings.styleClasses
                    },
					events: settings.events
                });
            });
        },
        positions: {
            at: {
                'tip-at-bottom-left': 'bottom left',
                'tip-at-bottom-center': 'bottom center',
                'tip-at-bottom-right': 'bottom right',
                'tip-at-top-left': 'top left',
                'tip-at-top-center': 'top center',
                'tip-at-top-right': 'top right',
                'tip-at-left-top': 'left top',
                'tip-at-left-center': 'left center',
                'tip-at-left-bottom': 'left bottom',
                'tip-at-right-top': 'right top',
                'tip-at-right-center': 'right center',
                'tip-at-right-bottom': 'right bottom',
                'tip-at-center': 'center'
            },
            my: {
                'tip-my-bottom-left': 'bottom left',
                'tip-my-bottom-center': 'bottom center',
                'tip-my-bottom-right': 'bottom right',
                'tip-my-top-left': 'top left',
                'tip-my-top-center': 'top center',
                'tip-my-top-right': 'top right',
                'tip-my-left-top': 'left top',
                'tip-my-left-center': 'left center',
                'tip-my-left-bottom': 'left bottom',
                'tip-my-right-top': 'right top',
                'tip-my-right-center': 'right center',
                'tip-my-right-bottom': 'right bottom',
                'tip-my-center': 'center'
            }
        },
        positionAt: function (elem) {
            for (className in helptips.positions.at) {
                if ($(elem).hasClass(className))
                    return helptips.positions.at[className];
            }
            return settings.positionAt;
        },
        positionMy: function (elem) {
            for (className in helptips.positions.my) {
                if ($(elem).hasClass(className))
                    return helptips.positions.my[className];
            }
            return settings.positionMy;
        },
        show: function () {
            return this.each(function () {
                $(settings.toggleSelector).addClass(settings.toggleActiveClass);
                $(settings.selector).qtip('show');
            });
        },
        hide: function () {
            return this.each(function () {
                $(settings.toggleSelector).removeClass(settings.toggleActiveClass);
                $(settings.selector).qtip('hide');
            });
        },
        destroy: function () {
            return this.each(function () {
                $(settings.selector).qtip('destroy');
            });
        }
    };
} (jQuery));