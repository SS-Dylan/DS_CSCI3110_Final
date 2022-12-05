using DS_CSCI3110_Final.Models.Entities;
using DS_CSCI3110_Final.Models.ViewModels;
using DS_CSCI3110_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace DS_CSCI3110_Final.Controllers;

/// <summary>
/// Handles CRRUD functionalities for pilot entities.
/// </summary>
public class PilotController : Controller
{
    private readonly IPilotRepository _pilotRepository;
    public PilotController(IPilotRepository pilotRepository)
    {
        _pilotRepository = pilotRepository;
    }

    /// <summary>
    /// GET method for creating a pilot.
    /// </summary>
    /// <returns></returns>
    public IActionResult Create()
    {
        return View();
    }

    /// <summary>
    /// POST method for creating a pilot.
    /// </summary>
    /// <param name="pilotVM"></param>
    /// <returns></returns>
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PilotVM pilotVM)
    {
        if (ModelState.IsValid)
        {
            var pilot = pilotVM.GetPilotInstance();
            await _pilotRepository.CreateAsync(pilot);
        }
        return RedirectToAction("Index");
    }

    /// <summary>
    /// Method to return details on a specific pilot.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Details(int id)
    {
        var pilot = await _pilotRepository.ReadAsync(id);
        if (pilot == null)
        {
            return RedirectToAction("Index", "Pilot");
        }
        var model = new PilotVM()
        {
            Id = pilot.Id,
            FirstName = pilot.FirstName,
            LastName = pilot.LastName
        };
        return View(model);
    }

    /// <summary>
    /// Gets all pilots in the database.
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        return View(await _pilotRepository.ReadAllAsync());
    }

    /// <summary>
    /// GET method for editing a pilot.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Edit(int id)
    {
        var pilot = await _pilotRepository.ReadAsync(id);
        if (pilot == null)
        {
            return RedirectToAction("Index");
        }
        var pilotVM = new PilotVM
        {
            Id = pilot.Id,
            FirstName = pilot.FirstName,
            LastName = pilot.LastName
        };
        return View(pilotVM);
    }

    /// <summary>
    /// POST method for editing a pilot.
    /// </summary>
    /// <param name="pilotVM"></param>
    /// <returns></returns>
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(PilotVM pilotVM)
    {
        if (ModelState.IsValid)
        {
            var pilot = pilotVM.GetPilotInstance();
            await _pilotRepository.UpdateAsync(pilot.Id, pilot);
        }
        return RedirectToAction("Index");
    }

    /// <summary>
    /// GET method for deleting a pilot.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Delete(int id)
    {
        var pilot = await _pilotRepository.ReadAsync(id);
        return View(pilot);
    }

    /// <summary>
    /// POST method for deleting a pilot.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    [HttpPost, ValidateAntiForgeryToken, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _pilotRepository.DeleteAsync(id);
        return RedirectToAction("Index");
    }
}
