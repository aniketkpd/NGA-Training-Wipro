using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace CustomerFeedbackApp.TagHelpers
{
    [HtmlTargetElement("rating-stars")]
    public class RatingTagHelper : TagHelper
    {
        public int Max { get; set; } = 5;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = new StringBuilder();

            for (int i = 1; i <= Max; i++)
            {
                content.Append($"<input type='radio' name='Rating' value='{i}' /> ⭐ ");
            }

            output.TagName = "div";
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}