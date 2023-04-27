using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace atFrameWork2.PageObjects
{
    public class SiteAndShopListPage
    {
        public ShopGrid OpenShops()
        {
            new WebItem("//a[@href=\"/shop/stores/\"]", "Вкладка магазины").Click();            
            return new ShopGrid();
        }
    }
}