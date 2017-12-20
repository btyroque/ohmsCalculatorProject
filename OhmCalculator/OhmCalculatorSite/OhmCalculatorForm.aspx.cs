using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class OhmCalculatorForm : System.Web.UI.Page
{

    protected void calculateButton_Click(object sender, EventArgs e)
    {
        string result = new OhmCalculatorClass().CalculateOhmAndTolerance(bandAColorList.SelectedValue,
                                                                          bandBColorList.SelectedValue, 
                                                                          MultiplierBandColorList.SelectedValue, 
                                                                          ToleranceBandColorList.SelectedValue);
        ResultLabel.Text = "Resistor Value: " + result;
    }
}