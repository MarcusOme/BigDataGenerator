#pragma checksum "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "8d41b8e00786d345fd91c365344efdd3e7693382"
// <auto-generated/>
#pragma warning disable 1591
namespace BigData.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#line 1 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#line 2 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#line 3 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Layouts;

#line default
#line hidden
#line 4 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#line 5 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#line 6 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\_Imports.razor"
using BigData.Client;

#line default
#line hidden
#line 7 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\_Imports.razor"
using BigData.Client.Shared;

#line default
#line hidden
#line 2 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
using BigData.Shared.Models;

#line default
#line hidden
#line 3 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
using BigData.Shared;

#line default
#line hidden
    [Microsoft.AspNetCore.Components.Layouts.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.RenderTree.RenderTreeBuilder builder)
        {
            builder.AddMarkupContent(0, "<h1>Create and configure</h1>\r\n");
            builder.OpenElement(1, "div");
            builder.AddAttribute(2, "class", "row p-1 mb-2");
            builder.AddMarkupContent(3, "\r\n    ");
            builder.AddMarkupContent(4, "<div class=\"col-8\">\r\n        <p>Create Users inside database</p>\r\n    </div>\r\n    ");
            builder.OpenElement(5, "div");
            builder.AddAttribute(6, "class", "col-2 text-right");
            builder.AddMarkupContent(7, "\r\n        ");
            builder.OpenElement(8, "button");
            builder.AddAttribute(9, "class", "btn btn-success");
            builder.AddAttribute(10, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 12 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
                                                   CreateUsers

#line default
#line hidden
            ));
            builder.AddContent(11, "CREATE");
            builder.CloseElement();
            builder.AddMarkupContent(12, "\r\n    ");
            builder.CloseElement();
            builder.AddMarkupContent(13, "\r\n    ");
            builder.OpenElement(14, "div");
            builder.AddAttribute(15, "class", "col-1");
            builder.AddMarkupContent(16, "\r\n");
#line 15 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
         if (loading_user)
        {

#line default
#line hidden
            builder.AddMarkupContent(17, "            <div class=\"loader\"></div>\r\n");
#line 18 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
        }
        else
        {

#line default
#line hidden
            builder.AddMarkupContent(18, "            <div class=\"loader no-display\"></div>\r\n");
#line 22 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
        }

#line default
#line hidden
            builder.AddContent(19, "    ");
            builder.CloseElement();
            builder.AddMarkupContent(20, "\r\n");
#line 24 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
     if (user_end)
    {

#line default
#line hidden
            builder.AddContent(21, "        ");
            builder.AddMarkupContent(22, "<div class=\"col-1 text-right\"><span class=\"oi oi-check\" aria-hidden=\"true\"></span></div>\r\n");
#line 27 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
    }
    else
    {

#line default
#line hidden
            builder.AddMarkupContent(23, "        <div class=\"col-1\"></div>\r\n");
#line 31 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
    }

#line default
#line hidden
            builder.CloseElement();
            builder.AddMarkupContent(24, "\r\n\r\n");
            builder.OpenElement(25, "div");
            builder.AddAttribute(26, "class", "row p-1 mb-2");
            builder.AddMarkupContent(27, "\r\n    ");
            builder.AddMarkupContent(28, "<div class=\"col-8\">\r\n        <p>Create Product inside database</p>\r\n    </div>\r\n    ");
            builder.OpenElement(29, "div");
            builder.AddAttribute(30, "class", "col-2 text-right");
            builder.AddMarkupContent(31, "\r\n        ");
            builder.OpenElement(32, "button");
            builder.AddAttribute(33, "class", "btn btn-success");
            builder.AddAttribute(34, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 39 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
                                                   CreateProducts

#line default
#line hidden
            ));
            builder.AddContent(35, "CREATE");
            builder.CloseElement();
            builder.AddMarkupContent(36, "\r\n    ");
            builder.CloseElement();
            builder.AddMarkupContent(37, "\r\n    ");
            builder.OpenElement(38, "div");
            builder.AddAttribute(39, "class", "col-1");
            builder.AddMarkupContent(40, "\r\n");
