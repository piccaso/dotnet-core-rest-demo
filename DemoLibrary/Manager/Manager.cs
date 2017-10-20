using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace DemoLibrary.Manager
{

    public class ManagerData
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public interface IManager
    {
        ManagerData GetDataById(int id);
        bool UpdateData(ManagerData data);
    }

    public class Manager : IManager {
        public ManagerData GetDataById(int id) => new ManagerData(){Id = id, Name = $"Manager Nr {id}"};

        public bool UpdateData(ManagerData data)
        {
            if(data.Id < 0) throw new HorseShitException("For real!");
            return true;
        }
    }

    [Serializable]
    public class HorseShitException : Exception
    {

        public HorseShitException()
        {
        }

        public HorseShitException(string message) : base(message)
        {
        }

        public HorseShitException(string message, Exception inner) : base(message, inner)
        {
        }

        protected HorseShitException(
            SerializationInfo info,
            StreamingContext context) : base(info, context)
        {
        }
    }
}
