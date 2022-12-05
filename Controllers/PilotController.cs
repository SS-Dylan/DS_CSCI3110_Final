using DS_CSCI3110_Final.Models.ViewModels;
using DS_CSCI3110_Final.Services;
using Microsoft.AspNetCore.Mvc;

namespace DS_CSCI3110_Final.Controllers;

/// <summary>
/// Handles CRRUD functionalities for pilot entities.
/// </summary>
public class PilotController : Controller
{
    private readonly IAirplaneRepository _airplaneRepo;
    public PilotController(IAirplaneRepository airplaneRepo)
    {
        _airplaneRepo = airplaneRepo;
    }

    /// <summary>
    /// GET method for creating a pilot.
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> CreateAsync([Bind(Prefix = "id")] int airplaneId)
    {
        var airplane = await _airplaneRepo.ReadAsync(airplaneId);
        if (airplane == null)
        {
            RedirectToAction("Index", "Airplane");
        }
        ViewData["Airplane"] = airplane;
        return View();
    }

    /// <summary>
    /// POST method for creating a pilot.
    /// </summary>
    /// <param name="pilot"></param>
    /// <returns></returns>
    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int airplaneId, CreatePilotVM pilot)
    {
        if (pilot != null)
        {
            var model = pilot.GetPilotInstance();
            await _airplaneRepo.CreatePilotAsync(airplaneId, model);
            return RedirectToAction("Details", "Airplane", new { id = airplaneId });
        }
        var airplane = _airplaneRepo.ReadAsync(airplaneId);
        ViewData["Airplane"] = airplane;
        return View(pilot);
    }

    /// <summary>
    /// Gets all pilots in the database.
    /// </summary>
    /// <returns></returns>
    public async Task<IActionResult> Index()
    {
        return View(await _airplaneRepo.ReadAllPilotAsync());
    }

    /// <summary>
    /// GET method for editing a pilot.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public async Task<IActionResult> Edit([Bind(Prefix = "id")] int airplaneId, int pilotId)
    {
        var airplane = await _airplaneRepo.ReadAsync(airplaneId);
        if (airplane == null)
        {
            return RedirectToAction("Index", "Airplane");
        }
        var pilot = airplane.Pilots.FirstOrDefault(p => p.Id == pilotId);
        if (pilot == null)
        {
            return RedirectToAction("Details", "Airplane");
        }
        var pilotVM = new EditPilotVM
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
    public async Task<IActionResult> Edit(int airplaneId, EditPilotVM pilotVM)
    {
        if (ModelState.IsValid)
        {
            var pilot = pilotVM.GetPilotInstance();
            await _airplaneRepo.UpdatePilotAsync(airplaneId, pilot);
            return RedirectToAction("Details", "Airplane", new { id = airplaneId });
        }
        pilotVM.Airplane = await _airplaneRepo.ReadAsync(airplaneId);
        return View(pilotVM);
    }
}
