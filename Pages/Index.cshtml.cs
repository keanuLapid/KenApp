using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KenApp.Pages
{
    public class Index : PageModel
    {
        private readonly ILogger<Index> _logger;

        public Index(ILogger<Index> logger)
        {
            _logger = logger;
        }

        public List<Company> Companies { get; set; }

        public void OnGet(string? sortBy = null, string? sortAsc = "true")
        {
            List<Company> companies = new List<Company>()
            {
                new Company {
                    Name = "Tech Solutions",
                    Industry = "Information Technology",
                    Location = "San Francisco, CA",
                    Employees = 250
                },
                new Company {
                    Name = "HealthPlus",
                    Industry = "Healthcare",
                    Location = "New York, NY",
                    Employees = 500
                },
                new Company {
                    Name = "EcoEnergy",
                    Industry = "Renewable Energy",
                    Location = "Austin, TX",
                    Employees = 150
                },
                new Company {
                    Name = "FinancePro",
                    Industry = "Financial Services",
                    Location = "Chicago, IL",
                    Employees = 300
                },
                new Company {
                    Name = "EduNation",
                    Industry = "Education",
                    Location = "Boston, MA",
                    Employees = 120
                },
                new Company {
                    Name = "AutoDrive",
                    Industry = "Automotive",
                    Location = "Detroit, MI",
                    Employees = 800
                },
                new Company {
                    Name = "Foodies",
                    Industry = "Food and Beverage",
                    Location = "Los Angeles, CA",
                    Employees = 200
                },
                new Company {
                    Name = "RetailMart",
                    Industry = "Retail",
                    Location = "Seattle, WA",
                    Employees = 1000
                },
                new Company {
                    Name = "MediCare",
                    Industry = "Pharmaceutical",
                    Location = "Philadelphia, PA",
                    Employees = 350
                },
                new Company {
                    Name = "SpaceY",
                    Industry = "Aerospace",
                    Location = "Houston, TX",
                    Employees = 400
                },
                new Company {
                    Name = "BuildIt",
                    Industry = "Construction",
                    Location = "Las Vegas, NV",
                    Employees = 220
                },
                new Company {
                    Name = "BioGen",
                    Industry = "Biotechnology",
                    Location = "San Diego, CA",
                    Employees = 280
                },
                new Company {
                    Name = "GreenWorld",
                    Industry = "Environmental Services",
                    Location = "Portland, OR",
                    Employees = 180
                },
                new Company {
                    Name = "Travelista",
                    Industry = "Travel and Tourism",
                    Location = "Miami, FL",
                    Employees = 500
                },
                new Company {
                    Name = "InnovateTech",
                    Industry = "Software Development",
                    Location = "San Jose, CA",
                    Employees = 350
                }
            };

            if (sortBy == null || sortAsc == null)
            {
                this.Companies = companies;
                return;
            }

            bool ascending = sortAsc.ToLower() == "true";

            this.Companies = sortBy.ToLower() switch
            {
                "name" => ascending ? companies.OrderBy(c => c.Name).ToList() : companies.OrderByDescending(c => c.Name).ToList(),
                "industry" => ascending ? companies.OrderBy(c => c.Industry).ToList() : companies.OrderByDescending(c => c.Industry).ToList(),
                "location" => ascending ? companies.OrderBy(c => c.Location).ToList() : companies.OrderByDescending(c => c.Location).ToList(),
                "employees" => ascending ? companies.OrderBy(c => c.Employees).ToList() : companies.OrderByDescending(c => c.Employees).ToList(),
                _ => companies
            };
        }

        public class Company
        {
            public string? Name { get; set; }
            public string? Industry { get; set; }
            public string? Location { get; set; }
            public int Employees { get; set; }
        }
    }
}
