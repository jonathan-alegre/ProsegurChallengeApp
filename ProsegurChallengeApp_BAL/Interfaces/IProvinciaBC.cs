using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProsegurChallengeApp_BAL.Interfaces
{
    public interface IProvinciaBC
    {
        List<SelectListItem> GetListItemProvincias();
    }
}
