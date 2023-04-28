using atFrameWork2.BaseFramework;
using atFrameWork2.BaseFramework.LogTools;
using atFrameWork2.SeleniumFramework;
using ATframework3demo.PageObjects;

namespace ATframework3demo.TestCases
{
    public class Case_CakeMeTest : CaseCollectionBuilder
    {
        protected override List<TestCase> GetCases()
        {
            var caseCollection = new List<TestCase>();
            caseCollection.Add(new TestCase("Проверка перехода на сайт", homePage => SendToAllByDefault(homePage)));
            return caseCollection;
        }

        void SendToAllByDefault(MainPage mainPage)
        {
            Thread.Sleep(1000);
        }
    }
}
