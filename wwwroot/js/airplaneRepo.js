"using strict";
// Class to handle creating, updating, and deleting airplanes.

//Path to the AirplaneAPIController
const baseAddress = "/api/airplaneapi";

//Sends AJAX request to api/airplaneapi/create to create an airplane
export async function create(formData) {
    const address = `${baseAddress}/create`;
    const response = await fetch(address, {
        method: "post",
        body: formData
    });
    console.log(response);
    if (!response.ok) {
        throw new Error("There was an error creating the airplane.");
    }
    return await response.json();
}

//Sends AJAX request to api/airplaneapi/edit to update an airplane
export async function update(formData) {
    const address = `${baseAddress}/edit`;
    const response = await fetch(address, {
        method: "put",
        body: formData
    });
    if (!response.ok) {
        throw new Error("There was an error updating the airplane.");
    }
    return await response.json();
}

//Sends AJAX request to api/airplaneapi/delete/{id} with the id for the airplane to delete
export async function deleteAirplane(id) {
    const address = `${baseAddress}/delete/${id}`;
    console.log(address);
    const response = await fetch(address, {
        method: "delete"
    });
    if (!response.ok) {
        throw new Error("There was an error deleting the airplane.");
    }
    return await response.text();
}