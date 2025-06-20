using InventoryProject.Data;
using InventoryProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace InventoryProject.Controllers;


public class InventoryController : Controller
{
    private readonly InventoryDbContext _context;

    public InventoryController(InventoryDbContext context)
    {
        _context = context;
    }

    // GET: Inventory
    public  IActionResult Index(string category, string productName)
    {
        IQueryable<InventoryModel> query = _context.InventoryItems;
        if (!string.IsNullOrEmpty(category))
        {
            query = query.Where(i => i.Category.ToString() == category);
        }

        if (!string.IsNullOrEmpty(productName))
        {
            query = query.Where(i => i != null && i.Name.Contains(productName));
        }
        var inventoryItems = query.ToList();
        return View(inventoryItems);
    }
    
    public IActionResult Create()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Create(InventoryModel inventoryItem)
    {
        if (ModelState.IsValid)
        {
            _context.InventoryItems.Add(inventoryItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(inventoryItem);
    }

    public IActionResult Details(int id)
    {
        var inventoryItem = _context.InventoryItems.FirstOrDefault(i => i.Id == id);
        if (inventoryItem == null)
        {
            return NotFound();
        }
        return View(inventoryItem);
    }
    
    public IActionResult Edit(int id)
    {
        var inventoryItem = _context.InventoryItems.FirstOrDefault(i => i.Id == id);
        if (inventoryItem == null)
        {
            return NotFound();
        }
        return View(inventoryItem);
    }
    
    [HttpPost]
    public IActionResult Edit(InventoryModel inventoryItem)
    {
        if (ModelState.IsValid)
        {
            _context.InventoryItems.Update(inventoryItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View(inventoryItem);
    }
    
    public IActionResult Delete(int id)
    {
        var inventoryItem = _context.InventoryItems.FirstOrDefault(i => i.Id == id);
        if (inventoryItem == null)
        {
            return NotFound();
        }
        return View(inventoryItem);
    }
    
    [HttpPost, ActionName("Delete")]
    public IActionResult DeleteConfirmed(int id)
    {
        var inventoryItem = _context.InventoryItems.FirstOrDefault(i => i.Id == id);
        if (inventoryItem == null)
        {
            return NotFound();
        }
        
        _context.InventoryItems.Remove(inventoryItem);
        _context.SaveChanges();
        return RedirectToAction("Index");
    }
}
