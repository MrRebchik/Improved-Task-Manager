$(document).ready(function () {

    function getCookie(name) {
        var cookieValue = null;
        if (document.cookie && document.cookie !== ''){
            var cookies = document.cookie.split(';');
            for (var i = 0; i < cookies.length; i++){
                var cookie = cookies[i].trim();
                if (cookie.substring(0, name.length + 1) === (name + '=')){
                    cookieValue = decodeURIComponent(cookie.substring(name.length + 1));
                    break;
                }
            }
        }
        return cookieValue;
    }

    var csrf_token = getCookie('csrftoken')


    $('button.delete_task').on('click', function () {
        let curr_el = $(this)
        let id = $(curr_el).parent().attr('id');

        $.ajax({
            url: 'delete/' + id,
            type: 'POST',
            data: {
                id: id,
                csrfmiddlewaretoken: csrf_token
            },
            success: function () {
                alert("Deleted!");
                $(curr_el).parent().fadeOut();
            }
        })
    })
})
