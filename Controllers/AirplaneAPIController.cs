using DS_CSCI3110_Final.Models.ViewModels;
using DS_CSCI3110_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace DS_CSCI3110_Final.Controllers;

/// <summary>
/// API controller to handle creating, updating, and deleting
/// functionalities for Airplane entities.
/// </summary>
[ApiController, Route("api/[controller]")]
public class AirplaneAPIController : Controller
{
    private readonly IAirplaneRepository _airplaneRepository;

    public AirplaneAPIController(IAirplaneRepository airplaneRepository)
    {
        _airplaneRepository = airplaneRepository;
    }

    /// <summary>
    /// Method for creating an airplane
    /// </summary>
    /// <param name="airplaneVM"></param>
    /// <returns></returns>
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromForm] AirplaneVM airplaneVM)
    {
        var airplane = airplaneVM.GetPlaneInstance();
        await _airplaneRepository.CreateAsync(airplane);
        return NoContent();
    }

    /// <summary>
    /// Method for updating airplane properties
    /// </summary>
    /// <param name="airplaneVM"></param>
    /// <returns></returns>
    [HttpPut("edit")]
    public async Task<IActionResult> Edit([FromForm] AirplaneVM airplaneVM)
    {
        var airplane = airplaneVM.GetPlaneInstance();
        await _airplaneRepository.UpdateAsync(airplane.Id, airplane);
        return NoContent();
    }

    /// <summary>
    /// Method for deleting an airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        await _airplaneRepository.DeleteAsync(id);
        return NoContent();
    }
}
