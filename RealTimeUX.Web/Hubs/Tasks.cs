using System;
using System.Collections.Generic;
using System.Diagnostics;
using AutoMapper;
using RealTimeUX.Web.Models;
using SignalR.Hubs;
using System.Linq;
using System.Data.Entity;
using System.Web.Helpers;

namespace RealTimeUX.Web.Hubs
{
    public class Tasks : Hub
    {
        public void GetAllCategories()
        {
            using (var context = new TestContext())
            {
                var res = context.Categories.ToArray();
                Caller.taskAll(res);
            }
        }

        /// <summary>
        /// Our method to create a task
        /// </summary>
        public bool Add(Task newTask)
        {
            try
            {
                using (var context = new TestContext())
                {
                    var task = context.Tasks.Create();
                    task.title = newTask.title;
                    task.completed = newTask.completed;
                    task.lastUpdated = DateTime.Now;
                    context.Tasks.Add(task);
                    context.SaveChanges();
                    Clients.taskAdded(task);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Caller.reportError("Unable to create task. Make sure title length is between 10 and 140");
                return false;
            }

        }

        /// <summary>
        /// Update a task using
        /// </summary>
        public bool Update(Task updatedTask)
        {
            using (var context = new TestContext())
            {
                var oldTask = context.Tasks.FirstOrDefault(t => t.taskId == updatedTask.taskId);
                try
                {
                    if (oldTask == null)
                        return false;
                    else
                    {
                        oldTask.title = updatedTask.title;
                        oldTask.completed = updatedTask.completed;
                        oldTask.lastUpdated = DateTime.Now;
                        context.SaveChanges();
                        Clients.taskUpdated(oldTask);
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Caller.reportError("Unable to update task. Make sure title length is between 10 and 140");
                    return false;
                }
            }

        }


        /// <summary>
        /// Delete the task
        /// </summary>
        public bool Remove(int taskId)
        {
            try
            {
                using (var context = new TestContext())
                {
                    var task = context.Tasks.FirstOrDefault(t => t.taskId == taskId);
                    context.Tasks.Remove(task);
                    context.SaveChanges();
                    Clients.taskRemoved(task.taskId);
                    return true;
                }
            }
            catch (Exception ex)
            {
                Caller.reportError("Error : " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// To get all the tasks up on init
        /// </summary>
        public void GetAll()
        {
            using (var context = new TestContext())
            {
                //var res = context.Tasks.Include(ToArray();
                var res = context.Tasks.Include(x=>x.Category).ToArray();

                //var temp = context.Categories
                //    .Include(x => x.Tasks);

                //var temp2 = (from i in temp
                //       select i.Tasks);
                //var blah = temp.ToArray();
                //var res = temp2.ToArray();
                //var res = from item in context.Tasks.Include()
                Caller.taskAll(res);
            }

        }
    }
}