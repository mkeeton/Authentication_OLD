﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Castle.Windsor;

namespace Authentication.API.IOC.CastleWindsor.Factories
{
  public class WindsorHttpControllerActivator : IHttpControllerActivator
  {
    private readonly IWindsorContainer _container;
    public WindsorHttpControllerActivator(IWindsorContainer container)
    {
      _container = container;
    }

    public IHttpController Create(HttpRequestMessage request, HttpControllerDescriptor controllerDescriptor, Type controllerType)
    {
      var controller = (IHttpController)_container.Resolve(controllerType);

      request.RegisterForDispose(new Release(() => _container.Release(controller)));

      return controller;
    }

    private class Release : IDisposable
    {
      private readonly Action _release;

      public Release(Action release)
      {
        _release = release;
      }

      public void Dispose()
      {
        _release();
      }
    }
  }
}