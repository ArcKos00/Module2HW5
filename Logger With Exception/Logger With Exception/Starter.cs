using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LoggerLogic;

namespace Logger_With_Exception
{
    internal class Starter
    {
        public static void Run(int maxCount)
        {
            int counter = 0;
            while (counter < maxCount)
            {
                try
                {
                    switch (new Random().Next(0, 3))
                    {
                        case 0:
                            Actions.Method1();
                            break;
                        case 1:
                            throw Actions.Method2();
                        case 2:
                            Actions.Method3();
                            break;
                    }
                }
                catch (NewException ex)
                {
                    Logger.GetLogger.Log($"Action got this custom Exception: {ex.Message}", InfoType.Warning);
                }
                catch (Exception ex)
                {
                    Logger.GetLogger.Log($"Action failed by reason: {ex}", InfoType.Error);
                }

                counter++;
            }
        }
    }
}
