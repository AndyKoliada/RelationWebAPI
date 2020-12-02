using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.ModelsConnected;

namespace WebAPI.Controllers
{
    public static class RequiredFieldsInit
    {
        public static void InitializeRequiredFields(Relation relation)
        {
            relation.InvoiceDateGenerationOptions = 1;
            relation.InvoiceGroupByOptions = 1;
            relation.PaymentViaAutomaticDebit = false;
            relation.IsMe = false;
            relation.IsTemporary = false;
            relation.IsDisabled = false;
            relation.CreatedAt = DateTime.Now;
            relation.CreatedBy = "Admin";
        }
    }
}
