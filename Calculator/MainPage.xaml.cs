using System;
using System.Linq;
using Xamarin.Forms;

namespace Calculator
{
  public partial class MainPage : ContentPage
  {
    const int MAX_DIGITS = 10;

    private string displayText;
    private bool isDisplayNegative;

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
      isDisplayNegative = false;
      displayText = string.Empty;
    }

    private void RefreshDisplay()
    {
      if(isDisplayNegative)
      {
        displayLabel.Text = "-";
      }
      else if(displayText == string.Empty)
      {
        displayLabel.Text = "0";
      }
      else
      {
        displayLabel.Text = string.Empty;
      }
        
      displayLabel.Text += displayText;

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
      if(displayText == string.Empty)
      {
        displayText = "0.";
      }
      else if(!displayText.Contains('.'))
      {
        displayText += '.';
      }
      RefreshDisplay();
    }

    private void UnaryPlusMinusButton_Clicked(object sender, EventArgs e)
    {
      if(displayText != string.Empty)
      {
        isDisplayNegative = !isDisplayNegative;
      }
      RefreshDisplay();
    }
  }
}
