using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManager.Models
{
    public class Todo
    {
        public int Id { get; internal set; }
        public string Description { get; set; }
        public bool IsCompleted { get; private set; }

        public void Complete()
        {
            this.IsCompleted = true;
        }
    }

    public class TodoRepository {
        
        private static List<Todo> _todos = new List<Todo>();

        public static Todo Add(string description) {
            var newId = _todos.Any() ? _todos.Max(t => t.Id) + 1 : 1;
            var newTodo = new Todo { Id = newId, Description = description};
            _todos.Add(newTodo);
            return newTodo;
        }

        public static void Remove(int id) {
            _todos.Remove(_todos.First(t => t.Id == id));
        }

        public static IEnumerable<Todo> Todos
        {
            get
            {
                return (IEnumerable<Todo>)_todos;
            }
        }


        internal static void Add(Todo todo)
        {
            Add(todo.Description);
        }
    }
}