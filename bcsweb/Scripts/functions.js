function getbaseUrl() {
//    return "http://localhost/bcsweb/";
//    return "http://localhost:32226/";
    return "http://172.16.11.241/bcsweb/";
//    return "http://172.16.11.122/bcsweb/";
}


function isEmpty(obj) {
    for (var key in obj) {
        if (obj.hasOwnProperty(key))    
            return false;
    }
    return true;
}


function checkLoggedin() {

    var baseUrl = getbaseUrl();

    $.ajax({
        type:"POST",
        url: baseUrl + "account/checkSession",
        data: {},
        success: function(data){
            if (data.sessionValue==false)  {  
                location.href= baseUrl + "Account/Login";
                return;
            } else {
                
            }
        }
    })
}


