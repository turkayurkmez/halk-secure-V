using System;
using System.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InjectionAttacks
{
    public static class XSRFHelper
    {
        //1. Kullanıcı login olduğunda, istemciye rastele bir değer gönder. Aynı zamanda bu değeri sunucuda sakla
        //2. Kullanıcı bir istek gönderdiğinde 1. adımda gönderilen değeri beraberinde yollasın. 
        //3. sunucuda tutulan değer ve istemcinin gönderdiği karşılaştırılsın.
        public static void Check(Page page, HiddenField field)
        {
            if (!page.IsPostBack)
            {
                Guid guid = Guid.NewGuid();
                field.Value = guid.ToString();
                page.Session["token"] = guid;
            }
            else
            {
                Guid client = new Guid(field.Value);
                Guid server = (Guid)page.Session["token"];
                if (client != server)
                {
                    throw new SecurityException("XSRF ataği algılandı!!!");
                }
            }
        }

    }
}