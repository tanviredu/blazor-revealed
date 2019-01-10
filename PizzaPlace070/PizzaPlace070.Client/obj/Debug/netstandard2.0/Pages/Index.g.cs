#pragma checksum "C:\Code\Blazor\PizzaPlace070\PizzaPlace070.Client\Pages\Index.cshtml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7a2d62df63a06c53d092d65b8e57326b44a2075b"
// <auto-generated/>
#pragma warning disable 1591
namespace PizzaPlace070.Client.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Blazor;
    using Microsoft.AspNetCore.Blazor.Components;
    using System.Net.Http;
    using Microsoft.AspNetCore.Blazor.Layouts;
    using Microsoft.AspNetCore.Blazor.Routing;
    using Microsoft.JSInterop;
    using PizzaPlace070.Client;
    using PizzaPlace070.Client.Shared;
    using PizzaPlace070.Shared;
    using System.ComponentModel;
    using Microsoft.AspNetCore.Blazor.Services;
    [Microsoft.AspNetCore.Blazor.Layouts.LayoutAttribute(typeof(MainLayout))]

    [Microsoft.AspNetCore.Blazor.Components.RouteAttribute("/")]
    public class Index : Microsoft.AspNetCore.Blazor.Components.BlazorComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Blazor.RenderTree.RenderTreeBuilder builder)
        {
            base.BuildRenderTree(builder);
            builder.OpenComponent<PizzaPlace070.Client.Pages.PizzaList>(0);
            builder.AddAttribute(1, "Title", "Our selected list of pizzas");
            builder.AddAttribute(2, "Menu", Microsoft.AspNetCore.Blazor.Components.RuntimeHelpers.TypeCheck<PizzaPlace070.Shared.Menu>(State.Menu));
            builder.AddAttribute(3, "Selected", new System.Action<PizzaPlace070.Shared.Pizza>((pizza) => AddToBasket(pizza)));
            builder.AddAttribute(4, "ShowPizzaInformation", new System.Action<PizzaPlace070.Shared.Pizza>((pizza) => ShowPizzaInformation(pizza)));
            builder.CloseComponent();
            builder.AddMarkupContent(5, "\n\n\n\n\n");
            builder.OpenComponent<PizzaPlace070.Client.Pages.ShoppingBasket>(6);
            builder.AddAttribute(7, "Title", "Your current order");
            builder.AddAttribute(8, "Basket", Microsoft.AspNetCore.Blazor.Components.RuntimeHelpers.TypeCheck<PizzaPlace070.Shared.Basket>(State.Basket));
            builder.AddAttribute(9, "GetPizzaFromId", new System.Func<System.Int32, PizzaPlace070.Shared.Pizza>(State.Menu.GetPizza));
            builder.AddAttribute(10, "Selected", new System.Action<System.Int32>(pos => RemoveFromBasket(pos)));
            builder.CloseComponent();
            builder.AddMarkupContent(11, "\n\n\n\n");
            builder.OpenComponent<PizzaPlace070.Client.Pages.CustomerEntry>(12);
            builder.AddAttribute(13, "Title", "Please enter your details below");
            builder.AddAttribute(14, "Customer", Microsoft.AspNetCore.Blazor.Components.RuntimeHelpers.TypeCheck<PizzaPlace070.Shared.Customer>(State.Basket.Customer));
            builder.AddAttribute(15, "Submit", new System.Action<PizzaPlace070.Shared.Customer>(async (_) => await PlaceOrder()));
            builder.CloseComponent();
            builder.AddMarkupContent(16, "\n\n\n");
            builder.OpenElement(17, "p");
            builder.AddContent(18, State.ToJson());
            builder.CloseElement();
        }
        #pragma warning restore 1998
#line 32 "C:\Code\Blazor\PizzaPlace070\PizzaPlace070.Client\Pages\Index.cshtml"
            

protected override async Task OnInitAsync()
{
  this.State.Menu = await menuService.GetMenu();
  this.State.Basket.Customer.PropertyChanged +=
    (sender, e) => this.StateHasChanged();
}

//private State State { get; } = new State();
//{
//  Menu = new Menu
//  {
//    Pizzas = new List<Pizza>
//{
//new Pizza(1, "Pepperoni", 8.99M, Spiciness.Spicy ),
//new Pizza(2, "Margarita", 7.99M, Spiciness.None ),
//new Pizza(3, "Diabolo", 9.99M, Spiciness.Hot )
//}
//  }
//};

private string SpicinessImage(Spiciness spiciness)
=> $"images/{spiciness.ToString().ToLower()}.png";

private void AddToBasket(Pizza pizza)
{
  Console.WriteLine($"Added pizza {pizza.Name}");
  State.Basket.Add(pizza.Id);
  StateHasChanged();
}

private void RemoveFromBasket(int pos)
{
  Console.WriteLine($"Removing pizza at pos {pos}");
  State.Basket.RemoveAt(pos);
  StateHasChanged();
}

private async Task PlaceOrder()
{
  //Console.WriteLine("Placing order");
  await orderService.PlaceOrder(State.Basket);
}

private void ShowPizzaInformation(Pizza pizza)
{
  State.CurrentPizza = pizza;
  UriHelper.NavigateTo("/PizzaInfo");
}


#line default
#line hidden
        [global::Microsoft.AspNetCore.Blazor.Components.InjectAttribute] private IUriHelper UriHelper { get; set; }
        [global::Microsoft.AspNetCore.Blazor.Components.InjectAttribute] private State State { get; set; }
        [global::Microsoft.AspNetCore.Blazor.Components.InjectAttribute] private IOrderService orderService { get; set; }
        [global::Microsoft.AspNetCore.Blazor.Components.InjectAttribute] private IMenuService menuService { get; set; }
    }
}
#pragma warning restore 1591
