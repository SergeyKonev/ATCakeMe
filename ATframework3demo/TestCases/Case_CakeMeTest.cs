using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;
using OpenQA.Selenium;

namespace ATframework3demo.TestCases
{
    public class Case_CakeMeTest : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Проверка перехода на сайт", (mainPage, info) => SiteOpened(mainPage)));
            return caseCollection;
        }

        void SiteOpened(MainPage mainPage)
        {
            //TODO - Сделать проверку названия сайта во вкладке
        }
    }
}
