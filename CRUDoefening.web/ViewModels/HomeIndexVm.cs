using CRUDoefening.web.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDoefening.web.ViewModels
{
    public class HomeIndexVm
    {
        public IEnumerable<Teacher> Teachers { get; set; }
    }
}
