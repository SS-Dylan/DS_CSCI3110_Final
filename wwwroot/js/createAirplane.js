"use strict";

import { create } from "./airplaneRepo.js"; //Import the create function

(function _airplaneCreate() {
    var formCreateAirplane =
        document.querySelector("#createAirplane");  //Get the airplaneVM form element
    
    formCreateAirplane.addEventListener('submit', async e =>
    {
        e.preventDefault();
        
        var formData = new FormData(formCreateAirplane);

        try
        {
            var result = await create(formData);    //Send AJAX call
        }
        
        finally
        {
            window.location.replace(`/airplane`);   //Redirect
        }

    });
})();