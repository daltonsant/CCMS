(function ($) {
    function fnAClickLink(taskId){
        let url = 'Tasks/Edit/'+taskId;
        window.location.replace(url);
    }
    
    $(document).ready(function(){
        
        let tasksTable = $('#table-custom-elements');
        if(tasksTable.length){
            let table = tasksTable.DataTable({
                serverSide: true,
                ajax: {
                    url: "/Tasks/GetTasks/",
                    type: 'POST'
                }, 
                responsive: {
                    details: false
                },
                'columnDefs': [
                    {
                        'targets': 0,
                        'searchable':false,
                        'orderable':false,
                        'className': 'taskids',
                        'visible' : false
                    },
                    { responsivePriority: 1, targets: 2 },
                ],
                columns: [
                    { data: "id", name: "Id" },
                    { data: "title", name: "Title" },
                    { data: "projectName", name: "ProjectName" },
                    { data: "priority", name: "Priority"},
                    { data: "status", name: "Status" },
                    { data: "taskType", name: "TaskType" },
                ],
                'language': {
                    'searchPlaceholder': 'Pesquise aqui',
                    url: '/js/datatable.pt_br.json'
                },
                'dom': 'ft<"footer-wrapper"l<"paging-info"ip>>',
                'pagingType': 'full',
                'drawCallback': function( settings ) {
                let api = this.api();

                // Add waves to pagination buttons
                $(api.table().container()).find('.paginate_button').addClass('waves-effect');

                api.table().columns.adjust();
            }
            });
            $('#table-custom-elements').on('click','tbody tr', function (){
                let data = table.row(this).data();
                if(data !== undefined){
                    let taskId = data['id'];
                    //inicialmente iremos abrir outra pagina, mas é possivel abrir um modal para atualização na mesma tela
                    fnAClickLink(taskId);
                }
                
            });
        }
    });
}( jQuery ));
