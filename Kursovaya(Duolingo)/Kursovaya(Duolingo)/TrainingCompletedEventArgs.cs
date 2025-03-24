using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovaya_Duolingo_
{
    public class TrainingCompletedEventArgs : EventArgs
    {
        public int CorrectAnswers { get; set; }
        public int TotalAnswers { get; set; }
    }
}
