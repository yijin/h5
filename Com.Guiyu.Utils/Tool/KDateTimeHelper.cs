using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.Guiyu.Utils.Tool
{
    public static class KDateTimeHelper
    {
        /// <summary>
        /// 设置时间的显示方式
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static string TimeDes(DateTime time)
        {
            TimeSpan timeSpan = DateTime.Now - time;
            int minute = Convert.ToInt32(timeSpan.TotalMinutes);
            if (minute < 1)
            {
                return "刚刚";
            }
            if (minute < 60)
            {
                return minute + "分钟前";
            }

            int hours = Convert.ToInt32(timeSpan.TotalHours);
            if (hours < 24)
            {
                return hours + "小时前";
            }
            int day = Convert.ToInt32(timeSpan.TotalDays);
            if (day <= 30)
            {
                return day + "天前";
            }
            int month = day / 30;
            if (month < 12)
            {
                return month + "月前";
            }
            int year = month / 12;
            return year + "年前";
        }


        public static string FormatTime(DateTime time)
        {
            TimeSpan span = DateTime.Now - time;
            int m = Convert.ToInt32(span.TotalMinutes);
            if (m < 60)
            {
                return m + "分钟前";
            }

            if (span.Days == 1)
            {
                return "昨天" + "，" + time.Hour + "时";
            }
            if (span.Days == 0 && span.TotalDays < 1)
            {
                return Convert.ToInt32(span.TotalHours) + "小时前";
            }

            return time.ToString("yyyy年M月d日") + "，" + time.Hour + "时";

        }

        public static string GetWeek(DateTime time)
        {
            switch (time.DayOfWeek.ToString().ToLower())
            {
                case "monday":
                    return "星期一";
                case "tuesday":
                    return "星期二";
                case "wednesday":
                    return "星期三";
                case "thursday":
                    return "星期四";
                case "friday":
                    return "星期五";
                case "saturday ":
                    return "星期六";
                default:
                    return "星期日";
            }
        }
    }
}
