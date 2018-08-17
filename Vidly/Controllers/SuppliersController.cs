using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.ViewModels;

namespace Vidly.Controllers
{
    public class SuppliersController : Controller
    {
        ApplicationDbContext _context;
        public SuppliersController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Suppliers
        public ActionResult Index()
        {
            var suppliers = _context.Suppliers.Include(s => s.City).ToList();
            return View(suppliers);
        }
        public ActionResult New()
        {
            var cities = _context.Cities.ToList();
            var viewModel = new SupplierFormViewModel { Cities = cities };
            return View("SupplierForm", viewModel);
        }
        public ActionResult Edit(int Id)
        {
            var supplier = _context.Suppliers.Single(s => s.Id == Id);
            var viewModel = new SupplierFormViewModel
            {
                Supplier = supplier,
                Cities = _context.Cities.ToList()
            };
            return View("SupplierForm", viewModel);
        }
        public ActionResult Save(Supplier supplier)
        {
            if (supplier.Id == 0)
            {
                _context.Suppliers.Add(supplier);
            }
            else
            {
                var supplierInDB = _context.Suppliers.Single(s => s.Id == supplier.Id);
                supplierInDB.Name = supplier.Name;
                supplierInDB.Phone = supplier.Phone;
                supplierInDB.StartDate = supplier.StartDate;
                supplierInDB.CityId = supplier.CityId;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Suppliers");
        }
    }
}