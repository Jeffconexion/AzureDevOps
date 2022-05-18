﻿using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Alura.ByteBank.WebApp.Testes.Util
{
  public class Fixture : IDisposable
  {
    public IWebDriver Driver { get; private set; }
    public Fixture()
    {
      Driver = new ChromeDriver(Helper.CaminhoDriverNavegador());
    }
    public void Dispose()
    {
      Driver.Quit();
    }
  }
}
