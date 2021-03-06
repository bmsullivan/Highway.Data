using System;
using System.Collections.Generic;
using System.Linq;
using Highway.Data.Interceptors.Events;

namespace Highway.Data.Interfaces
{
    /// <summary>
    /// The interface used to surface events from a context that supports interceptors
    /// </summary>
    public interface IObservableDataContext : IDataContext
    {
        /// <summary>
        /// The event fired just before the commit of the ORM
        /// </summary>
        event EventHandler<PreSaveEventArgs> PreSave;
        /// <summary>
        /// The event fired just after the commit of the ORM
        /// </summary>
        event EventHandler<PostSaveEventArgs> PostSave;
    }
}
