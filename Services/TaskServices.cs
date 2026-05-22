using System;
using System.Collections.Generic;
using System.Linq;
using TaskManager.Model;



namespace TaskManager.Services
{
    public class TaskServices
    {
        //private static List<Taskitem> tasks = new List<Taskitem>();
        private readonly TaskitemContext _context;

        public TaskServices(TaskitemContext context)
        {
            _context = context;
        }

        public List<Taskitem> GetAllTasks()
        {
            return _context.Taskitems.ToList();
        }
        public Taskitem? GetTaskById(int id)
        {
            return _context.Taskitems.Find(id);
        }

        public Taskitem Add(Taskitem item)
        {
            _context.Taskitems.Add(item);
            _context.SaveChanges();
            return item;
        }

        public bool Delete(int id) {
            var existingItem = GetTaskById(id);
            if (existingItem == null) return false;
            _context.Taskitems.Remove(existingItem);
            _context.SaveChanges();
            return true;
        }
        public void Update(int id, Taskitem item) {
            var task = GetTaskById(id);
            if (task == null) return;
            task.Title= item.Title;
            task.IsCompleted = item.IsCompleted;

            _context.SaveChanges();
        }


        //private static int nextId = 1;
        //public List<Taskitem> GetAllTasks()
        //{
        //    return tasks;
        //}

        //public Taskitem? GetTaskById(int id)
        //{
        //    return tasks.FirstOrDefault(t => t.Id == id);
        //}

        //public Taskitem Add(Taskitem item)
        //{
        //    item.Id = nextId++;
        //    tasks.Add(item);
        //    return item;
        //}


        //public bool Update(int id, Taskitem updatedItem)
        //{
        //    var existingItem = GetTaskById(id);
        //    if (existingItem == null)
        //    {
        //        return false;
        //    }
        //    existingItem.Title = updatedItem.Title;
        //    existingItem.IsCompleted = updatedItem.IsCompleted;
        //    return true;
        //}

        //public bool Delete(int id) { 
        //    var existingItem = GetTaskById(id);
        //    if (existingItem == null)
        //    {
        //        return false;
        //    }
        //    tasks.Remove(existingItem);
        //    return true;
        //}

    }
}
