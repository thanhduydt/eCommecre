#pragma checksum "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "dfb63ff6108f574c3050fd658288c2989be9f429"
// <auto-generated/>
#pragma warning disable 1591
[assembly: global::Microsoft.AspNetCore.Razor.Hosting.RazorCompiledItemAttribute(typeof(AspNetCore.Views_Home_Checkout), @"mvc.1.0.view", @"/Views/Home/Checkout.cshtml")]
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
#line 1 "D:\eCommecre\eCommecre\Views\_ViewImports.cshtml"
using eCommecre;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "D:\eCommecre\eCommecre\Views\_ViewImports.cshtml"
using eCommecre.Models;

#line default
#line hidden
#nullable disable
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"dfb63ff6108f574c3050fd658288c2989be9f429", @"/Views/Home/Checkout.cshtml")]
    [global::Microsoft.AspNetCore.Razor.Hosting.RazorSourceChecksumAttribute(@"SHA1", @"e0a2401da98737e8b8304eb18ad99c76dbbac5af", @"/Views/_ViewImports.cshtml")]
    public class Views_Home_Checkout : global::Microsoft.AspNetCore.Mvc.Razor.RazorPage<eCommecre.Areas.Admin.Models.Bill>
    {
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_0 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("class", new global::Microsoft.AspNetCore.Html.HtmlString("form-control"), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
        private static readonly global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute __tagHelperAttribute_1 = new global::Microsoft.AspNetCore.Razor.TagHelpers.TagHelperAttribute("asp-action", "Order", global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
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
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper;
        private global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper;
        #pragma warning disable 1998
        public async override global::System.Threading.Tasks.Task ExecuteAsync()
        {
            WriteLiteral("<div class=\"page-content\">\n    <div class=\"checkout\">\n        <div class=\"container\">\n            ");
            __tagHelperExecutionContext = __tagHelperScopeManager.Begin("form", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagAndEndTag, "dfb63ff6108f574c3050fd658288c2989be9f4294042", async() => {
                WriteLiteral(@"
                <div class=""row"">
                    <div class=""col-lg-9"">
                        <h2 class=""checkout-title"">Chi ti???t ????n h??ng</h2><!-- End .checkout-title -->
                        <div class=""row"">
                            <div class=""col-sm-6"">
                                <label>T??n ng?????i nh???n</label>
                                <input type=""text"" class=""form-control"" required>
                            </div><!-- End .col-sm-6 -->

                            <div class=""col-sm-6"">
                                <label>S??? ??i???n tho???i</label>
                                ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dfb63ff6108f574c3050fd658288c2989be9f4294932", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 17 "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ReceivingPhoneNmber);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                BeginWriteTagHelperAttribute();
                __tagHelperStringValueBuffer = EndWriteTagHelperAttribute();
                __tagHelperExecutionContext.AddHtmlAttribute("required", Html.Raw(__tagHelperStringValueBuffer), global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.Minimized);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n                            </div><!-- End .col-sm-6 -->\n                        </div><!-- End .row -->\n\n                        <label>?????a ch??? nh???n</label>\n                        ");
                __tagHelperExecutionContext = __tagHelperScopeManager.Begin("input", global::Microsoft.AspNetCore.Razor.TagHelpers.TagMode.StartTagOnly, "dfb63ff6108f574c3050fd658288c2989be9f4296995", async() => {
                }
                );
                __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.InputTagHelper>();
                __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper);
#nullable restore
#line 22 "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml"
__Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For = ModelExpressionProvider.CreateModelExpression(ViewData, __model => __model.ReceivingAddress);

#line default
#line hidden
#nullable disable
                __tagHelperExecutionContext.AddTagHelperAttribute("asp-for", __Microsoft_AspNetCore_Mvc_TagHelpers_InputTagHelper.For, global::Microsoft.AspNetCore.Razor.TagHelpers.HtmlAttributeValueStyle.DoubleQuotes);
                __tagHelperExecutionContext.AddHtmlAttribute(__tagHelperAttribute_0);
                await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
                if (!__tagHelperExecutionContext.Output.IsContentModified)
                {
                    await __tagHelperExecutionContext.SetOutputContentAsync();
                }
                Write(__tagHelperExecutionContext.Output);
                __tagHelperExecutionContext = __tagHelperScopeManager.End();
                WriteLiteral("\n\n");
                WriteLiteral(@"
                        <!--<div class=""row"">
                            <div class=""col-sm-6"">
                                <label>Town / City *</label>
                                <input type=""text"" class=""form-control"" required>
                            </div>--><!-- End .col-sm-6 -->

                            <!--<div class=""col-sm-6"">
                                <label>State / County *</label>
                                <input type=""text"" class=""form-control"" required>
                            </div>--><!-- End .col-sm-6 -->
                        <!--</div>--><!-- End .row -->

                        <!--<div class=""row"">
                            <div class=""col-sm-6"">
                                <label>Postcode / ZIP *</label>
                                <input type=""text"" class=""form-control"" required>
                            </div>--><!-- End .col-sm-6 -->

                            <!--<div class=""col-sm-6"">
                                <label>Phone *");
                WriteLiteral(@"</label>
                                <input type=""tel"" class=""form-control"" required>
                            </div>--><!-- End .col-sm-6 -->
                        <!--</div>--><!-- End .row -->

                        <!--<label>Email address *</label>
                        <input type=""email"" class=""form-control"" required>

                        <div class=""custom-control custom-checkbox"">
                            <input type=""checkbox"" class=""custom-control-input"" id=""checkout-create-acc"">
                            <label class=""custom-control-label"" for=""checkout-create-acc"">Create an account?</label>
                        </div>--><!-- End .custom-checkbox -->

                        <!--<div class=""custom-control custom-checkbox"">
                            <input type=""checkbox"" class=""custom-control-input"" id=""checkout-diff-address"">
                            <label class=""custom-control-label"" for=""checkout-diff-address"">Ship to a different address?</label>
                 ");
                WriteLiteral(@"       </div>--><!-- End .custom-checkbox -->

                        <!--<label>Order notes (optional)</label>
                        <textarea class=""form-control"" cols=""30"" rows=""4"" placeholder=""Notes about your order, e.g. special notes for delivery""></textarea>-->
                    </div><!-- End .col-lg-9 -->
                    <aside class=""col-lg-3"">
                        <div class=""summary"">
                            <h3 class=""summary-title"">????n h??ng c???a b???n</h3><!-- End .summary-title -->

                            <table class=""table table-summary"">
                                <thead>
                                    <tr>
                                        <th>S???n ph???m</th>
                                        <th>Th??nh ti???n</th>
                                    </tr>
                                </thead>

                                <tbody>
");
#nullable restore
#line 84 "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml"
                                     foreach (var item in ViewBag.Cart)
                                    {

#line default
#line hidden
#nullable disable
                WriteLiteral("                                    <tr>\n                                        <td><a href=\"#\">");
#nullable restore
#line 87 "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml"
                                                   Write(item.ProductViewModel.Product.Name);

#line default
#line hidden
#nullable disable
                WriteLiteral("</a></td>\n                                        <td>");
#nullable restore
#line 88 "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml"
                                       Write(item.Quantity);

#line default
#line hidden
#nullable disable
                WriteLiteral(" x ");
#nullable restore
#line 88 "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml"
                                                        Write(item.ProductViewModel.Product.Price);

#line default
#line hidden
#nullable disable
                WriteLiteral(" = ");
#nullable restore
#line 88 "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml"
                                                                                               Write(item.Total);

#line default
#line hidden
#nullable disable
                WriteLiteral("</td>\n                                    </tr>\n");
#nullable restore
#line 90 "D:\eCommecre\eCommecre\Views\Home\Checkout.cshtml"
                                    }

#line default
#line hidden
#nullable disable
                WriteLiteral(@"                                </tbody>
                            </table><!-- End .table table-summary -->

                            <!--<div class=""accordion-summary"" id=""accordion-payment"">
                                <div class=""card"">
                                    <div class=""card-header"" id=""heading-1"">
                                        <h2 class=""card-title"">
                                            <a role=""button"" data-toggle=""collapse"" href=""#collapse-1"" aria-expanded=""true"" aria-controls=""collapse-1"">
                                                Direct bank transfer
                                            </a>
                                        </h2>
                                    </div>--><!-- End .card-header -->
                                    <!--<div id=""collapse-1"" class=""collapse show"" aria-labelledby=""heading-1"" data-parent=""#accordion-payment"">
                                        <div class=""card-body"">
                                     ");
                WriteLiteral(@"       Make your payment directly into our bank account. Please use your Order ID as the payment reference. Your order will not be shipped until the funds have cleared in our account.
                                        </div>--><!-- End .card-body -->
                                    <!--</div>--><!-- End .collapse -->
                                <!--</div>--><!-- End .card -->

                                <!--<div class=""card"">
                                    <div class=""card-header"" id=""heading-2"">
                                        <h2 class=""card-title"">
                                            <a class=""collapsed"" role=""button"" data-toggle=""collapse"" href=""#collapse-2"" aria-expanded=""false"" aria-controls=""collapse-2"">
                                                Check payments
                                            </a>
                                        </h2>
                                    </div>--><!-- End .card-header -->
                                  ");
                WriteLiteral(@"  <!--<div id=""collapse-2"" class=""collapse"" aria-labelledby=""heading-2"" data-parent=""#accordion-payment"">
                                        <div class=""card-body"">
                                            Ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros. Nullam malesuada erat ut turpis.
                                        </div>--><!-- End .card-body -->
                                    <!--</div>--><!-- End .collapse -->
                                <!--</div>--><!-- End .card -->

                                <!--<div class=""card"">
                                    <div class=""card-header"" id=""heading-3"">
                                        <h2 class=""card-title"">
                                            <a class=""collapsed"" role=""button"" data-toggle=""collapse"" href=""#collapse-3"" aria-expanded=""false"" aria-controls=""collapse-3"">
                                                Cash on delivery
                                         ");
                WriteLiteral(@"   </a>
                                        </h2>
                                    </div>--><!-- End .card-header -->
                                    <!--<div id=""collapse-3"" class=""collapse"" aria-labelledby=""heading-3"" data-parent=""#accordion-payment"">
                                        <div class=""card-body"">
                                            Quisque volutpat mattis eros. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volutpat mattis eros.
                                        </div>--><!-- End .card-body -->
                                    <!--</div>--><!-- End .collapse -->
                                <!--</div>--><!-- End .card -->

                                <!--<div class=""card"">
                                    <div class=""card-header"" id=""heading-4"">
                                        <h2 class=""card-title"">
                                            <a class=""collapsed"" role=""button"" data-toggle=""collapse"" href=""#collap");
                WriteLiteral(@"se-4"" aria-expanded=""false"" aria-controls=""collapse-4"">
                                                PayPal <small class=""float-right paypal-link"">What is PayPal?</small>
                                            </a>
                                        </h2>
                                    </div>--><!-- End .card-header -->
                                    <!--<div id=""collapse-4"" class=""collapse"" aria-labelledby=""heading-4"" data-parent=""#accordion-payment"">
                                        <div class=""card-body"">
                                            Nullam malesuada erat ut turpis. Suspendisse urna nibh, viverra non, semper suscipit, posuere a, pede. Donec nec justo eget felis facilisis fermentum.
                                        </div>--><!-- End .card-body -->
                                    <!--</div>--><!-- End .collapse -->
                                <!--</div>--><!-- End .card -->

                                <!--<div class=""card"">
                    ");
                WriteLiteral(@"                <div class=""card-header"" id=""heading-5"">
                                        <h2 class=""card-title"">
                                            <a class=""collapsed"" role=""button"" data-toggle=""collapse"" href=""#collapse-5"" aria-expanded=""false"" aria-controls=""collapse-5"">
                                                Credit Card (Stripe)
                                                <img src=""../assets/images/payments-summary.png"" alt=""payments cards"">
                                            </a>
                                        </h2>
                                    </div>--><!-- End .card-header -->
                                    <!--<div id=""collapse-5"" class=""collapse"" aria-labelledby=""heading-5"" data-parent=""#accordion-payment"">
                                        <div class=""card-body"">
                                            Donec nec justo eget felis facilisis fermentum.Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Donec odio. Quisque volut");
                WriteLiteral(@"pat mattis eros. Lorem ipsum dolor sit ame.
                                        </div>--><!-- End .card-body -->
                                    <!--</div>--><!-- End .collapse -->
                                <!--</div>--><!-- End .card -->
                            <!--</div>--><!-- End .accordion -->

                            <button type=""submit"" class=""btn btn-outline-primary-2 btn-order btn-block"">
                                <span class=""btn-text"">?????T H??NG</span>
                                <span class=""btn-hover-text"">?????T H??NG</span>
                            </button>
                        </div><!-- End .summary -->
                    </aside><!-- End .col-lg-3 -->
                </div><!-- End .row -->
            ");
            }
            );
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.FormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper = CreateTagHelper<global::Microsoft.AspNetCore.Mvc.TagHelpers.RenderAtEndOfFormTagHelper>();
            __tagHelperExecutionContext.Add(__Microsoft_AspNetCore_Mvc_TagHelpers_RenderAtEndOfFormTagHelper);
            __Microsoft_AspNetCore_Mvc_TagHelpers_FormTagHelper.Action = (string)__tagHelperAttribute_1.Value;
            __tagHelperExecutionContext.AddTagHelperAttribute(__tagHelperAttribute_1);
            await __tagHelperRunner.RunAsync(__tagHelperExecutionContext);
            if (!__tagHelperExecutionContext.Output.IsContentModified)
            {
                await __tagHelperExecutionContext.SetOutputContentAsync();
            }
            Write(__tagHelperExecutionContext.Output);
            __tagHelperExecutionContext = __tagHelperScopeManager.End();
            WriteLiteral("\n        </div><!-- End .container -->\n    </div><!-- End .checkout -->\n</div><!-- End .page-content -->");
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.ViewFeatures.IModelExpressionProvider ModelExpressionProvider { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IUrlHelper Url { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.IViewComponentHelper Component { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IJsonHelper Json { get; private set; }
        [global::Microsoft.AspNetCore.Mvc.Razor.Internal.RazorInjectAttribute]
        public global::Microsoft.AspNetCore.Mvc.Rendering.IHtmlHelper<eCommecre.Areas.Admin.Models.Bill> Html { get; private set; }
    }
}
#pragma warning restore 1591
