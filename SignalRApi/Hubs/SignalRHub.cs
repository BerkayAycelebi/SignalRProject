using Microsoft.AspNetCore.SignalR;
using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;

namespace SignalRApi.Hubs
{
    public class SignalRHub:Hub
    {

        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
		private readonly IOrderService _orderService;
		private readonly IMoneyCaseService _moneyCaseService;
		private readonly IMenuTableService _menuTableService;
		private readonly IBookingService _bookingService;
		private readonly INotificationService _notificationService;

		public SignalRHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
		{
			_categoryService = categoryService;
			_productService = productService;
			_orderService = orderService;
			_moneyCaseService = moneyCaseService;
			_menuTableService = menuTableService;
			_bookingService = bookingService;
			_notificationService = notificationService;
		}

		public async Task SendStatistic()
        {
            var valueCategory = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", valueCategory);
			
			var valueProductCount = _productService.TProductCount();
			await Clients.All.SendAsync("ReceiveProductCount", valueProductCount);
		
			var ActiveCategoryValue = _categoryService.TActiveCategoryCount();
			var PassiveCategoryValue = _categoryService.TPassiveCategoryCount();
			await Clients.All.SendAsync("ReceiveActiveCategorytCount", ActiveCategoryValue);
			await Clients.All.SendAsync("ReceivePassiveCategorytCount", PassiveCategoryValue);
		
			var ProductCountByHamburger=_productService.TProductCountByCategoryNameHamburger();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", ProductCountByHamburger);

			var ProductCountByDrinks = _productService.TProductCountByCategoryNameDrink();
			await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink",ProductCountByDrinks);


			var ProductPriceAvg = _productService.TProductPriceAvg();
			await Clients.All.SendAsync("ReceiveProductPriceAvg", ProductPriceAvg.ToString("0.00")+" "+"₺");

			var ProductNameByMaxPrice = _productService.TProductNameByMaxPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", ProductNameByMaxPrice);

			var value9 = _productService.TProductNameByMinPrice();
			await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value9);

			var value10 = _productService.TProductPriceByHamburger();
			await Clients.All.SendAsync("ReceiveProductAvgPriceByHamburger", value10.ToString("0.00") + "₺");

			var value11 = _orderService.TTotalOrderCount();
			await Clients.All.SendAsync("ReceiveTotalOrderCount", value11);

			var value12 = _orderService.TActiveOrderCount();
			await Clients.All.SendAsync("ReceiveActiveOrderCount", value12);

			var value13 = _orderService.TLastOrderPrice();
			await Clients.All.SendAsync("ReceiveLastOrderPrice", value13.ToString("0.00") + "₺");

			var value14 = _moneyCaseService.TTotalMoneyCaseAmount();
			await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value14.ToString("0.00") + "₺");

			var value16 = _menuTableService.TMenuTableCount();
			await Clients.All.SendAsync("ReceiveMenuTableCount", value16);




		}

		public async Task SendProgress()
		{

            var value = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + "₺");

            var value2 = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveTActiveOrderCount", value2);

            var value3 = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value3);



        }

		public async Task GetbookingList()
		{
			var values = _bookingService.TGetListAll();
			await Clients.All.SendAsync("ReceiveBookingList", values);
		}

		public async Task SendNotification()
		{
			var value=_notificationService.TNotificationCountByStatusFalse();
			await Clients.All.SendAsync("ReceiveNotificationCountByFalse", value);

			var notificationList=_notificationService.TGetAllNotificationByFalse();
			await Clients.All.SendAsync("ReceiveNotificationListbyFalse", notificationList);
		}


    }
}
