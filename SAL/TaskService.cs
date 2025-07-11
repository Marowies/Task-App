using TaskApp.DAL;
using TaskApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskApp.SAL
{
    public class TaskService
    {
        private readonly AppDbContext _context;

        public TaskService(AppDbContext context)
        {
            _context = context;
        }
             
        public IEnumerable<TaskItem> GetAll()
        {
            return _context.Tasks.ToList();
        }

        public async Task<TaskItem?> GetByIdAsync(int id)
        {
            return await _context.Tasks.FindAsync(id);
        }

        public async Task<TaskItem> CreateAsync(TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
            return task;
        }

        public async Task<bool> UpdateAsync(TaskItem task)
        {
            _context.Tasks.Update(task);
            var saved = await _context.SaveChangesAsync();
            return saved > 0;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null) return false;

            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
