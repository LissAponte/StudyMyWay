using System.Threading.Tasks;
using Microsoft.JSInterop;

namespace StudyMyWay.Components.Pages.Service
{
    public sealed class BrowserService
    {
        private readonly IJSRuntime _js;
        public BrowserService(IJSRuntime js) => _js = js;

        //public ValueTask Open(string url, string target = "_blank", string features = "")=> _js.InvokeVoidAsync("browser.openExternal", url, target, features);

        public async ValueTask Open(string url,string target = "_blank", string features = "")
        {
            await _js.InvokeVoidAsync("browser.openExternal", url, target, features);
        }
    }
}
