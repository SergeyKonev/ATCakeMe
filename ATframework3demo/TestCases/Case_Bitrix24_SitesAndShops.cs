using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.PageObjects;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;
using System.ComponentModel.DataAnnotations;

namespace ATframework3demo.TestCases
{
    public class Case_Bitrix24_SitesAndShops : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Создание магазина", homePage => CreateShop(homePage)));
            return caseCollection;
        }

        void CreateShop(PortalHomePage homePage)
        {
            string phoneNumber = "+" + DateTime.Now.Ticks;
            string shopName = "TestShop" + DateTime.Now;
            string shopAddress;

            CRMShopContactDetailsPage shopContactDetailsPage = homePage.LeftMenu.
                OpenSitesAndShops().
                OpenShops().
                OpenShopTemplates().CreateCrmAndOnlineStore();//переход на страницу магазинов, выбор шаблона для создания

            shopContactDetailsPage.EnterPhoneNumber(phoneNumber);
            shopContactDetailsPage.EnterShopName(shopName);
            shopAddress = shopContactDetailsPage.GetAdress();

            if (!shopContactDetailsPage.IsAdressValid())
            {
                Log.Error("Не работает автоматическая генерация адреса магазина");
                return;
            }
            CRMShopProductsDetailsPage shopProductsDetailsPage = shopContactDetailsPage.ToProductsDetails();//переход на страницу товаров

            //Проверка наличия демо-товаров
            CRMShopProductsGridExample productsGridExample = shopProductsDetailsPage.OpenProductsGridExample();
            if (!productsGridExample.IsProductExampleExist())
                Log.Error("Не отображаются демо-товары в каталоге товаров");
            productsGridExample.Close();

            ShopGrid shopsGrid = shopProductsDetailsPage.ToFirstOrderPage().ToShopsGrid();//завершение создания магазина, переход к списку магазинов
            if (!shopsGrid.IsShopExist(shopAddress, phoneNumber, shopName))//проверка отображения созданного магазина в гриде
                Log.Error("Магазин не создался, либо отображаемые данные не соответствуют введенным");

            DriverActions.OpenUri(new Uri("https://"+shopAddress+ ".bitrix24shop.ru"));//переход на страницу сайта

            if (new CRMShopSite().IsInformationValid(shopName, phoneNumber))
                Log.Info("Страница магазина доступна для просмотра");
            else
                Log.Error("Страница недоступна(возможно на портале включен демо-режим и доступно не более 1 сайта), либо на странице отображается некорректная информация");

        }
    }
}
