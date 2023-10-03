using Salmon_Cookies.Dto;
using Salmon_Cookies.Model;

namespace Salmon_Cookies.Interface
{
    public interface IStandCookies
    {
        Task<List<ViewStandCookies>> Get();
        Task<ViewStandCookies> GetById(int id);

        Task<CookieStand> Create(CreateStand stand);
        Task<CookieStand> Put(int id, CreateStand updateStand);
        Task<CookieStand> Delete(int id);

        
    }
}
