using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SamaraOrganicsSystem.Dtos;

namespace SamaraOrganicsSystem.Models.ViewModels
{
    public class CreateInvoiceVM
    {
        public IEnumerable<VendorDto> VendorList { get; set; }
        public IEnumerable<CategoryDto> CategoryList { get; set; }
        public IEnumerable<StatusDto> StatusList { get; set; }
        public IEnumerable<AccountsDto> AccountsList { get; set; }
       
    }
}
