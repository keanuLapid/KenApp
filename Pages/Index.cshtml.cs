using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KenApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public List<Company> Companies { get; set; }

        [BindProperty]
        public SearchParameters SearchParams { get; set; }

        public void OnGet(string sortBy = null, bool? sortAsc = null)
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

            SearchParams = new SearchParameters
            {
                SortBy = sortBy,
                SortAsc = sortAsc ?? true
            };

            if (!string.IsNullOrEmpty(SearchParams.SortBy))
            {
                switch (SearchParams.SortBy.ToLower())
                {
                    case "name":
                        Companies = SearchParams.SortAsc ? companies.OrderBy(c => c.Name).ToList() : companies.OrderByDescending(c => c.Name).ToList();
                        break;
                    case "industry":
                        Companies = SearchParams.SortAsc ? companies.OrderBy(c => c.Industry).ToList() : companies.OrderByDescending(c => c.Industry).ToList();
                        break;
                    case "location":
                        Companies = SearchParams.SortAsc ? companies.OrderBy(c => c.Location).ToList() : companies.OrderByDescending(c => c.Location).ToList();
                        break;
                    case "employees":
                        Companies = SearchParams.SortAsc ? companies.OrderBy(c => c.Employees).ToList() : companies.OrderByDescending(c => c.Employees).ToList();
                        break;
                    default:
                        Companies = companies;
                        break;
                }
            }
            else
            {
                Companies = companies;
            }
        }

        public class Company
        {
            public string Name { get; set; }
            public string Industry { get; set; }
            public string Location { get; set; }
            public int Employees { get; set; }
        }

        public class SearchParameters
        {
            public string SortBy { get; set; }
            public bool SortAsc { get; set; }
            public string SearchBy { get; set; }
            public string Keyword { get; set; }
            public int PageSize { get; set; } = 5;
            public int PageIndex { get; set; } = 1;
            public int PageCount { get; set; }
            public int SearchCount { get; set; }
        }
    }
}