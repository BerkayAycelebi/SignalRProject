using Microsoft.AspNetCore.Mvc;

namespace SignalRWebUI.ViewComponents.DefaultComponents
{
    public class _DefaultOurMenuPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
