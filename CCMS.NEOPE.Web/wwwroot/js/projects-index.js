(function ($) {
    function fnAClickLink(projectId){
        let url = '/Projects/Edit/'+projectId;
        window.location.replace(url);
    }

    $(document).ready(function(){

        let tasksTable = $('#table-projects');
        if(tasksTable.length){
            let table = tasksTable.DataTable({
                serverSide: true,
                ajax: {
                    url: "/Projects/List/",
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
                        'className': 'projectId',
                        'visible' : false
                    },
                    { responsivePriority: 1, targets: 2 },
                ],
                columns: [
                    { data: "id", name: "Id" },
                    { data: "code", name: "Code" },
                    { data: "name", name: "Name" },
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
            $('#table-projects').on('click','tbody tr', function (){
                let data = table.row(this).data();
                if(data !== undefined){
                    let projectId = data['id'];
                    //inicialmente iremos abrir outra pagina, mas é possivel abrir um modal para atualização na mesma tela
                    fnAClickLink(projectId);
                }
                
            });
        }
    });
}( jQuery ));
