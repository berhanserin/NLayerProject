using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NLayerProject.Web.DTOs
{
    public class ErrorDto
    {
        public ErrorDto()
        {
            Erors=new List<string>();
        }
        public List<String> Erors { get; set; }
        public int Status { get; set; }
    }
}
