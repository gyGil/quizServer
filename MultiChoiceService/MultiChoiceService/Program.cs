/// \file Program.cs
///
/// \class Program
/// 
/// \brief 
/// - This source file creates the initial Service Application by deriving the ServiceBase class.
///   
/// \author
/// - Marcus Rankin, Geun Young Gil, Ibrahim Naamani
/// 
/// \reference
/// - Norbert Mika: SET - Windows Mobile Programming - Modules 08.
/// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace MultiChoiceService
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new Service() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
