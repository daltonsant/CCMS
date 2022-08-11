(function ($) {
    let link = $("#deleteLink").attr("href");
    
    function deleteModalAjax(href,id){
        $.ajax({
            url: link,
            type: 'DELETE',
            success: function(result) {
                // Do something with the result
               window.location.replace(href);
            }
        });
    }

    $(document).ready(function(){
        let id = $("#Id").val();
        $("#ok").click(function(event) {
            let url = $(this).attr('href');
            
            event.preventDefault();
            
            deleteModalAjax(url,id);  
        });
    });
}( jQuery ));
