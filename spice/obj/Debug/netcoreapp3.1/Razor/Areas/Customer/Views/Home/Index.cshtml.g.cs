#pragma checksum "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8c1405742d3b4db3bef85fdff557cc464c5377ef"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Areas_Customer_Views_Home_Index), @"mvc.1.0.view", @"/Areas/Customer/Views/Home/Index.cshtml")]
namespace AspNetCore
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
#nullable restore
#line 1 "D:\2022\spice\spice\Areas\Customer\Views\_ViewImports.cshtml"
using spice;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\2022\spice\spice\Areas\Customer\Views\_ViewImports.cshtml"
using spice.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"8c1405742d3b4db3bef85fdff557cc464c5377ef", @"/Areas/Customer/Views/Home/Index.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"5f2ed86c783bf4c79000cbafe64aee5d4a8ac8ec", @"/Areas/Customer/Views/_ViewImports.cshtml")]
    #nullable restore
    public class Areas_Customer_Views_Home_Index : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<spice.Models.ViewModel.IndexViewModel>
    #nullable disable
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("width", new global::Microsoft.AspNetCore.Html.HtmlString("99%"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString(" height:140px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_2 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("img-thumbnail"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_3 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Details", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_4 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-controller", "Home", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_5 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-area", "Customer", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_6 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("style", new global::Microsoft.AspNetCore.Html.HtmlString("width:80px"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_7 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("btn btn-info form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        #line hidden
        #pragma warning disable 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperExecutionContext __tagHelperExecutionContext;
        #pragma warning restore 0649
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner __tagHelperRunner = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperRunner();
        #pragma warning disable 0169
        private string __tagHelperStringValueBuffer;
        #pragma warning restore 0169
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __backed__tagHelperScopeManager = null;
        private global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager __tagHelperScopeManager
        {
            get
            {
                if (__backed__tagHelperScopeManager == null)
                {
                    __backed__tagHelperScopeManager = new global::Microsoft.AspNetCore.Razor.Runtime.TagHelpers.TagHelperScopeManager(StartTagHelperWritingScope, EndTagHelperWritingScope);
                }
                return __backed__tagHelperScopeManager;
            }
        }
        private global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
#nullable restore
#line 2 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
  
    ViewData["Title"] = "Home Page";
    

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n\r\n");
#nullable restore
#line 8 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
Write(ViewData["date"]);

#line default
#line hidden
#nullable disable
            WriteLiteral(" \r\n<span style=\"color:cadetblue; font-weight:bold;\">Hello Programmer</span>\r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 12 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
 foreach (var item in ViewData["names"] as List<string>)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("    <span>    ");
#nullable restore
#line 14 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
         Write(item);

#line default
#line hidden
#nullable disable
            WriteLiteral("  </span>\n");
#nullable restore
#line 15 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("<br />\r\n<br />\r\n");
#nullable restore
#line 18 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
 if(Model.Coupons.Count()>0)
{

#line default
#line hidden
#nullable disable
            WriteLiteral("<div class=\"border-row\">\r\n    <div class=\"carousel\" data-ride=\"carousel\"   data-interval=\"2000\">\r\n\r\n        \r\n");
            WriteLiteral("\r\n");
#nullable restore
#line 45 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
         for (int i = 0; i < Model.Coupons.Count(); i++)
            {
                var base64=Convert.ToBase64String(Model.Coupons.ToList()[i].Picture);
               string img= $"data:image/Jpeg;base64,{base64}";
                //var img = string.Format("data:image/Jpeg;base64,{0}",base64);
              
                if (i == 0)
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                    <div class=\"carousel-item active\">\r\n                              <img");
            BeginWriteAttribute("src", " src=\"", 1735, "\"", 1745, 1);
#nullable restore
#line 54 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("", 1741, img, 1741, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                               style=\"width:1100px; height:50px; display:block;\"\r\n                               class=\"img-thumbnail\">\r\n                    </div>\r\n");
#nullable restore
#line 58 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"

                }
                else
                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                      <div class=\"carousel-item\">  \r\n                             <img");
            BeginWriteAttribute("src", " src=\"", 2061, "\"", 2071, 1);
#nullable restore
#line 63 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
WriteAttributeValue("", 2067, img, 2067, 4, false);

#line default
#line hidden
#nullable disable
            EndWriteAttribute();
            WriteLiteral("\r\n                               style=\"width:1100px; height:50px; display:block;\"\r\n                               class=\"img-thumbnail\">                         \r\n                      </div>\r\n");
#nullable restore
#line 67 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"

                }

        }

#line default
#line hidden
#nullable disable
            WriteLiteral("    </div>\r\n   \r\n</div>\r\n");
#nullable restore
#line 74 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
}

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                               \r\n<br />\r\n<br />\r\n<div class=\"whitebackground container\" style=\"margin-top:10px\">\r\n");
#nullable restore
#line 80 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
  foreach (var item in Model.Category)
    {
        var myMenuitem = Model.MenuItem.Where(x => x.Category.Name.Equals(item.Name));

#line default
#line hidden
#nullable disable
            WriteLiteral("        <div class=\"row\">\r\n");
#nullable restore
#line 84 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
         if(myMenuitem.Count() > 0)
        {

#line default
#line hidden
#nullable disable
            WriteLiteral("            <div class=\"col-12\">\r\n                <div class=\"row\">\r\n                    <h3 class=\"text-success\">\r\n                        ");
#nullable restore
#line 89 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                   Write(item.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n                    </h3>\r\n                </div>\r\n");
#nullable restore
#line 93 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                  foreach (var item2 in Model.MenuItem.Where(x => x.Category.Id == item.Id).OrderByDescending(x=>x.Name))
                    {

#line default
#line hidden
#nullable disable
            WriteLiteral(@"                        <div class=""border border-info rounded col-12"" style=""margin-top:10px;margin-bottom:10px;padding:10px"">
                            <div class=""row"">
                                 <div class=""col-md-3 col-sm-12"">
                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("img", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "8c1405742d3b4db3bef85fdff557cc464c5377ef11612", async() => {
            }
            );
            __Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.Razor.TagHelpers.UrlResolutionTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_Razor_TagHelpers_UrlResolutionTagHelper);
            BeginAddHtmlAttributeValues(__tagHelperExecutionContext, "src", 2, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            AddHtmlAttributeValue("", 3399, "~/Images/", 3399, 9, true);
#nullable restore
#line 98 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
AddHtmlAttributeValue("", 3408, item2.Image, 3408, 12, false);

#line default
#line hidden
#nullable disable
            EndAddHtmlAttributeValues(__tagHelperExecutionContext);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_1);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_2);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral(@"
                                 </div>

                                <div class=""col-md-9 col-sm-12"">
                                    <div class=""row pr-3"">
                                        <div class=""col-8"">
                                            <label class=""text-primary"" style=""font-size:21px;"">
                                               ");
#nullable restore
#line 105 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                          Write(item2.Name);

#line default
#line hidden
#nullable disable
            WriteLiteral("                                             \r\n                                            </label>\r\n");
#nullable restore
#line 107 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                               if(item2.Spicyness == "0")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span> No Spicy That\'s Desert</span>\r\n");
#nullable restore
#line 110 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                                }
                                                else if(item2.Spicyness == "1")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text-info\"> Light Spicy</span>\r\n");
#nullable restore
#line 114 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                                }
                                                else if(item2.Spicyness == "2")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text-secondary\"> Hot Spicy</span>\r\n");
#nullable restore
#line 118 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                                }
                                                else if(item2.Spicyness == "3")
                                                {

#line default
#line hidden
#nullable disable
            WriteLiteral("                                                    <span class=\"text-danger\">Very Hot Spicy</span>\r\n");
#nullable restore
#line 122 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                                }

#line default
#line hidden
#nullable disable
            WriteLiteral("                                        </div>\r\n                                         <div class=\"col-4 text-right\" style=\"color:maroon\">\r\n                                             <h4>\r\n                                                 $");
#nullable restore
#line 126 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                             Write(item2.Price);

#line default
#line hidden
#nullable disable
            WriteLiteral(@" 
                                             </h4>
                                         </div>
                                    </div>
                                </div>
                                <div class=""row col-12 text-justify"" style=""margin-left:20px; margin-right:20px"">
                                    <p>");
#nullable restore
#line 132 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                  Write(item2.Description);

#line default
#line hidden
#nullable disable
            WriteLiteral("</p>\r\n                                </div>\r\n                                <div class=\"col-md-3 col-sm-12 offset-md-9 text-right\">\r\n                                    ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("a", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "8c1405742d3b4db3bef85fdff557cc464c5377ef17284", async() => {
                WriteLiteral("Details");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Action = (string)__tagHelperAttribute_3.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_3);
            if (__Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues == null)
            {
                throw new InvalidOperationException(InvalidTagHelperIndexerAssignment("asp-route-id", "Microsoft.AspNetCore.Mvc.TagHelpers.AnchorTagHelper", "RouteValues"));
            }
            BeginWriteTagHelperAttribute();
#nullable restore
#line 135 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                                                              WriteLiteral(item2.Id);

#line default
#line hidden
#nullable disable
            __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"] = __tagHelperStringValueBuffer;
            __tagHelperExecutionContext.AddTagHelperAttribute("asp-route-id", __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.RouteValues["id"], global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Controller = (string)__tagHelperAttribute_4.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_4);
            __Microsoft_AspNetCore_Mvc_TagHelpers_AnchorTagHelper.Area = (string)__tagHelperAttribute_5.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_5);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_6);
            __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_7);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\r\n                                </div>\r\n                            </div>\r\n                        </div>\r\n");
#nullable restore
#line 140 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
                     
                       
                    }

#line default
#line hidden
#nullable disable
            WriteLiteral("            </div>\r\n            <div>\r\n               \r\n            </div>\r\n");
#nullable restore
#line 147 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
        }

#line default
#line hidden
#nullable disable
            WriteLiteral("        </div>\r\n");
#nullable restore
#line 149 "D:\2022\spice\spice\Areas\Customer\Views\Home\Index.cshtml"
    }

#line default
#line hidden
#nullable disable
            WriteLiteral("\r\n</div>\r\n");
        }
        #pragma warning restore 1998
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; } = default!;
        #nullable disable
        #nullable restore
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<spice.Models.ViewModel.IndexViewModel> Html { get; private set; } = default!;
        #nullable disable
    }
}
#pragma warning restore 1591