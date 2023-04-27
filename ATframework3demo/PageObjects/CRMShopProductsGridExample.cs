using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium.DevTools.V108.Browser;
using OpenQA.Selenium.Internal;

namespace ATframework3demo.PageObjects
{
    public class CRMShopProductsGridExample
    {
        public void Close()
        {
            DriverActions.SwitchToDefaultContent();
            new WebItem("//div[@title=\"Закрыть\" and ./../../..//iframe[contains(@src,\"/crm/catalog/list\")]]", "Кнопка закрытия").Click();
            new WebItem("//iframe[@src=\"/shop/stores/site/edit/0/?super=Y&IFRAME=Y&IFRAME_TYPE=SIDE_SLIDER\"]", "Слайдер с подтверждением").SwitchToFrame();
        }

        /// <summary>
        /// Проверка на то, что хотя бы 1 образец товара присутствует 
        /// </summary>
        /// <returns></returns>
        public bool IsProductExampleExist()
        {
            if (new WebItem("//tr[.//a[@title=\"Наименование товара\"] and .//img]", "Демо-товар").WaitElementDisplayed())
                return true;
            return false; 

        }
    }
}
