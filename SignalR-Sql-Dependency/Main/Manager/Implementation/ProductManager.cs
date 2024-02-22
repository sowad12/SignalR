using Library.Infrastructer.Interface;
using Library.Model.ViewModel;
using Main.Manager.Interface;

namespace Main.Manager.Implementation
{
    public class ProductManager : IProductManager
    {
        private readonly IDapperContext _dapper;
        public ProductManager(IDapperContext dapper)
        {
            _dapper = dapper;
        }
        public bool CreateUpdateProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProduct(long id)
        {
            throw new NotImplementedException();
        }

        public  List<Product> GetAllProducts()
        {
            try
            {
                var data = _dapper.StoredProcedureQuery<Product>("PRODUCT_SELECT", new
                {


                });
                return data;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}
