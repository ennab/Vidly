using System.Collections.Generic;
using Vidly.Models;
namespace Vidly.ViewModels
{
    public class SupplierFormViewModel
    {
        public List<City> Cities { get; set; }
        public Supplier Supplier { get; set; }
    }
}