using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2K.Core.Entity;

namespace _2K.Core.Context
{
    public interface IRepository
    {
        IDbSet<Post> Posts { get; } 
    }
}
