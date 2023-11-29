using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPFSample.Helps
{
    public class Log4NetObject
    {
        public static ILog LogConfinuration(Type type)
        {

            // 配置日志记录器
            Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();
            hierarchy.Root.RemoveAllAppenders();

            // 定义轮廓布局
            PatternLayout patternLayout = new PatternLayout();
            patternLayout.ConversionPattern = "%date [%thread] %-5level %logger - %message%newline";
            patternLayout.ActivateOptions();

            // 定义文件写入器appender
            #region test
            //FileAppender fileAppender = new FileAppender();
            //fileAppender.AppendToFile = true;
            //fileAppender.File = $"C:\\ProgramData\\Aucotec\\Engineering Base\\Logfiles\\{System.Environment.UserName}_dataprotal_log.log";
            //fileAppender.Layout = patternLayout;

            //fileAppender.ActivateOptions();
            #endregion

            var fileAppender = new RollingFileAppender
            {
                Name = "RollingFileAppender", 
                File = $"C:\\Logs\\{System.Environment.UserName}_log.log",
                AppendToFile = true,
                RollingStyle = RollingFileAppender.RollingMode.Composite,
                DatePattern = "yyyyMMdd",
                StaticLogFileName = true,
                Layout = patternLayout,
                MaximumFileSize = "100MB",
                MaxSizeRollBackups = 5
            };

            fileAppender.ActivateOptions();
            // 将appender添加到root记录器
            hierarchy.Root.AddAppender(fileAppender);
            hierarchy.Root.Level = log4net.Core.Level.Error;
            hierarchy.Configured = true;

            return LogManager.GetLogger(type);
        }

    }
}
