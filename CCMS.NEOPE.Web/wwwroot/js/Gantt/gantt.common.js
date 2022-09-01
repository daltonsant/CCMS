(function ($) {
    
    
    $(document).ready(function () {
        var tasks = [
            {
                id: 'Task 1',
                name: 'Redesign website',
                start: '2022-08-28',
                end: '2022-09-12',
                progress: 100,
                dependencies: ''
            },
            {
                id: 'Task 2',
                name: 'Redesign website',
                start: '2022-08-28',
                end: '2022-08-31',
                progress: 100,
                dependencies: 'Task 1'
            },
            {
                id: 'Task 3',
                name: 'Redesign website',
                start: '2022-08-28',
                end: '2022-09-21',
                progress: 100,
                dependencies: 'Task 2'
            }
        ];
        
        let gantt = new Gantt("#gantt", tasks, {
            header_height: 50,
            column_width: 30,
            step: 24,
            view_modes: ['Quarter Day', 'Half Day', 'Day', 'Week', 'Month'],
            bar_height: 20,
            bar_corner_radius: 3,
            arrow_curve: 5,
            padding: 18,
            view_mode: 'Day',
            date_format: 'YYYY-MM-DD',
            custom_popup_html: null
        });
        
    });
} ( jQuery ));