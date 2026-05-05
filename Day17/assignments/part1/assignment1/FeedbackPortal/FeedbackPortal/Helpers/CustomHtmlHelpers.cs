using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FeedbackPortal.Helpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlContent StyledInput(this IHtmlHelper htmlHelper, string name, string placeholder)
        {
            return new HtmlString($"<input name='{name}' placeholder='{placeholder}' style='padding:5px;border:1px solid gray;' />");
        }
    }
}