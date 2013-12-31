﻿using System;
using DataExplorer.Domain.Views;

namespace DataExplorer.Persistence.Views
{
    public class ViewRepository : IViewRepository
    {
        private readonly IDataContext _viewContext;

        public ViewRepository(IDataContext viewContext)
        {
            _viewContext = viewContext;
        }

        public T Get<T>() where T : IView, new()
        {
            if (!_viewContext.Views.ContainsKey(typeof(T)))
            {
                var view = new T();
                _viewContext.Views.Add(typeof(T), view);
            }

            return (T) _viewContext.Views[typeof(T)];
        }

        public void Set<T>(T view) where T : IView
        {
            _viewContext.Views[typeof(T)] = view;
        }
    }
}
