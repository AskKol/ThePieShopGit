using System.Collections;
using System.Collections.Generic;

namespace ThePieShopGit.Models
{
    public interface ICategoryRepository
    {
         IEnumerable<Category> Categories { get; }
       
    }
}