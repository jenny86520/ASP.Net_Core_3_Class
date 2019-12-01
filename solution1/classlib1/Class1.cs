using System;

namespace classlib1
{
    public class Class1
    {
        public string Go()
        {
            /** [start] 練習 .NET Standard 多目標架構作法 */
#if NET472
            return "net 4.7.2";
#else
            return ".net standard 2.0";
            /** [end] 練習 .NET Standard 多目標架構作法 */
#endif
        }
    }
}
