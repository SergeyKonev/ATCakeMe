using atFrameWork2.SeleniumFramework;
using atFrameWork2.TestEntities;

namespace ATframework3demo.PageObjects;

public class DetailPage
{
    public Recipe GetRecipeInfo()
    {
        //return new Recipe();
        return null;
    }

    public ProfilePage OpenAuthorProfilePage()
    {
        new WebItem("//p[@class=\"title is-4\"]/a", "Переход на страницу автора").Click();
        return new ProfilePage();
    }
}