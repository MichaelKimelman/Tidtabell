using Azure.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using Tidtabell.Models;

namespace Tidtabell.Data.Helper
{
    public class UniqueTimeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value,
        ValidationContext validationContext)
        {
            //var context = (ApplicationDbContext)validationContext.GetService(typeof(ApplicationDbContext));
            //if (!context.Time.Any(a => a.Hours == value && a.Minutes == value))
            //{
            //    return ValidationResult.Success;
            //}
            return new ValidationResult("Time Exists");
        }
    }
}

public class SaveCode
{
    public async Task<IActionResult> Create([Bind("Id,Hours,Minutes")] Time time)
    {
        //var oldValue = time.Minutes;
        //string extra = Request.Form["Minutessecond"];

        //time.Minutes = extra;
        //if (ModelState.IsValid)
        //{

        //    if (_context.Time.ToList().Exists(x => x.Hours == time.Hours) && _context.Time.ToList().Exists(x => x.Minutes == time.Minutes))
        //    {
        //        ViewData["ClockHours"] = GetTimeValueLists()[0];
        //        ViewData["ClockMinutes"] = GetTimeValueLists()[1];
        //        ModelState.AddModelError("Error", "Time Already Exists");
        //        return View(time);
        //    }
        //    _context.Add(time);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}
        //ViewData["ClockHours"] = GetTimeValueLists()[0];
        //ViewData["ClockMinutes"] = GetTimeValueLists()[1];
        //return View(time);
        return new ViewResult();
    }
    public async Task<IActionResult> Edit(int id, [Bind("Id,Hours,Minutes")] Time time)
    {
        //if (id != time.Id)
        //{
        //    return NotFound();
        //}
        //if (_context.Time.ToList().Exists(x => x.Hours == time.Hours && x.Minutes == time.Minutes))
        //{
        //    ViewData["ClockHours"] = GetTimeValueLists()[0];
        //    ViewData["ClockMinutes"] = GetTimeValueLists()[1];
        //    ModelState.AddModelError("Error", "Time Already Exists");
        //    return View(time);
        //}
        //_context.ChangeTracker.Clear();//CLEARS TRACKING FROM ABOVE IF EXISTS CHECK, OTHERWISE INVALIDOPERATIONERROR
        //
        //if (ModelState.IsValid)
        //{
        //    try
        //    {
        //        _context.Update(time);
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TimeExists(time.Id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }
        //
        //    return RedirectToAction(nameof(Index));
        //}
        //ViewData["ClockHours"] = GetTimeValueLists()[0];
        //ViewData["ClockMinutes"] = GetTimeValueLists()[1];
        //return View(time);
        return new ViewResult();
    }
    private List<List<SelectListItem>> GetTimeValueLists()
    {
        List<SelectListItem> hourList = new List<SelectListItem>();
        List<SelectListItem> minuteList = new List<SelectListItem>();

        int hours = 0;
        int minutes = 0;

        for (int i = 0; i < 60; i++)
        {
            if (i < 24)
            {
                hourList.Add(new SelectListItem() { Text = i < 10 ? "0" + i.ToString() : i.ToString(), Value = i < 10 ? "0" + i.ToString() : i.ToString() });
            }
            minuteList.Add(new SelectListItem() { Text = i < 10 ? "0" + i.ToString() : i.ToString(), Value = i < 10 ? "0" + i.ToString() : i.ToString() });
        }

        return new List<List<SelectListItem>> { hourList, minuteList };
    }

    //FROM TIME CREATE VIEW 
    //<div class="form-group" style="display:none">
    //    <label asp-for="Minutes" class="control-label">minutes</label>
    //    <input asp-for="Minutes" value="x" class="form-control"></input>
    //    <span asp-validation-for="Minutes" class="text-danger"></span>
    //</div>
    //<div class="form-group">
    //    <label class="control-label">Minutessecond</label>
    //    <select name = "Minutessecond" asp-items="ViewBag.ClockMinutes" class="form-control"></select>
    //    <span asp-validation-for="Minutes" class="text-danger"></span>
    //</div>
    //<div class="text-danger">
    //    @Html.ValidationMessage("Error")
    //</div>


}