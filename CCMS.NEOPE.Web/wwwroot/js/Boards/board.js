(function ($) {

    function getStatusString(status) {
      let statusStr = 'Não iniciada';
      if(status == 'InProgress') {
        statusStr = 'Em andamento';
      } else if (status == 'InReview'){
        statusStr = 'Em revisão';
      } else if (status == 'Done'){
        statusStr = 'Concluída';
      } 

      return statusStr;
    }

    function getCardText({ title, project, duedate, isLate, status } )
    {
        //create the element that will be inserted on the kanban item
        let cardEl = document.createElement('div');

        //create the title div
        let titleEl = document.createElement('div');
        titleEl.classList.add("text-bold");
        titleEl.style.paddingBottom = '20px';
        titleEl.style.paddingLeft = '10px';
        titleEl.style.fontWeight = 'bold';
        titleEl.style.fontSize = '16px';
        titleEl.style.paddingRight = '10px';
        titleEl.style.marginLeft = '20px';
        
        titleEl.innerText = title;
        cardEl.appendChild(titleEl);

        //create the body content div
        let cardBody = document.createElement('div');
        cardEl.appendChild(cardBody);

        //create project div
        let projectDiv = document.createElement('div');
        let spanProj = document.createElement('span');
        spanProj.style.fontSize = '14px';
        spanProj.style.fontWeight = 'bold';
        spanProj.innerText = project;
        projectDiv.appendChild(spanProj);
        cardBody.appendChild(projectDiv);

        //create duedate div
        let dueDateDiv = document.createElement('div');
        let spanDue = document.createElement('span');
        spanDue.style.fontSize = '12px';
        spanDue.style.fontWeight = 'bold';

        if(isLate === undefined || isLate == false)
            spanDue.style.color = '#61A60E';
        else
            spanDue.style.color = '#ff0f0f';

        spanDue.innerText = duedate;

        dueDateDiv.appendChild(spanDue);
        cardBody.appendChild(dueDateDiv);

        let statusDiv = document.createElement('div');
        statusDiv.innerText = status;
        cardBody.appendChild(statusDiv);

        return cardEl.innerHTML;
    }

    function clickCallback(el, kanbanBoards) {
        let id = el.dataset.eid;
        
        let modal = document.getElementById('modal_task_content');
        modal.innerHTML = '';
        
        let modalContent = document.createElement("div");

        modalContent.classList.add("modal-content");
        modal.appendChild(modalContent);

        $.ajax({
          method: "GET",
          url: "Board/Status",
          async: false,
          data: { id: id }
        })
        .done(function( msg ) {
          modalContent.innerHTML = msg;
          $('select').not('.disabled').not('.js-is-select2').formSelect();
          M.updateTextFields();
        });

        let modalFooter = document.createElement("div");
        modalFooter.classList.add("modal-footer");

        let buttonsDiv = document.createElement("div");
        buttonsDiv.classList.add("buttons");
        buttonsDiv.classList.add("right");
        modalFooter.appendChild(buttonsDiv);

        let element = document.createElement("a");
        element.classList.add("waves-effect");
        element.classList.add("waves-light");
        element.classList.add("btn");
        element.classList.add("grey");
        element.classList.add("modal-close");
        element.href = '#!';
        element.innerHTML = 'Cancelar';
        buttonsDiv.appendChild(element);

        element = document.createElement("button");
        element.classList.add("waves-effect");
        element.classList.add("waves-light");
        element.classList.add("btn");
        element.classList.add("green");
        element.classList.add("darken-4");
        element.innerHTML = 'Salvar';
        element.setAttribute("id","btnSaveStatus")
        element.style.marginLeft = '5px';
        buttonsDiv.appendChild(element);

        modal.appendChild(modalFooter);

        $("#btnSaveStatus").on("click", function() {
            
            $.ajax({
              method: "POST",
              url: "Board/Status",
              async: false,
              data: $("#activity").serialize()
            })
            .done(function( data ) {
              if(data.isJson === undefined || data.isJson == false)
              {
                modalContent.innerHTML = data;
                $('select').not('.disabled').not('.js-is-select2').formSelect();
                M.updateTextFields();
              } else {
                if(data.status == 'Done')
                {
                  kanbanBoards.removeElement(data.assetId);
                }
                else
                {
                  let correctBoard = "_plan";
                  if(data.stepId == 2){
                    correctBoard = "_inspecao";
                  } else if( data.stepId == 3) {
                    correctBoard = "_tac_equip";

                  } else if( data.stepId == 4) {
                    correctBoard = "_taf_spcs";

                  } else if( data.stepId == 5) {
                    correctBoard = "_tac_spcs";
                    
                  } else if( data.stepId == 6) {
                    correctBoard = "_energizacao";
                    
                  } else if( data.stepId == 7) {
                    correctBoard = "_sap";
                  }

                  kanbanBoards.removeElement(data.assetId);
                  kanbanBoards.addElement(correctBoard, {
                    id: data.assetId,
                    title: getCardText({ title: data.name, project: data.project, duedate: data.duedate, islate: data.islate, status: getStatusString(data.status) }),
                    class: ["card"]

                  });


                  // //configure the actionbutton
                  // kanbanBoards.replaceElement(data.assetId, {
                  //   id: data.assetId,
                  //   title: getCardText({ title: data.name, project: data.project, duedate: data.duedate, islate: data.islate, status: getStatusString(data.status) }),
                  //   class: ["card"]

                  // });

                }

              }
            });
          


         });
        
        let instanceM = M.Modal.getInstance(modal);
        instanceM.open();
        
        
        
    }

    $(document).ready(function (){

        let cards = {
            planejamento: [
                {
                  id: "_test_delete",
                  title: "Try drag this (Look the console)",
                  drag: function(el, source) {
                    console.log("START DRAG: " + el.dataset.eid);
                  },
                  dragend: function(el) {
                    console.log("END DRAG: " + el.dataset.eid);
                  },
                  drop: function(el) {
                    console.log("DROPPED: " + el.dataset.eid);
                  },
                  class: ["card"]
                },
                {
                  title: "Try Click This!",
                  click: function(el) {
                    alert("click");
                  },
                  context: function(el, e){
                    alert("right-click at (" + `${e.pageX}` + "," + `${e.pageX}` + ")")
                  },
                  class: ["card"]
                }
              ],
            inspecao: [
                {
                  id: 1,
                  title: getCardText({ title:"72T2", project: "Araripina II", duedate: "22/11/2022", status: "Em andamento" }),
                  class: ["card"]
                },
                {
                  title: "Run?",
                  class: ["card"]
                }
              ],
            tacequip: [
                {
                  title: "Do Something!",
                  class: ["card"]
                },
                {
                  title: "Run?",
                  class: ["card"]
                }
              ],
            tafspcs: [
                {
                  title: "All right",
                  class: ["card"]
                },
                {
                  title: "Ok!",
                  class: ["card"]
                }
              ],
            tacspcs: [
                {
                  title: "All right",
                  class: ["card"]
                },
                {
                  title: "Ok!",
                  class: ["card"]
                }
              ],
            energizacao: [
                {
                  title: "All right",
                  class: ["card"]
                },
                {
                  title: "Ok!",
                  class: ["card"]
                }
              ],
            sap: [
                {
                  title: "All right",
                  class: ["card"]
                },
                {
                  title: "Ok!",
                  class: ["card"]
                }
              ]
        };

        let KanbanTest = new jKanban({
            element: "#myKanban",
            gutter: "10px",
            widthBoard: "300px",
            dragBoards: false,      
            itemHandleOptions:{
              enabled: true,
              handleClass         : "item_handle",
              customCssHandler    : "drag_handler",
              customCssIconHandler: "drag_handler_icon", 
            },
            click: function(el) {
              clickCallback(el, KanbanTest);
            },
            context: function(el, e) {
             
            },
            dropEl: function(el, target, source, sibling){
              console.log(target.parentElement.getAttribute('data-id'));
              console.log(el, target, source, sibling)
            },
            buttonClick: function(el, boardId) {
              console.log(el);
              console.log(boardId);
              // create a form to enter element
              var formItem = document.createElement("form");
              formItem.setAttribute("class", "itemform");
              formItem.innerHTML =
                '<div class="form-group"><textarea class="form-control" rows="2" autofocus></textarea></div><div class="form-group"><button type="submit" class="btn btn-primary btn-xs pull-right">Submit</button><button type="button" id="CancelBtn" class="btn btn-default btn-xs pull-right">Cancel</button></div>';
    
              KanbanTest.addForm(boardId, formItem);
              formItem.addEventListener("submit", function(e) {
                e.preventDefault();
                var text = e.target[0].value;
                KanbanTest.addElement(boardId, {
                  title: text
                });
                formItem.parentNode.removeChild(formItem);
              });
              document.getElementById("CancelBtn").onclick = function() {
                formItem.parentNode.removeChild(formItem);
              };
            },
            boards: [
              {
                id: "_plan",
                title: "PLANEJAMENTO",
                class: "kanban-board-header",
                //dragTo: ["_tac_equip"],
                item: cards.planejamento
              },
              {
                id: "_inspecao",
                title: "INSPEÇÃO",
                class: "kanban-board-header",
                item: cards.inspecao,
              },
              {
                id: "_tac_equip",
                title: "TAC EQUIP. INTERLIG.",
                class: "kanban-board-header",
                item: cards.tacequip,
              },
              {
                id: "_taf_spcs",
                title: "TAF SPCS",
                class: "kanban-board-header",
                
                item: cards.tafspcs
              },
              {
                id: "_tac_spcs",
                title: "TAC SPCS",
                class: "kanban-board-header",
                
                item: cards.tacspcs,
              },
              {
                id: "_energizacao",
                title: "Energização",
                class: "kanban-board-header",
               // dragTo: ["_tac_spcs"],
                item: cards.energizacao,
              },
              {
                id: "_sap",
                title: "SAP",
                class: "kanban-board-header",
               // dragTo: ["_tac_spcs"],
                item: cards.sap,
              }
            ]
          });
    
        //   var toDoButton = document.getElementById("addToDo");
        //   toDoButton.addEventListener("click", function() {
        //     KanbanTest.addElement("_plan", {
        //       title: "Test Add"
        //     });
        //   });
    
        //   var toDoButtonAtPosition = document.getElementById("addToDoAtPosition");
        //   toDoButtonAtPosition.addEventListener("click", function() {
        //     KanbanTest.addElement("_plan", {
        //       title: "Test Add at Pos"
        //     }, 1);
        //   });
    
        //   var addBoardDefault = document.getElementById("addDefault");
        //   addBoardDefault.addEventListener("click", function() {
        //     KanbanTest.addBoards([
        //       {
        //         id: "_default",
        //         title: "Kanban Default",
        //         item: [
        //           {
        //             title: "Default Item"
        //           },
        //           {
        //             title: "Default Item 2"
        //           },
        //           {
        //             title: "Default Item 3"
        //           }
        //         ]
        //       }
        //     ]);
        //   });
    
        //   var removeBoard = document.getElementById("removeBoard");
        //   removeBoard.addEventListener("click", function() {
        //     KanbanTest.removeBoard("_taf_spcs");
        //   });
    
        //   var removeElement = document.getElementById("removeElement");
        //   removeElement.addEventListener("click", function() {
        //     KanbanTest.removeElement("_test_delete");
        //   });
    
          var allEle = KanbanTest.getBoardElements("_plan");
          allEle.forEach(function(item, index) {
            //console.log(item);
          });    
    
    });
} ( jQuery ))