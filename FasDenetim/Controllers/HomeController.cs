using System.Diagnostics;
using FasDenetim.Data;
using Microsoft.AspNetCore.Mvc;
using FasDenetim.Models;
using Microsoft.EntityFrameworkCore;
using OfficeOpenXml;

namespace FasDenetim.Controllers;

public class HomeController : Controller
{
    private List<BilançoModel> bilancoModels; 
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext applicationDbContext;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext)
    {
        _logger = logger;
        this.applicationDbContext = applicationDbContext;
    }

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Data(List<BilançoModel> list)
    {
        return View(list);
    }

    public async Task<List<BilançoModel>> Import(IFormFile file)
    {
        var list = new List<BilançoModel>();
        using (var stream = new MemoryStream())
        {
            await file.CopyToAsync(stream);
            using (var package = new ExcelPackage(stream))
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                var rowCount = worksheet.Dimension.Rows;
                for (int row = 2; row < rowCount; row++)
                {
                    if (worksheet.Dimension.Rows>10)
                    {
                        list.Add(new BilançoModel
                        {
                            Bilanço = worksheet.Cells[row,1].Value.ToString().Trim(),
                            OncekiYıl = worksheet.Cells[row,2].Value.ToString().Trim(),
                            CariYıl = worksheet.Cells[row,3].Value.ToString().Trim(),
                            HesaplanmışVeri = worksheet.Cells[row,3].Value.ToString().Trim(),
                        });
                    }
                    else
                    {
                        Console.WriteLine("asdasdasda");
                    }
                    
                }
            }
        }
        applicationDbContext.bilancoModel.AddRange(list);
        applicationDbContext.SaveChanges();
        Data(list);
        return list;
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}