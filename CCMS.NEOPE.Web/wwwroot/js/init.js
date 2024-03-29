
// Write your JavaScript code.
(function($){
    $(function(){

        // Plugin initialization
        $('.collapsible').collapsible({accordion: true});
        $('.carousel.carousel-slider').carousel({fullWidth: true});
        $('.carousel').carousel();
        $('.tooltipped').tooltip();
        $('.dropdown-trigger').dropdown({
            alignment: 'right',
            constrainWidth: false,
            coverTrigger: false,
            closeOnClick: false,
            onOpenEnd: function(el) {
                var tabs = $(this).find('.tabs');
                var dropdownInstance = el.M_Dropdown;
                if (tabs.length) {
                    var tabsInstance = M.Tabs.getInstance(tabs);
                    tabsInstance.updateTabIndicator();
                    tabsInstance.options.onShow = function() {
                        setTimeout(function() {
                            dropdownInstance.recalculateDimensions();
                            tabsInstance.updateTabIndicator();
                        }, 0);
                    };
                }
            }
        });
        $('.slider').slider();
        $('.parallax').parallax();
        $('.modal').modal();
        $('.scrollspy').scrollSpy();
        $('.sidenav').sidenav({'edge': 'left'});
        $('#sidenav-right').sidenav({'edge': 'right'});
        $('.datepicker').datepicker({selectYears: 20});
        $('select').not('.disabled').not('.js-is-select2').formSelect();
        $('input.autocomplete').autocomplete({
            data: {"Apple": null, "Microsoft": null, "Google": 'http://placehold.it/250x250'},
        });
        $('.tabs').tabs();

        // Chips
        $('.chips').chips();
        $('.chips-initial').chips({
            readOnly: true,
            data: [{
                tag: 'Apple',
            }, {
                tag: 'Microsoft',
            }, {
                tag: 'Google',
            }]
        });
        $('.chips-placeholder').chips({
            placeholder: 'Enter a tag',
            secondaryPlaceholder: '+Tag',
        });
        $('.chips-autocomplete').chips({
            autocompleteOptions: {
                data: {
                    'Apple': null,
                    'Microsoft': null,
                    'Google': null
                }
            },
        });


    }); // end of document ready
})(jQuery); // end of jQuery name space
