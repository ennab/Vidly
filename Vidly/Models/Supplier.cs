using System;

namespace Vidly.Models
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public DateTime StartDate { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
    }
    /*
        a form for supplier
        model 
        id name phone startdate city
        index page
        edit page
        index method
        new method
        edit method 
     */
}