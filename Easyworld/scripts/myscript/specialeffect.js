$(document).ready(function () {



  

    //RESIZING HangUp Button

    var elem = $('#LocalVideo_Mobile');
   
   
    var $windowResizer = $(window);

    $windowResizer.on('scroll resize', check_if_Div_in_view);
   
    $windowResizer.on('scroll resize', check_if_Div_in_view);

    $windowResizer.trigger('scroll resize');


    function check_if_Div_in_view() {
        var window_height = $windowResizer.height();
        var window_width = $windowResizer.width();
        var window_top_position = $windowResizer.scrollTop();
        var window_bottom_position = (window_top_position + window_height);

        $.each(elem, function () {
            var $element = $(this);
            var element_height = $element.outerHeight();
            var element_width = $element.outerWidth();
            var element_top_position = $element.offset().top;
            var element_bottom_position = (element_top_position + element_height);

           
            //check to see if this current container is within viewport
            if ((element_bottom_position >= window_top_position) && (element_top_position <= window_bottom_position))
            {
                if (window_width < 320) {
                    $element.height(100);
                    $element.width(80);
                }
                else if (window_width > 300 && window_width < 480) {
                
                    $element.height(150);
                    $element.width(120);
                }
                else if (window_width > 480 && window_width < 768) {

                    $element.height(200);
                    $element.width(180);
                }
            else
                {
                   
                    //$element.removeClass('centerr');
                   
                  
            
                }
               
            } else {
               // $element.removeClass('centerr');
              
            }
        });
    }

});


