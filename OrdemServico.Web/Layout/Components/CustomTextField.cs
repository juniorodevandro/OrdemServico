using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace OrdemServico.Web.Layout.Components
{
    public class CustomTextField : MudTextField<string>
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.Variant = Variant.Outlined;
        }
    }    
    
    public class CustomNumericField : MudTextField<decimal>
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.Variant = Variant.Outlined;
        }
    }    
    
    public class CustomIntField : MudTextField<int>
    {
        protected override void OnInitialized()
        {
            base.OnInitialized();

            this.Variant = Variant.Outlined;
        }
    }
}