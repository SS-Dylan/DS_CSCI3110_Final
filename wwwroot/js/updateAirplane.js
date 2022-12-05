"use strict";

 //Import the update function
import { update } from "./airplaneRepo.js";

(function _airplaneUpdate() {
    var formUpdateAirplane =
        document.querySelector("#updateAirplane");  //Get the airplaneVM form element
    
    formUpdateAirplane.addEventListener('submit', async e =>
    {
        e.preventDefault();
        var formData = new FormData(formUpdateAirplane);
        
        try
        {    //Send AJAX call
            var result = await update(formData);
        }
        
        finally
        {   //Redirect
            window.location.replace(`/airplane`);
        }
    });
})();