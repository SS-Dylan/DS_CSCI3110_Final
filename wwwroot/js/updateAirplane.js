"use strict";

import { update } from "./airplaneRepo.js"; //Import the create function

(function _airplaneUpdate() {
    var formUpdateAirplane =
        document.querySelector("#updateAirplane");  //Get the airplaneVM form element
    
    formUpdateAirplane.addEventListener('submit', async e =>
    {
        e.preventDefault();
        var formData = new FormData(formUpdateAirplane);
        
        try
        {
            var result = await update(formData);    //Send AJAX call
        }
        
        finally
        {
            window.location.replace(`/airplane`);   //Redirect
        }
    });
})();