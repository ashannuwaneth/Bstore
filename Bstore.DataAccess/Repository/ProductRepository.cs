using Bstore.DataAccess.Data;
using Bstore.DataAccess.Repository.IRepository;
using Bstore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bstore.DataAccess.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {

        private readonly ApplicationDataContext _db;

        public ProductRepository(ApplicationDataContext db) : base(db)
        {
            _db = db;
        }   
        public void Update(Product obj)
        {
            var Productobj = _db.Products.FirstOrDefault(x => x.Id == obj.Id);
            if (Productobj != null)
            {
                Productobj.Title = obj.Title;
                Productobj.ISBN = obj.ISBN;
                Productobj.Price = obj.Price;
                Productobj.Price50 = obj.Price50;
                Productobj.ListPrice = obj.ListPrice;
                Productobj.Price100 = obj.Price100;
                Productobj.Description = obj.Description;
                Productobj.CategoryId = obj.CategoryId;
                Productobj.Author = obj.Author;
                Productobj.CoverTypeId= obj.CoverTypeId;
                if (Productobj.ImageUrl != null)
                {
                    Productobj.ImageUrl = obj.ImageUrl;
                }
            }
            _db.Products.Update(Productobj);
        }
    }
}
