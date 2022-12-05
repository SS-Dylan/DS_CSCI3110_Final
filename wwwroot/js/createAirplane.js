"use strict";

//Import the create function
import { create } from "./airplaneRepo.js";

(function _airplaneCreate() {
    var formCreateAirplane =
        document.querySelector("#createAirplane");  //Get the airplaneVM form element
    
    formCreateAirplane.addEventListener('submit', async e =>
    {
        e.preventDefault();
        
        var formData = new FormData(formCreateAirplane);

        try
        {    //Send AJAX call
            var result = await create(formData);
        }
        
        finally
        {   //Redirect
            window.location.replace(`/airplane`);
        }

    });
})();