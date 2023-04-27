using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.Events;


namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Страница со списком всех сайтов пользователя
    /// </summary>
    public class ShopGrid
    {
        public static WebItem sliderIframe =>
            new WebItem("//iframe[@src=\"/shop/stores/site/edit/0/?IFRAME=Y&IFRAME_TYPE=SIDE_SLIDER\"]", "Слайдер выбора шаблона магазина");


        internal bool IsShopExist(string shopAddress, string phoneNumber, string shopName)
        {
            if (new WebItem($"//div[@class=\"landing-sites__item\" " +
                $"and  .//div[@title=\"{shopName}\"] and .//div[text()=\"{shopAddress}.bitrix24shop.ru\"] " +
                $"and .//div[text()=\"{phoneNumber}\"]]", "Карточка магазина").WaitElementDisplayed())
                return true;
            return false;
        }

        internal ShopTemplatesMenu OpenShopTemplates()
        {
            new WebItem("//a[@href=\"/shop/stores/site/edit/0/\"]", "Создание магазина(переход к выбору шаблонов)").Click();
            sliderIframe.SwitchToFrame();
            return new ShopTemplatesMenu();
        }
    }
}
