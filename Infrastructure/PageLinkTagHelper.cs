using ItMightBeAmazon.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//custom helper tag
namespace ItMightBeAmazon.Infrastructure
{
    //target elements are divs with page-model as the attributes
    [HtmlTargetElement("div", Attributes = "page-model")]

    //PageLinkTagHelper that inherits from TagHelper
    public class PageLinkTagHelper : TagHelper
    {
        //Private instance of an IUrlHelperFactory
        private IUrlHelperFactory urlHelperFactory;

        //pass in a parameter that will place a value in the urlHelperFactory variable
        public PageLinkTagHelper (IUrlHelperFactory hp)
        {
            urlHelperFactory = hp;
        }


        //properties of the PageLinkTagHelper class
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PagingInfo PageModel { get; set; }

        public string PageAction { get; set; }

        //create a dictionary called PageUrlValues with the attribute pregix "page-url-" and instantiate it.
        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //override method for pagination
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            TagBuilder result = new TagBuilder("div");

            //create a button for every necessary page
            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");

                PageUrlValues["page"] = i;

                tag.Attributes["href"] = urlHelper.Action(PageAction, PageUrlValues);

                //this if statement is for styling with bootstrap in the index.cshtml file
                if (PageClassesEnabled)
                {
                    tag.AddCssClass(PageClass);
                    tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                }

                tag.InnerHtml.Append(i.ToString());

                result.InnerHtml.AppendHtml(tag);

            }

            //output the result
            output.Content.AppendHtml(result.InnerHtml);
        }
    }
}
