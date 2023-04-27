using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Список шаблонов для нового магазина
    /// </summary>
    public class ShopTemplatesMenu
    {
        public CRMShopContactDetailsPage CreateCrmAndOnlineStore()
        {
            new WebItem("//span[@id=\"landing-demo-store_v3/mainpage\"]", "Создание магазина").Click();
            DriverActions.SwitchToDefaultContent();
            new WebItem("//iframe[@src=\"/shop/stores/site/edit/0/?super=Y&IFRAME=Y&IFRAME_TYPE=SIDE_SLIDER\"]", "Слайдер с подтверждением").SwitchToFrame();
            new WebItem("//form[@action=\"/shop/stores/site/edit/0/?super=Y&IFRAME=Y&IFRAME_TYPE=SIDE_SLIDER&action=create\"]", "Кнопка Создать магазин в 1 клик").Click();
            new WebItem("//input[@value=\"Company24\"]", "Название магазина").WaitElementDisplayed(20);
            return new CRMShopContactDetailsPage();
        }
    }
}
