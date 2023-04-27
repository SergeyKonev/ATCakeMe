using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium.DevTools.V108.Network;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Страница с информацией о товарах нового магазина
    /// </summary>
    public class CRMShopProductsDetailsPage
    {
        public CRMShopProductsGridExample OpenProductsGridExample()
        {
            new WebItem("//a[contains(@href, \"/crm/catalog/list\") and @target=\"_blank\"]", "Посмотреть товары").Click();
            DriverActions.SwitchToDefaultContent();
            new WebItem("//iframe[contains(@src,\"/crm/catalog/list/\")]", "Фрейм каталога").SwitchToFrame();
            return new CRMShopProductsGridExample();
        }

        public CRMShopFirstOrderPage ToFirstOrderPage()
        {
            new WebItem("//button[@id=\"landing-master-next\"]", "Продолжить").Click();
            return new CRMShopFirstOrderPage();
        }
    }
}
