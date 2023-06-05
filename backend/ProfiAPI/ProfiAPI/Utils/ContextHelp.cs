using Microsoft.EntityFrameworkCore;
using ProfiAPI.Data.IF;
using ProfiAPI.Data.Models;

namespace ProfiAPI.Utils
{
    public static class ContextHelp
    {
        #region NULL CHECKING

        public static bool NullCheck(ApplicationDbContext _context)
        {
            return _context == null || _context.Services == null;
        }

        #endregion

        #region GET

        public static async Task<List<T>> FindItemsAsync<T>(ApplicationDbContext context)
                                                            where T : class
        {
            return await context.Set<T>().ToListAsync();
        }

        public static async Task<T> FindItemAsync<T>(int id, ApplicationDbContext context)
                                                    where T : class
        {
            var item = await context.Set<T>().FindAsync(id);

            if (item != null)
                return item;
            else
                return null;
        }

        #endregion

        #region UPDATE

        public static async Task UpdateAndSave<T>
                                (ApplicationDbContext _context, T entity) where T : class
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        #endregion

        #region DELETE

        public static async Task RemoveAndSave<T>
                                (ApplicationDbContext context, T entity) where T : class
        {
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        #endregion

        #region POST

        public static async Task AddAndSave<T>(ApplicationDbContext context, 
                                                T entity) where T : class
        {
            if(entity != null)
            {
                await context.Set<T>().AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }

        #endregion
    }
}
