"use strict";

//Import the delete function
import { deleteAirplane } from "./airplaneRepo.js";

(function _airplaneDelete() {
    var formDeleteAirplane =
        document.querySelector("#deleteAirplane");  //Get the airplane form element
    
    formDeleteAirplane.addEventListener('submit', async e =>
    {
        e.preventDefault();
        
        var formData = new FormData(formDeleteAirplane);
        var id = formData.get("Id");    //Get the airplane Id from the form data

        try
        {   //Send AJAX call
            var result = await deleteAirplane(id);  
        }

        finally
        {   //Redirect
            window.location.replace(`/airplane`);   
        }
    });
})();