using OpenQA.Selenium;
using System;
namespace Yummy.SeleniumExtensions
{
  public static class WebElementExtensions
  {
    /// <summary>
    /// Check for image is loaded correctly
    /// </summary>
    /// <param name="element">WebElement</param>
    /// <param name="driver">Selenium Driver</param>
    /// <returns>If image loaded returns true otherwise returns false</returns>
    public static bool IsImageLoaded(this IWebElement element, IWebDriver driver)
    {
      Object result = ((IJavaScriptExecutor)driver).ExecuteScript(
            "return arguments[0].complete && " +
            "typeof arguments[0].naturalWidth != \"undefined\" && " +
            "arguments[0].naturalWidth > 0", element);

      bool loaded = false;
      if (result is bool)
      {
        loaded = (bool)result;
        return loaded;
      }
      return false;
    }
  }
}