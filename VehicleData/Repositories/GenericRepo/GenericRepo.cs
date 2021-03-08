using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using VehicleData.Models;

namespace VehicleData.Repositories.GenericRepo
{
    public abstract class GenericRepo<T>:IGenericRepo<T> where T :class
    {
        protected VehicleTrackingContext vehicleTrackingContext { get; set; }
        public GenericRepo(VehicleTrackingContext repositoryContext)
        {
            this.vehicleTrackingContext = repositoryContext;
        }
        public IQueryable<T> FindAll()
        {
            return this.vehicleTrackingContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this.vehicleTrackingContext.Set<T>().Where(expression).AsNoTracking();
        }
        public void Create(T entity)
        {
            this.vehicleTrackingContext.Set<T>().AddAsync(entity);
        }
        public void Update(T entity)
        {
            this.vehicleTrackingContext.Set<T>().Update(entity);
        }
        public void Delete(T entity)
        {
            this.vehicleTrackingContext.Set<T>().Remove(entity);
        }
    }
}
