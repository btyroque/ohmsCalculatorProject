using System.Web.Mvc;

namespace OhmCalculatorWeb.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new OhmViewModel { Message = "", OhmValue = "" };
            return View(model);
        }

        [HttpPost]
        public ActionResult Index(string bandAColorList, string bandBColorList, string MultiplierBandColorList, string ToleranceBandColorList)
        {
            string ohms = "";
            string message = "";
            string BandAColorSelected = "Brown";
            string BandBColorSelected = "Black";
            string MultiplierBandColorSelected = "Black";
            string ToleranceBandColorSelected = "Brown";
            if (bandAColorList != null && bandBColorList != null && MultiplierBandColorList != null && ToleranceBandColorList != null)
            {
                try
                {
                    ohms = new OhmCalculatorClass().CalculateOhmAndTolerance(bandAColorList, bandBColorList, MultiplierBandColorList, ToleranceBandColorList);
                    message = "Resistor Value:";
                    BandAColorSelected = bandAColorList;
                    BandBColorSelected = bandBColorList;
                    MultiplierBandColorSelected = MultiplierBandColorList;
                    ToleranceBandColorSelected = ToleranceBandColorList;
                }
                catch (ResistorBandColorException)
                {
                    message = "Wrong color band configuration";
                }                
            }
            var model = new OhmViewModel { Message = message,
                                           OhmValue = ohms,
                                           BandAColorSelected = BandAColorSelected,
                                           BandBColorSelected = BandBColorSelected,
                                           MultiplierBandColorSelected = MultiplierBandColorSelected,
                                           ToleranceBandColorSelected = ToleranceBandColorSelected,
            };

            return View(model);
        }
    }

    public class OhmViewModel
    {
        public string OhmValue { get; set; }

        public string Message { get; set; }

        public string BandAColorSelected { get; set; }

        public string BandBColorSelected { get; set; }

        public string MultiplierBandColorSelected { get; set; }

        public string ToleranceBandColorSelected { get; set; }
    }
}