#line 42 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
         if (loading_product)
        {

#line default
#line hidden
            builder.AddMarkupContent(41, "            <div class=\"loader\"></div>\r\n");
#line 45 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
        }
        else
        {

#line default
#line hidden
            builder.AddMarkupContent(42, "            <div class=\"loader no-display\"></div>\r\n");
#line 49 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
        }

#line default
#line hidden
            builder.AddContent(43, "    ");
            builder.CloseElement();
            builder.AddMarkupContent(44, "\r\n");
#line 51 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
     if (prod_end)
    {

#line default
#line hidden
            builder.AddContent(45, "        ");
            builder.AddMarkupContent(46, "<div class=\"col-1 text-right\"><span class=\"oi oi-check\" aria-hidden=\"true\"></span></div>\r\n");
#line 54 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
    }
    else
    {

#line default
#line hidden
            builder.AddMarkupContent(47, "        <div class=\"col-1\"></div>\r\n");
#line 58 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
    }

#line default
#line hidden
            builder.CloseElement();
            builder.AddMarkupContent(48, "\r\n\r\n");
            builder.OpenElement(49, "div");
            builder.AddAttribute(50, "class", "row p-1 mb-2");
            builder.AddMarkupContent(51, "\r\n    ");
            builder.AddMarkupContent(52, "<div class=\"col-8\">\r\n        <p>Create Purchases inside database (only initial purchase)</p>\r\n    </div>\r\n    ");
            builder.OpenElement(53, "div");
            builder.AddAttribute(54, "class", "col-2 text-right");
            builder.AddMarkupContent(55, "\r\n        ");
            builder.OpenElement(56, "button");
            builder.AddAttribute(57, "class", "btn btn-success");
            builder.AddAttribute(58, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 66 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
                                                   CreatePurchase

#line default
#line hidden
            ));
            builder.AddContent(59, "CREATE");
            builder.CloseElement();
            builder.AddMarkupContent(60, "\r\n    ");
            builder.CloseElement();
            builder.AddMarkupContent(61, "\r\n    ");
            builder.OpenElement(62, "div");
            builder.AddAttribute(63, "class", "col-1");
            builder.AddMarkupContent(64, "\r\n");
#line 69 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
         if (loading_purchase)
        {

#line default
#line hidden
            builder.AddMarkupContent(65, "            <div class=\"loader\"></div>\r\n");
#line 72 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
        }
        else
        {

#line default
#line hidden
            builder.AddMarkupContent(66, "            <div class=\"loader no-display\"></div>\r\n");
#line 76 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
        }

#line default
#line hidden
            builder.AddContent(67, "    ");
            builder.CloseElement();
            builder.AddMarkupContent(68, "\r\n");
#line 78 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
     if (purchase_end)
    {

#line default
#line hidden
            builder.AddContent(69, "        ");
            builder.AddMarkupContent(70, "<div class=\"col-1 text-right\"><span class=\"oi oi-check\" aria-hidden=\"true\"></span></div>\r\n");
#line 81 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
    }
    else
    {

#line default
#line hidden
            builder.AddMarkupContent(71, "        <div class=\"col-1\"></div>\r\n");
#line 85 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
    }

#line default
#line hidden
            builder.CloseElement();
            builder.AddMarkupContent(72, "\r\n<br>\r\n");
            builder.OpenElement(73, "div");
            builder.AddAttribute(74, "class", "machine-learning-purchase");
            builder.AddMarkupContent(75, "\r\n    ");
            builder.AddMarkupContent(76, "<h3>Purchase Learning</h3>\r\n    ");
            builder.AddMarkupContent(77, "<p>Populate with more purchase using a reccomendation algorithm (to better simulate a real world scenario):</p>\r\n    ");
            builder.OpenElement(78, "button");
            builder.AddAttribute(79, "class", "btn btn-warning");
            builder.AddAttribute(80, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.UIMouseEventArgs>(this, 
#line 91 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
                                               ModelLearn

#line default
#line hidden
            ));
            builder.AddContent(81, "START LEARNING");
            builder.CloseElement();
            builder.AddMarkupContent(82, "\r\n    <br><br>\r\n");
