using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperShop.Web.TagHelpers
{
    // [HtmlTargetElement("my-helper")]
    public class Base64JpegTagHelper : TagHelper
    {
        public string ImageData { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "img";
            output.Attributes.Add("src", $"data:image/jpeg;base64,{ImageData}"); 
        }
    }
}
