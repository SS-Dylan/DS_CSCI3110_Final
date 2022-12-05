"use strict";

import { deleteAirplane } from "./airplaneRepo.js"; //Import the create function

(function _airplaneDelete() {
    var formDeleteAirplane =
        document.querySelector("#deleteAirplane");  //Get the airplane form element
    
    formDeleteAirplane.addEventListener('submit', async e =>
    {
        e.preventDefault();
        
        var formData = new FormData(formDeleteAirplane);
        var id = formData.get("Id");    //Get the airplane Id from the form data

        try
        {
            var result = await deleteAirplane(id);  //Send AJAX call
        }

        finally
        {
            window.location.replace(`/airplane`);   //Redirect
        }
    });
})();