using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Services.Data;
using Services.Models;

namespace Services.Features.Relations
{
    public class Index
    {
        public class Query : IRequest<Result>
        {
            public string SortOrder { get; set; }
            public string CurrentFilter { get; set; }
            public string SearchString { get; set; }
            public int? Page { get; set; }
        }

        public class Result
        {
            public string CurrentSort { get; set; }
            public string NameSortParm { get; set; }
            public string DateSortParm { get; set; }
            public string CurrentFilter { get; set; }
            //public string SearchString { get; set; }

            public PaginatedList<Model> Results { get; set; }
        }

        public class Model
        {
            //public int ID { get; set; }
            ////[Display(Name = "First Name")]
            //public string FirstMidName { get; set; }
            //public string LastName { get; set; }
            //public DateTime EnrollmentDate { get; set; }

            public Guid Id { get; set; }
            public string Name { get; set; }
            public string FullName { get; set; }
            public string TelephoneNumber { get; set; }

            [Display(Name = "Email")]
            public string EmailAddress { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Street { get; set; }
            public string StreetNumber { get; set; }
            public string PostalCode { get; set; }
            
        }

        public class QueryHandler : AsyncRequestHandler<Query, Result>
        {
            private readonly TestContext _db;

            public QueryHandler(TestContext db) => _db = db;

            protected override async Task<Result> HandleCore(Query message)
            {
                var model = new Result
                {
                    CurrentSort = message.SortOrder,
                    NameSortParm = String.IsNullOrEmpty(message.SortOrder) ? "name_desc" : "",
                    DateSortParm = message.SortOrder == "Date" ? "date_desc" : "Date",
                };

                if (message.SearchString != null)
                {
                    message.Page = 1;
                }
                else
                {
                    message.SearchString = message.CurrentFilter;
                }

                model.CurrentFilter = message.SearchString;
                //model.SearchString = message.SearchString;

                IQueryable<RelationViewModel> relations = _db.RelationViewModels;

                //Search filter
                //if (!String.IsNullOrEmpty(message.SearchString))
                //{
                //    relations = relations.Where(s => s.LastName.Contains(message.SearchString)
                //                                   || s.FirstMidName.Contains(message.SearchString));
                //}

                switch (message.SortOrder)
                {
                    case "name_desc":
                        relations = relations.OrderByDescending(r => r.Name);
                        break;
                    case "full_name_desc":
                        relations = relations.OrderByDescending(r => r.FullName);
                        break;
                    case "telephone_number_desc":
                        relations = relations.OrderByDescending(r => r.TelephoneNumber);
                        break;
                    case "email_desc":
                        relations = relations.OrderByDescending(r => r.EmailAddress);
                        break;
                    case "country_desc":
                        relations = relations.OrderByDescending(r => r.Country);
                        break;
                    case "city_desc":
                        relations = relations.OrderByDescending(r => r.City);
                        break;
                    case "street_desc":
                        relations = relations.OrderByDescending(r => r.Street);
                        break;
                    case "postal_code_desc":
                        relations = relations.OrderByDescending(r => r.PostalCode);
                        break;
                    default: // Name ascending 
                        relations = relations.OrderBy(r => r.Name);
                        break;
                }

                int pageSize = 3;
                int pageNumber = (message.Page ?? 1);
                model.Results = await relations
                    .ProjectTo<Model>()
                    .PaginatedListAsync(pageNumber, pageSize);

                return model;
            }
        }
    }
}
