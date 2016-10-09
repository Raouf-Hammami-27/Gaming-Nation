using TAG_DATA;
using TAG_DATA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TAG_DATA.Infrastructure
{
    public interface IDatabaseFactory : IDisposable 
    {
        tagContext DataContext { get; } 
    }
}
