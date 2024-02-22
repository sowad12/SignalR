using Library.Model.ViewModel;

namespace Main.Manager.Interface
{
    public interface IProductManager
    {
        List<Product> GetAllProducts();
        bool CreateUpdateProduct(Product product);
        bool DeleteProduct(long id);    

    }
}
