(function ($) {


    $(document).ready(function (){


        /********************
         *     Calendar     *
         ********************/


        $('#calendar').fullCalendar({
            header: {
                left: 'prev,next,title',
                right: ''
            },
            editable: false,
            eventLimit: true, // allow "more" link when too many events
            locale: "pt-br",
            events: "/Calendar/List",
            views: {
                agendaWeek: {
                    columnFormat: 'DD'
                }
            }
        })
    });

} ( jQuery ))