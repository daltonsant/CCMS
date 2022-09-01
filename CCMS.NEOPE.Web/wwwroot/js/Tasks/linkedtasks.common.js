(function ($) {
    const taksSelectOptions = {
        ajax: {
            url: '/Tasks/SearchTasks',
            dataType: 'json',
            delay: 250,
            data: function (params) {
                var query = {
                    search: params.term,
                    page: params.page,
                    taskId: $("#Id").val()
                }
                // Query parameters will be ?search=[term]&type=public
                return query;
            },
            processResults: function (data, params) {
                // parse the results into the format expected by Select2
                // since we are using custom formatting functions we do not need to
                // alter the remote JSON data, except to indicate that infinite
                // scrolling can be used
                params.page = params.page || 1;

                return {
                    results: data.items,
                    pagination: {
                        more: (params.page * 10) < data.total_count
                    }
                };
            }
            // Additional AJAX parameters go here; see the end of this chapter for the full code of this example
        },
        minimumInputLength: 3,
        input_text: 'Selecione a atividade...',
        language: "pt-BR"
    };
    const editObject = [];
    
    function clearAddOrEditRelatedTasksFields(){
        $("#rel_type").val('').formSelect();
        $("#related_atvs").val(null).trigger('change');
    }
   
    function showAddOrEditRelatedTasks(){
        let relatedAtvs = $("#lista_atv_associadas");
        let addOrEditAtvs = $("#add_or_edit_atv_associada");
        
        addOrEditAtvs.show();
        relatedAtvs.hide();
   }
    
    function fnClearAndShowLinkedTasks(){
       let relatedAtvs = $("#lista_atv_associadas");
       let addOrEditAtvs = $("#add_or_edit_atv_associada");

       clearAddOrEditRelatedTasksFields();

        $("#val_rel_type").empty();
        $("#val_tasks_rel").empty();
        
       addOrEditAtvs.hide();
       relatedAtvs.show();
   }
   
    function fnDeleteLink(event){
        let linkedTask = $(event.target).closest("tr");
        linkedTask.remove();

        $("#related_tasks_table_content").children().each( (index, element) => {
            $(element).children().each((i,child) => {
                let name = child.name;
                
                if(name) {
                    name = name.replace(/^(\w+)\[.*?\]/, '$1[' + index + ']');
                    child.name = name;
                }
            });
        });
    }
    
    function fnUpdateEventHandler(event) {
        const linkedTask = $(event.target).closest("tr");
        const relatedAtvs = $("#lista_atv_associadas");
        const addOrEditAtvs = $("#add_or_edit_atv_associada");
        const children = linkedTask.children();
        
        editObject.length = 0;
        editObject.push(linkedTask);
        
        addOrEditAtvs.show();
        relatedAtvs.hide();

        $("#related_atvs").val(null).trigger('change');
        
        const subjectId = $(children[3]).val();
        const objectId = $(children[2]).val();
        let taskId = $("[name='Id']").val();
        let selectedTaskId = subjectId;
        const selectedType =  $(children[4]).text();

        $("#rel_type option").filter(function() {
            let text = $(this).text();
            return text == selectedType;
        }).prop("selected", true);
        
        $("#rel_type").formSelect();
        
        let isSubject = false;
        
        if(taskId == undefined)
            taskId = "";
        
        if(taskId == subjectId){
            isSubject = true;
            selectedTaskId = objectId;
        } 
        
        var newOption = new Option($(children[5]).text(), selectedTaskId, false, true);
        $('#related_atvs').append(newOption).trigger('change');
        
        console.log(editObject);
        
    }
    
    $(document).ready(function () {
        editObject.length = 0;
        
        $('.js-is-select2').sm_select(taksSelectOptions);
        
        $("#cancel_add_or_edit_linked_task").click(() => {
            fnClearAndShowLinkedTasks();
        });
        
        $("#add_new_link").click(() => {
            showAddOrEditRelatedTasks();
        });
        
        $("#concluir_add_or_edit_linked_task").click(() => {
            let selectedTaskId = $("#related_atvs").val();
            let selectedTaskTitle =  $("#related_atvs option:selected").text();
            let selectedRelType = $("#rel_type").val();
            let selectedRelTypeText = $("#rel_type option:selected").text();
            
            $("#val_rel_type").empty();
            $("#val_tasks_rel").empty();
            
            let hasError = false;
            
            //validation
            if(selectedRelType === "") {
                hasError = true;
                $("#val_rel_type").text("O campo Tipo de relacionamento é obrigatorio");
            }
            if(selectedTaskId === "") {
                hasError = true;
                $("#val_tasks_rel").text("O campo Atividade relacionada é obrigatorio");
            }
            const taskId = $("[name='Id']").val();
            
            if (!hasError) {
                if (editObject.length > 0) {
                    const linkedTask = editObject[0].children();
                    
                    $(linkedTask[1]).val(selectedRelType);
                    $(linkedTask[4]).text(selectedRelTypeText);
                    $(linkedTask[5]).text(selectedTaskTitle);

                    $(linkedTask[7]).val(selectedRelTypeText);
                    $(linkedTask[8]).val(selectedTaskTitle);
                    
                    let subjectTask = $(linkedTask[3]);
                    let objectTask = $(linkedTask[2]);

                    switch (selectedRelTypeText)  {
                        case "Bloqueia":
                        case "Causa":
                        case "Duplica":
                            subjectTask.val(taskId);
                            objectTask.val(selectedTaskId);
                            break;
                        case "Bloqueada por":
                        case "Causada por":
                        case "Relacionada a":
                            subjectTask.val(selectedTaskId);
                            objectTask.val(taskId);
                            break;
                    }
                    
                    //after the edit remove the edited item from the list
                    editObject.length = 0;
                } else {
                    let count = 0;
                    $("#related_tasks_table_content").children().each((index, element) =>{
                        let linkAttributes = $(element).children();
                        if($(linkAttributes[2]).val() == selectedTaskId || 
                            $(linkAttributes[2]).val() == selectedTaskId ) {
                            count++;
                        }
                    });
                    
                    if(count > 1) {
                        hasError = true;
                        $("#val_tasks_rel").text("Já existe um relacionamento com essa atividade");
                    } else {
                        let index = $("#related_tasks_table_content").children().length;
                        
                        let newElement = fnCreateLink(index, "", selectedRelType,
                            selectedTaskId, selectedRelTypeText, selectedTaskTitle);

                        $("#related_tasks_table_content").append(newElement);
                    }
                }
                
                fnClearAndShowLinkedTasks();
            }
            
        });
        
        $("#related_tasks_table_content").on("click",".delete-link",(e) => {
            fnDeleteLink(e);
        });

        $("#related_tasks_table_content").on("click",".edit-link",(event) => {
            fnUpdateEventHandler(event);
        });
    });
    
    function fnCreateLink(index, id, selectedRelType, selectedTaskId, selectedRelTypeText, selectedTaskTitle) {
        const taskId = $("[name='Id']").val();
        
        let element = 
            $('<tr class="hoverable linkedtask">' +
                '<input type="hidden" name="LinkedTasks['+ index + '].Id" value="' + id + '" />' +
                '<input type="hidden" name="LinkedTasks['+ index +'].Type" value="'+ selectedRelType +'"/>' +
                '<input type="hidden" name="LinkedTasks[' + index + '].ObjectTaskId" value />' +
                '<input type="hidden" name="LinkedTasks[' + index +'].SubjectTaskId" value />' +
                '<td>' + selectedRelTypeText + '</td>' +
                '<td>' + selectedTaskTitle + '</td>' +
                '<td>' +
                    '<a class="delete-link waves-effect waves-light material-icons" style="color: red;">delete</a>' +
                    '<a class="edit-link waves-effect waves-light material-icons" style="color: black;">edit</a>' +
                '</td>' +
                '<input type="hidden" name="LinkedTasks[' + index + '].TypeText" value="'+ selectedRelTypeText +'" />' +
                '<input type="hidden" name="LinkedTasks[' + index +'].TaskText" value="'+ selectedTaskTitle +'" />' +
            '</tr>');
        
        let children = element.children();
        
        let objectTask = $(children[2]);
        let subjectTask = $(children[3]);

        switch (selectedRelTypeText)  {
            case "Bloqueia":
            case "Causa":
            case "Duplica":
                subjectTask.val(taskId);
                objectTask.val(selectedTaskId);
                break;
            case "Bloqueada por":
            case "Causada por":
            case "Relacionada a":
                subjectTask.val(selectedTaskId);
                objectTask.val(taskId);
                break;
        }
        
        return  element;
    }
    
} ( jQuery ));