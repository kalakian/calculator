using System;
using System.Linq;
using Xamarin.Forms;

namespace Calculator
{
  public partial class MainPage : ContentPage
  {
    const int MAX_DIGITS = 10;

    private string displayText;

    public MainPage()
    {
      InitializeComponent();
    }

    protected override void OnAppearing()
    {
      base.OnAppearing();

      ClearDisplay();
      RefreshDisplay();
    }

    private void ClearDisplay()
    {
      displayText = "0";
    }

    private void RefreshDisplay()
    {
      displayLabel.Text = displayText;
      if(!displayText.Contains('.'))
      {
        displayLabel.Text += '.';
      }
    }

    private void DigitButton_Clicked(object sender, EventArgs e)
    {
      if(displayText.Count(char.IsDigit) == MAX_DIGITS)
        return;

      if(displayText == "0")
      {
        displayText = (sender as Button).Text;
      }
      else
      {
        displayText += (sender as Button).Text;
      }
      RefreshDisplay();
    }

    private void ClearButton_Clicked(object sender, EventArgs e)
    {
      ClearDisplay();
      RefreshDisplay();
    }

    private void DecimalPointButton_Clicked(object sender, EventArgs e)
    {
      if(!displayText.Contains('.'))
      {
        displayText += '.';
      }
    }
  }
}
