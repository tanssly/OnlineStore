using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Services
{
    public interface IShoppingCartService
    {
        void Create(Cart cart);
        List<CartItem> ReadAll();
        void Update(Cart cart);
        void Delete(Cart cart);
    }
}
