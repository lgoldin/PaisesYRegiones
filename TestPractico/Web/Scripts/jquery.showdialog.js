//ShowDialog jQuery Plugin
//Requires jQuery and jQuery UI
;(function ($) {
	var defaults = {
		message: '',
		title: '',
		iconClass: '',
		onClick: function () {
			$(this).dialog('close');
		},
		onYesClick: function () {
			$(this).dialog('close');
		},
		onNoClick: function () {
			$(this).dialog('close');
		}
	};

	$.showOkDialog = function (params) {
        var params = $.extend({}, defaults, params);

		$('<span class="ui-okdialog"><span class="ui-icon dialog-icon ' + params.iconClass + '"></span>' + params.message + '</span>').dialog({
			modal: true,
			dialogClass: 'no-close',
			buttons: [{
				text: 'Aceptar',
				'class': 'btn btn-primary',
				click: params.onClick
			}],
			title: params.title,
			width: 350,
			resizable: false,
            draggable: false
		});
    };
	
	$.showYesNoDialog = function (params) {
		var params = $.extend({}, defaults, params);

		$('<span class="ui-yesnodialog"><span class="ui-icon dialog-icon ' + params.iconClass + '"></span>' + params.message + '</span>').dialog({
			modal: true,
			dialogClass: 'no-close',
			buttons: [{
				text: 'Si',
				'class': 'btn btn-primary btn-green',
				click: params.onYesClick
			}, {
				text: 'No',
				'class': 'btn btn-primary btn-red',
				click: params.onNoClick
			}],
			title: params.title,
			width: 350,
			resizable: false,
            draggable: false
		});
	};
} (jQuery));