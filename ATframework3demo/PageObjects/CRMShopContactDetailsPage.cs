using atFrameWork2.SeleniumFramework;
using OpenQA.Selenium;

namespace ATframework3demo.PageObjects
{
    /// <summary>
    /// Страница заполнения контактной информации нового магазина
    /// </summary>
    public class CRMShopContactDetailsPage
    {
        public CRMShopProductsDetailsPage ToProductsDetails()
        {
            new WebItem("//button[@id=\"landing-master-next\"]", "Кнопка продолжить").Click();
            return new CRMShopProductsDetailsPage();
           
        }
        public void EnterPhoneNumber(string phoneNum)
        {
            var phoneNumField = new WebItem("//input[@name=\"PHONE\"]", "Поле ввода номера телефона");
            phoneNumField.SendKeys(Keys.Control + "a");
            phoneNumField.SendKeys(Keys.Delete);
            phoneNumField.SendKeys(phoneNum);
        }

        public void EnterShopName(string shopName)
        {
            var shopNameField = new WebItem("//input[@name=\"COMPANY\"]", "Поле ввода названия");
            shopNameField.SendKeys(Keys.Control + "a");
            shopNameField.SendKeys(Keys.Delete);
            shopNameField.SendKeys(shopName);

        }

        public string GetAdress()
        {
            return new WebItem("//input[@name=\"SUBDOMAIN\"]", "Адрес сайта").GetAttribute("value");
        }


        public bool IsAdressValid()
        {
            var alert = new WebItem("//div[@id=\"domain-edit-message\"]", "Уведомление о доступности домена");
            if (alert.InnerText() == "Данный домен доступен для регистрации!")
                return true;
            else 
                return false;
        }
    }
}
