(function ($) {

    function getCard({ id, title, project, duedate, status } )
    {
        let cardStr = "<div>";

        cardStr += "<div class='text-bold' stype='padding-bottom:10px; font-weight: bold;'>"+title+"</div>"


        cardStr += "</div>"
        return cardStr;
    }



    $(document).ready(function (){
        var KanbanTest = new jKanban({
            element: "#myKanban",
            gutter: "10px",
            widthBoard: "450px",
            dragBoards: false,      
            itemHandleOptions:{
              enabled: true,
            },
            click: function(el) {
              console.log("Trigger on all items click!");
            },
            context: function(el, e) {
              console.log("Trigger on all items right-click!");
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
                class: "info,good",
                //dragTo: ["_tac_equip"],
                item: [
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
                    }
                  },
                  {
                    title: "Try Click This!",
                    click: function(el) {
                      alert("click");
                    },
                    context: function(el, e){
                      alert("right-click at (" + `${e.pageX}` + "," + `${e.pageX}` + ")")
                    },
                    class: ["peppe", "bello"]
                  }
                ]
              },
              {
                id: "_inspecao",
                title: "INSPEÇÃO",
                class: "cyan",
                item: [
                  {
                    title: getCard({id:1,title:"Ola mundo"})
                  },
                  {
                    title: "Run?"
                  }
                ]
              },
              {
                id: "_tac_equip",
                title: "TAC EQUIP. INTERLIG.",
                class: "warning",
                item: [
                  {
                    title: "Do Something!"
                  },
                  {
                    title: "Run?"
                  }
                ]
              },
              {
                id: "_taf_spcs",
                title: "TAF SPCS",
                class: "success",
                
                item: [
                  {
                    title: "All right"
                  },
                  {
                    title: "Ok!"
                  }
                ]
              },
              {
                id: "_tac_spcs",
                title: "TAC SPCS",
                class: "success",
                
                item: [
                  {
                    title: "All right"
                  },
                  {
                    title: "Ok!"
                  }
                ]
              },
              {
                id: "_energizacao",
                title: "Energização",
                class: "success",
               // dragTo: ["_tac_spcs"],
                item: [
                  {
                    title: "All right"
                  },
                  {
                    title: "Ok!"
                  }
                ]
              },
              {
                id: "_sap",
                title: "SAP",
                class: "success",
               // dragTo: ["_tac_spcs"],
                item: [
                  {
                    title: "All right"
                  },
                  {
                    title: "Ok!"
                  }
                ]
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