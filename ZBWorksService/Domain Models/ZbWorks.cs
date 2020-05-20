using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ZBWorks.Domain_Models
{
    public enum DurationOfTask
    {
        [Description("Select Duration")]
        Time,

        [Description("15 mins")]
        FifteenMinutes,

        [Description("30 mins")]
        ThirtyMinutes,

        [Description("45 mins")]
        FortyFiveMinutes,

        [Description("1 hour")]
        OneHour,

        [Description("2 hour")]
        TwoHour,

        [Description("3 hour")]
        ThreeHour,

        [Description("4 hour")]
        FourHour,

        [Description("5 hour")]
        FiveHour,

        [Description("6 hour")]
        SixHour,

        [Description("7 hour")]
        SevenHour,

        [Description("8 hour")]
        EightHour,
    }
    public static class EnumExtensionMethods
    {
        public static string GetEnumDescription(this Enum enumValue)
        {
            var fieldInfo = enumValue.GetType().GetField(enumValue.ToString());

            var descriptionAttributes = (DescriptionAttribute[])fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return descriptionAttributes.Length > 0 ? descriptionAttributes[0].Description : enumValue.ToString();
        }
    }
    public class ZbWorks
    {

        public string EmployeeName { get; set; }
        public string InternalEmployeeID { get; set; }
        public string InternalZBWorksId { get; set; }
        public string TaskName { get; set; }
        public long TaskDate { get; set; }
        public int TaskDuration { get; set; } = 0;

        public string TaskDurationDescription
        {
            get
            {
                DurationOfTask curDuration = (DurationOfTask)TaskDuration;
                return curDuration.GetEnumDescription();
            }

            set
            {
                Type enumType = typeof(DurationOfTask);
                foreach (DurationOfTask duration in Enum.GetValues(enumType))
                {
                    if (duration.GetEnumDescription() == value)
                    {
                        TaskDuration = (int)duration;
                    }
                }

            }
        }

        public List<string> TaskDurationList
        {
            get
            {
                List<string> retVal = new List<string>();
                Type enumType = typeof(DurationOfTask);

                foreach (DurationOfTask duration in Enum.GetValues(enumType))
                {
                    retVal.Add(duration.GetEnumDescription());
                }

                return retVal;
            }
        }
        public DateTime DisplayTaskDate
        {
            get { return new DateTime(TaskDate); }
        }

    }
}
