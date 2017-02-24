using quotingDojoAsp.Models;
using System.Collections.Generic;

namespace quotingDojoAsp.Factory
{
    public interface IFactory<T> where T : BaseEntity
    {
    }
}