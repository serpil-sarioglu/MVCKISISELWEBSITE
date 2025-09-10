using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MVCKISISELWEBSITE.Helper
{
    [HtmlTargetElement("truncate")]
    public class TruncateTagHelper:TagHelper
    {
        public int Length { get; set; } = 50;
        public string Text { get; set; }=string.Empty;
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (Text.Length <=Length)
            {
                output.Content.SetContent(Text);
            }
            else
            {
                 var truncatedText= Text.Substring(0,Length)+ "...";
                output.Content.SetContent(truncatedText);

            }
            output.TagName = null;
        }        
    }
}
