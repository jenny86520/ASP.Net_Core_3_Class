#pragma checksum "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\Pages\FetchData.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "000e3cff5720d0ffbc6779a53fbde65843f60745"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace web6.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using web6;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\_Imports.razor"
using web6.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\Pages\FetchData.razor"
using web6.Data;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/fetchdata")]
    public class FetchData : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 39 "d:\work\教材\課程\ASP.NET Core 3 開發實戰：從入門到進階\Source\1207\web\web6\Pages\FetchData.razor"
       
    WeatherForecast[] forecasts;

    protected override async Task OnInitializedAsync()
    {
        forecasts = await ForecastService.GetForecastAsync(DateTime.Now);
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private WeatherForecastService ForecastService { get; set; }
    }
}
#pragma warning restore 1591
