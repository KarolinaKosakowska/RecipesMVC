using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipesMVC.TagHelpers
{
    [HtmlTargetElement("ul", Attributes = "page-model")]
    public class PageLinkTagHelper: TagHelper
    {
        private readonly IUrlHelperFactory urlHelperFactory;
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public PageInfo PageModel { get; set; }

        public string Action { get; set; }

        [HtmlAttributeName(DictionaryAttributePrefix = "page-url-")]
        public Dictionary<string, object> PageUrlValues { get; set; } = new Dictionary<string, object>();

        public string PageItemCss { get; set; }

        public string PageLinkCss { get; set; }

        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            this.urlHelperFactory = urlHelperFactory;
        }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder li = new TagBuilder("li");
                TagBuilder a = new TagBuilder("a");

                PageUrlValues["pageId"] = i;
                PageUrlValues["pageSizeLocal"] = PageModel.ItemPerPage;

                if (PageModel.CurrentPage == i)
                {
                    a.Attributes["disabled"] = "disabled";
                    a.AddCssClass("active");
                }
                else
                    a.Attributes["href"] = urlHelper.Action(Action, PageUrlValues);

                a.InnerHtml.Append(i.ToString());

                if (!string.IsNullOrEmpty(PageLinkCss))
                    a.AddCssClass(PageLinkCss);

                if (!string.IsNullOrEmpty(PageItemCss))
                    li.AddCssClass(PageItemCss);

                li.InnerHtml.AppendHtml(a);

                output.Content.AppendHtml(li);
            }
        }
    }
}
    

