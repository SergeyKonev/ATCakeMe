using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class CRMShopFirstOrderPage
    {
        public ShopGrid ToShopsGrid() 
        {
            new WebItem("//button[@id=\"landing-master-next\"]", "Кнопка Продолжить").Click();
            new WebItem("//a[@href=\"/shop/stores/\"]", "Кнопка Начать продавать").Click();
            return new ShopGrid();
        }
    }
}
