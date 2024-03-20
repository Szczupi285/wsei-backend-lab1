using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.NewFolder
{
    public abstract class QuizExceptions : Exception
    {
        public QuizExceptions(string? message) : base(message)
        {
        }
    }
}
