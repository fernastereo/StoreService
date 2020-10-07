using ServiceStore.Api.Shop.RemoteModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceStore.Api.Shop.RemoteInterface
{
    public interface IBooksService
    {
        Task<(bool result, RemoteBook Book, string ErrorMessage)> GetBook(Guid BookId);
    }
}
