using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CustomerFeedbackApp.Helpers
{
    public static class CustomHtmlHelpers
    {
        public static IHtmlContent StyledInput(this IHtmlHelper htmlHelper, string name, string placeholder)
        {
            return new HtmlString($"<input name='{name}' placeholder='{placeholder}' class='form-control' />");
        }
    }
}