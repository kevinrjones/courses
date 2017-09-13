using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.Threading;

[WebService(Namespace = "http://www.develop.com/StockService/1")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class StockService : System.Web.Services.WebService
{
    private static Random rnd = new Random();

    public StockService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public double GetQuote(string symbol)
    {
        Thread.Sleep(2000);
        double amount = rnd.NextDouble() * 100.0;

        return amount;
    }
    
}
