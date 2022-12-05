using DS_CSCI3110_Final.Models.Entities;
using DS_CSCI3110_Final.Models.ViewModels;
using DS_CSCI3110_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace DS_CSCI3110_Final.Controllers;

/// <summary>
/// Controller to handle CRRUD functionalities for Airplane entities.
/// </summary>
public class AirplaneController : Controller
{
    private readonly IAirplaneRepository _airplaneRepository;
    public AirplaneController(IAirplaneRepository airplaneRepository)
    {
        _airplaneRepository = airplaneRepository;
    }

    /// <summary>
    /// GET method for creating an airplane.
    /// </summary>
    /// <returns></returns>
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// POST method for creating an airplane.
    /// </summary>
    /// <param name="airplaneVM"></param>
    /// <returns></returns>
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(AirplaneVM airplaneVM)
    {
        if (ModelState.IsValid)
        {
            var airplane = airplaneVM.GetPlaneInstance();
            await _airplaneRepository.CreateAsync(airplane);
        }
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Method to return details on a specific airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Details(int id)
    {
        var airplane = await _airplaneRepository.ReadAsync(id);
        if (airplane == null)
        {
            return RedirectToAction("Index", "Airplane");
        }
        var model = new AirplaneVM()
        {
            Id = airplane.Id,
            TailNum = airplane.TailNum,
            Model = airplane.Model,
            Hours = airplane.Hours,
            Pilots = airplane.Pilots
        };
        return View(model);
    }

    /// <summary>
    /// Gets all airplanes in the database.
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        return View(await _airplaneRepository.ReadAllAsync());
    }

    /// <summary>
    /// GET method for editing an airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Edit(int id)
    {
        var airplane = await _airplaneRepository.ReadAsync(id);
        if (airplane == null)
        {
            return RedirectToAction("Index");
        }
        var airplaneVM = new AirplaneVM
        {
            Id = airplane.Id,
            TailNum = airplane.TailNum,
            Model = airplane.Model,
            Hours = airplane.Hours,
        };
        return View(airplaneVM);
    }
    
    /// <summary>
    /// POST method for editing an airplane.
    /// </summary>
    /// <param name="airplaneVM"></param>
    /// <returns></returns>
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(AirplaneVM airplaneVM)
    {
        if (ModelState.IsValid)
        {
            var airplane = airplaneVM.GetPlaneInstance();
            await _airplaneRepository.UpdateAsync(airplane.Id, airplane);
        }
        return RedirectToAction("Index");
    }
    
    /// <summary>
    /// GET method for deleting an airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Delete(int id)
    {
        var airplane = await _airplaneRepository.ReadAsync(id);
        return View(airplane);
    }
    
    /// <summary>
    /// POST method for deleting an airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _airplaneRepository.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