#line 93 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
     if (training)
    {
    

#line default
#line hidden
            builder.AddContent(83, "    ");
            builder.OpenElement(84, "div");
            builder.AddAttribute(85, "class", "row p-1 mb-2");
            builder.AddMarkupContent(86, "\r\n        ");
            builder.AddMarkupContent(87, "<div class=\"col-8\">Inserting purchase after creating ML model</div>\r\n        ");
            builder.OpenElement(88, "div");
            builder.AddAttribute(89, "class", "col-1");
            builder.AddMarkupContent(90, "\r\n");
#line 99 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
             if (creating_ml_purchase)
            {

#line default
#line hidden
            builder.AddMarkupContent(91, "                <div class=\"loader\"></div>\r\n");
#line 102 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
            }
            else
            {

#line default
#line hidden
            builder.AddMarkupContent(92, "                <div class=\"loader no-display\"></div>\r\n");
#line 106 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
            }

#line default
#line hidden
            builder.AddContent(93, "        ");
            builder.CloseElement();
            builder.AddMarkupContent(94, "\r\n");
#line 108 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
         if (insert_end)
        {

#line default
#line hidden
            builder.AddContent(95, "            ");
            builder.AddMarkupContent(96, "<div class=\"col-1 text-right\"><span class=\"oi oi-check\" aria-hidden=\"true\"></span></div>\r\n");
#line 111 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
        }
        else
        {

#line default
#line hidden
            builder.AddMarkupContent(97, "            <div class=\"col-1\"></div>\r\n");
#line 115 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
        }

#line default
#line hidden
            builder.AddContent(98, "    ");
            builder.CloseElement();
            builder.AddMarkupContent(99, "\r\n");
#line 117 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
    }

#line default
#line hidden
            builder.CloseElement();
        }
        #pragma warning restore 1998
#line 119 "C:\Users\Marco\Documents\BigDataGenerator\WebApp\BigData.Client\Pages\Index.razor"
       
//call the server to create the data

Message message;

bool loading_user = false;
bool loading_product = false;
bool loading_purchase = false;

bool user_end = false;
bool prod_end = false;
bool purchase_end = false;

public async Task CreateUsers()
{
    //call to server method to create the users
    loading_user = true;
    message = await Http.GetJsonAsync<Message>("api/CoreUser/InsertUserAction");
    loading_user = false;
    user_end = true;
    base.StateHasChanged();
}

protected async Task CreateProducts()
{
    //creating products
    loading_product = true;
    Message msg_prod = await Http.GetJsonAsync<Message>("api/CoreProduct/InsertProductAction");
    loading_product = false;
    prod_end = true;
    base.StateHasChanged();
}

protected async Task CreatePurchase()
{
    //creating purchase
    loading_purchase = true;
    Message msg_prod = await Http.GetJsonAsync<Message>("api/CorePurchase/InsertPurchaseAction");
    loading_purchase = false;
    purchase_end = true;
    base.StateHasChanged();
}


//train the model
bool loading_ml_model = false;
bool train_end = false;
bool training = false;
bool creating_ml_purchase = false;
bool insert_end = false;
protected async Task ModelLearn()
{
    training = true;

    creating_ml_purchase = true;
    Message msg_insert = await Http.GetJsonAsync<Message>("api/CorePurchase/ModelInsert");
    creating_ml_purchase = false;
    insert_end = true;

    base.StateHasChanged();
}


#line default
#line hidden
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient Http { get; set; }
    }
}
#pragma warning restore 1591
