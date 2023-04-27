using atFrameWork2.SeleniumFramework;

namespace ATframework3demo.PageObjects
{
    public class CRMShopSite
    {
        /// <summary>
        /// Проверка информации на сайте магазина
        /// </summary>
        /// <param name="shopName"></param>
        /// <param name="phoneNumber"></param>
        /// <returns></returns>
        public bool IsInformationValid(string shopName, string phoneNumber)
        {
            if (new WebItem($"//header[ .//a[contains(text(),\"{shopName}\")] and .//span[contains(text(),\"{phoneNumber}\")]]", "Шапка сайта").WaitElementDisplayed())
                return true;   
            return false;
        }
    }
}