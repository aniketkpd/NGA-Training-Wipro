using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace FeedbackPortal.TagHelpers
{
    [HtmlTargetElement("star-rating")]
    public class StarRatingTagHelper : TagHelper
    {
        public int Count { get; set; } = 5;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = new StringBuilder();

            for (int i = 1; i <= Count; i++)
            {
                content.Append("<span style='color:gold;font-size:20px;'>★</span>");
            }

            output.TagName = "div";
            output.Content.SetHtmlContent(content.ToString());
        }
    }
}