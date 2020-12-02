using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ModelsConnected;

namespace WebAPI.Controllers
{
    public static class PostalCodesValidator
    {   
        public static List<Country> CountriesWithPCMask { get; set; }

        //public static void TryGetCodeMask(Relation relation, Country country)
        //{ 
        //    if(CountriesWithPCMask.Count() == 0)
        //    {
        //        CountriesWithPCMask
        //    }
        //}
    }
}
