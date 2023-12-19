using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultBookATablePartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
