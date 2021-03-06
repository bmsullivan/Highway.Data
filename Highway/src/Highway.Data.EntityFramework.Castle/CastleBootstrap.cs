﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Highway.Data.EventManagement;
using Highway.Data.Interfaces;

namespace Highway.Data.NHibernate.Castle
{
    /// <summary>
    /// Castle specific bootstrap for installing types needed for usage to the current container
    /// </summary>
    public class CastleBootstrap : IWindsorInstaller
    {
        /// <summary>
        /// Performs the installation in the <see cref="T:Castle.Windsor.IWindsorContainer"/>.
        /// </summary>
        /// <param name="container">The container.</param><param name="store">The configuration store.</param>
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Kernel.Resolver.AddSubResolver(new ArrayResolver(container.Kernel));
            container.Register(
                Component.For<IEventManager>().ImplementedBy<EventManager>()
                );
        }
    }
}
