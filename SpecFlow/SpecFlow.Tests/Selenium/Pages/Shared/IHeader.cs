using SpecFlow.Tests.Selenium.Pages.About;
using SpecFlow.Tests.Selenium.Pages.Contacts;
using SpecFlow.Tests.Selenium.Pages.Form;
using SpecFlow.Tests.Selenium.Pages.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Tests.Selenium.Pages.Shared
{
    internal interface IHeader
    {
        HomePage GoHome();
        AboutPage GoToAbout();
        ContactsPage GoToContacts();
        CreateFormPage GoToCreateForm();
    }
}
