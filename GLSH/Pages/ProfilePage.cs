using GLSH.Common;

namespace GLSH.Pages
{
    class ProfilePage
    {
        cmn Common = new cmn();

        public void goToStore()
        {            
            Common.clickButton("Online Store", "id", "wp-admin-bar-site-name");
        }
    }
}
