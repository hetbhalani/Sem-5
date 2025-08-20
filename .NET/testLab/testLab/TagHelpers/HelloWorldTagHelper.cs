using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Net;
namespace testLab.TagHelpers
{
    public class HelloWorldTagHelper: TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "span";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent("Hello World");
        }
    }
}
