using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProsegurChallengeApp.Utils
{
    public static class Utils
    {
        public static void InsertNullValueToListItem(List<SelectListItem> listItem)
        {
            listItem.Insert( 0, new SelectListItem { Value = null, Text = null } );
        }
    }
}
