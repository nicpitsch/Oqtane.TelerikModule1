using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace My.Module.TelerikModule1
{
    public class Interop
    {
        private readonly IJSRuntime _jsRuntime;

        public Interop(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }
    }
}
