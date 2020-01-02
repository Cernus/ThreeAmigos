using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreeAmigos.ProductFacade.Models
{
    public class DecrementProductDto
    {
        public int ProductId { get; set; }
        public int DecrementBy { get; set; }
    }
}
