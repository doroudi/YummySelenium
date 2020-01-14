using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Yummy.SeleniumExtensions
{
  public static class WebDriveExtensions
  {
    /// <summary>
    /// Find Element with wait
    /// </summary>
    /// <param name="driver">Selenium Driver</param>
    /// <param name="by">Selector</param>
    /// <param name="timeoutInSeconds">maximum time to wait for element</param>
    /// <returns>WebElement</returns>
    public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
    {
      if (timeoutInSeconds > 0)
      {
        var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
        return wait.Until(drv => drv.FindElement(by));
      }
      return driver.FindElement(by);
    }

    /// <summary>
    /// Get Response time of Webpage in Miliseconds
    /// </summary>
    /// <param name="driver">Selenium Driver</param>
    /// <returns>Website load time in ms</returns>
    public static int GetResponseTime(this IWebDriver driver)
    {
      IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
      var ResponseTime = Convert.ToInt32(js.ExecuteScript("return window.performance.timing.domContentLoadedEventEnd-window.performance.timing.navigationStart;"));
      return ResponseTime;
    }
  }
}