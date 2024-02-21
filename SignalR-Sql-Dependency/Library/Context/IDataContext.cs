﻿using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Context
{
    public interface IDataContext
    {
        IEnumerable<EntityEntry> GetChangeTrackerEntries();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        EntityEntry Entry(object entity);

        int SaveChanges();

        Task<int> SaveChangesAsync();

        DatabaseFacade Database { get; }
    }
}
